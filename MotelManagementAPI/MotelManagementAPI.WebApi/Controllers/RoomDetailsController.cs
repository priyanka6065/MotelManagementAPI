using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotelManagementAPI.Application.Features.Products.Commands;
using MotelManagementAPI.Application.Features.Products.Commands.CreateProduct;
using MotelManagementAPI.Application.Features.Products.Commands.DeleteProductById;
using MotelManagementAPI.Application.Features.Products.Commands.UpdateProduct;
using MotelManagementAPI.Application.Features.Products.Queries.GetAllProducts;
using MotelManagementAPI.Application.Features.Products.Queries.GetProductById;
using MotelManagementAPI.Application.Features.RoomDetails.Commands.CreateRoomDetail;
using MotelManagementAPI.Application.Features.RoomDetails.Commands.UpdateRoomDetail;
using MotelManagementAPI.Application.Features.RoomDetails.Queries.GetAllRoomDetails;
using MotelManagementAPI.Application.Features.RoomDetails.Queries.GetRoomDetailById;
using MotelManagementAPI.Application.Filters;

namespace MotelManagementAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RoomDetailsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllRoomDetailsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllRoomDetailsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetRoomDetailByIdQuery { Id = id }));
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreateRoomDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateRoomDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
    }
}
