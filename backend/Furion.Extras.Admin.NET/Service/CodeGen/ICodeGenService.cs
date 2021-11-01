﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service.CodeGen
{
    public interface ICodeGenService
    {
        Task AddCodeGen(AddCodeGenInput input);

        Task DeleteCodeGen(List<DeleteCodeGenInput> inputs);

        Task<SysCodeGen> GetCodeGen([FromQuery] QueryCodeGenInput input);

        List<TableColumnOuput> GetColumnList(AddCodeGenInput input);

        List<TableOutput> GetTableList();

        Task<dynamic> QueryCodeGenPageList([FromQuery] CodeGenPageInput input);

        Task RunLocal(SysCodeGen input);

        Task UpdateCodeGen(UpdateCodeGenInput input);
    }
}