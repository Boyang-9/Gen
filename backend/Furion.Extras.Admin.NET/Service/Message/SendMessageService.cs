﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Furion.Extras.Admin.NET.Service
{
    /// <summary>
    /// 消息发送服务
    /// </summary>
    [ApiDescriptionSettings(Name = "Message", Order = 100)]
    public class SendMessageService : ISendMessageService, IDynamicApiController, ITransient
    {
        private readonly ISysCacheService _sysCacheService;
        private readonly IHubContext<ChatHub, IChatClient> _chatHubContext;

        public SendMessageService(ISysCacheService sysCacheService, IHubContext<ChatHub, IChatClient> chatHubContext)
        {
            _sysCacheService = sysCacheService;
            _chatHubContext = chatHubContext;
        }

        /// <summary>
        /// 发送消息给所有人
        /// </summary>
        /// <param name="title">发送标题</param>
        /// <param name="message">发送内容</param>
        /// <param name="type">消息类型</param>
        /// <returns></returns>
        [HttpGet("/sysMessage/allUser")]
        public async Task SendMessageToAllUser(string title, string message, MessageType type)
        {
            await _chatHubContext.Clients.All.ReceiveMessage(new {title = title, message = message, messagetype = type });
        }

        /// <summary>
        /// 发送消息给除了发送人的其他人
        /// </summary>
        /// <param name="title">发送标题</param>
        /// <param name="message">发送内容</param>
        /// <param name="userId">发送人</param>
        /// <param name="type">消息类型</param>
        /// <returns></returns>
        [HttpGet("/sysMessage/otherUser")]
        public async Task SendMessageToOtherUser(string title, string message,MessageType type, long userId)
        {
            var onlineuserlist = await _sysCacheService.GetAsync<List<OnlineUser>>(CommonConst.CACHE_KEY_ONLINE_USER);

            var user = onlineuserlist.Where(x => x.UserId == userId).ToList();

            if (user != null)
            {
                await _chatHubContext.Clients.AllExcept(user[0].ConnectionId).ReceiveMessage(new {title = title, message = message, messagetype= type });
            }
        }

        /// <summary>
        /// 发送消息给某个人
        /// </summary>
        /// <param name="title">发送标题</param>
        /// <param name="message">发送内容</param>
        /// <param name="userId">接收人</param>
        /// <param name="type">消息类型</param>
        /// <returns></returns>
        [HttpGet("/sysMessage/user")]
        public async Task SendMessageToUser(string title, string message, MessageType type, long userId)
        {
            var onlineuserlist = await _sysCacheService.GetAsync<List<OnlineUser>>(CommonConst.CACHE_KEY_ONLINE_USER);

            var user = onlineuserlist.Where(x => x.UserId == userId).ToList();
            if (user != null)
            {
                foreach (var item in user)
                {
                    await _chatHubContext.Clients.Client(item.ConnectionId).ReceiveMessage(new { title = title, message = message, messagetype = type });

                }
            }
        }

        /// <summary>
        /// 发送消息给某些人
        /// </summary>
        /// <param name="title">发送标题</param>
        /// <param name="message">发送内容</param>
        /// <param name="userId">接收人列表</param>
        /// <param name="type">消息类型</param>
        /// <returns></returns>
        [HttpGet("/sysMessage/users")]
        public async Task SendMessageToUsers(string title, string message, MessageType type, List<long> userId)
        {
            var onlineuserlist = await _sysCacheService.GetAsync<List<OnlineUser>>(CommonConst.CACHE_KEY_ONLINE_USER);

            List<string> userlist = new List<string>();

            foreach (var item in onlineuserlist)
            {
                if (userId.Contains(item.UserId))
                {
                    userlist.Add(item.ConnectionId);
                }
            }
            await _chatHubContext.Clients.Clients(userlist).ReceiveMessage(new { title = title, message = message, messagetype = type });
        }
    }
}
