using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface ICustomerService
    {
        Task Add(AddCustomerInput input);
        Task Delete(DeleteCustomerInput input);
        Task<Customer> Get([FromQuery] QueryeCustomerInput input);
        Task<dynamic> List([FromQuery] CustomerInput input);
        Task<dynamic> Page([FromQuery] CustomerInput input);
        Task Update(UpdateCustomerInput input);
    }
}