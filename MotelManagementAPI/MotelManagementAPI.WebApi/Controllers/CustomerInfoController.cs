using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotelManagementAPI.Application.Features.Customers.Commands.CreateCustomer;
using MotelManagementAPI.Application.Features.Customers.Commands.DeleteCustomer;
using MotelManagementAPI.Application.Features.Customers.Queries.GetAllCustomer;
using MotelManagementAPI.Application.Features.Customers.Queries.GetCutomerById;

namespace MotelManagementAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCustomersParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllCustomersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = id }));
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //[HttpPut("{id}")]
        ////[Authorize]
        //public async Task<IActionResult> Put(int id, UpdateRoomDetailCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await Mediator.Send(command));
        //}

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCustomerByIdCommand { Id = id }));
        }
    }
}
