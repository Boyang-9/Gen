using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IProjectService
    {
        Task Add(AddProjectInput input);
        Task Delete(DeleteProjectInput input);
        Task<Project> Get([FromQuery] QueryeProjectInput input);
        Task<dynamic> List([FromQuery] ProjectInput input);
        Task<dynamic> Page([FromQuery] ProjectInput input);
        Task Update(UpdateProjectInput input);
        Task<dynamic> FkSysUserList();
        Task<dynamic> FkCustomerList();
        Task<dynamic> FkCustomerMineList();
    }
}