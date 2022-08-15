using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test_Vehicle.Commands;
using Test_Vehicle.Models;

namespace Test_Vehicle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesMediatRController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public VehiclesMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            var request = new GetVehicles.Query { };
            return await _mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<Vehicle> GetVehicles(Guid id)
        {
            var request = new GetVehicle.Query { Id = id };
            //return BadRequest(new { message= "Error" });
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<ActionResult> CreateVehicle([FromBody] AddVehicle.Command command)
        {
            var createdVehicleId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetVehicle), new { Id= createdVehicleId}, null);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVehicle(Guid Id)
        {
            await _mediator.Send(new DeleteVehicle.Command { Id=Id});
            return NoContent();
        }

    }
}
