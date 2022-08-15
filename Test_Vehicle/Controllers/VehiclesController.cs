using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Test_Vehicle.Data;
using Test_Vehicle.Models;

namespace Test_Vehicle.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private IVehicleData _vehicleData;
        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="vehicleData"></param>
        public VehiclesController(IVehicleData vehicleData)
        {
            _vehicleData = vehicleData;
        }

        /// <summary>
        /// All vehicles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetVehicles()
        {
            return Ok(_vehicleData.GetVehicles());
        }

        /// <summary>
        /// Vehicle based on Id
        /// </summary>
        /// <param name="id"></param>
        /// GET api/vehicles/79ab817e-6c7e-4c39-ad89-fe43c2180714
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetVehicles(Guid id)
        {
            var employee = _vehicleData.GetVehicles(id);
            if (employee != null)
                return Ok(_vehicleData.GetVehicles(id));
            else
                return NotFound($"Vehicle with id: {id} was not found");
        }


        /// <summary>
        /// Add vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// POST api/vehicles
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddVehicle(Vehicle vehicle)
        {
            _vehicleData.AddVehicle(vehicle);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + vehicle.Id, vehicle);
        }


        /// <summary>
        /// Remove vehicle
        /// </summary>
        /// <param name="id"></param>
        /// DELETE api/vehicles/79ab817e-6c7e-4c39-ad89-fe43c2180714
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteVehicle(Guid id)
        {
            var vehicle = _vehicleData.GetVehicles(id);

            if (vehicle != null)
            {
                _vehicleData.DeleteVehicle(vehicle);
                return Ok();
            }

            return NotFound($"Vehicle with id: {id} was not found");
        }


        /// <summary>
        /// Update vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vehicle"></param>
        /// PATCH api/vehicle/79ab817e-6c7e-4c39-ad89-fe43c2180714
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditVehicle(Guid id, Vehicle vehicle)
        {
            var vehicleToBeEdited = _vehicleData.GetVehicles(id);
            if (vehicleToBeEdited != null)
            {
                vehicle.Id = vehicleToBeEdited.Id;
                _vehicleData.EditVehicle(vehicle);
            }

            return Ok(vehicleToBeEdited);
        }


        /// <summary>
        /// Search based on criterion
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// GET api/vehicles/year/1990
        [HttpGet]
        [Route("api/[controller]/{attribute}/{value}")]
        public IActionResult GetVehiclesFiltered(string attribute, string value)
        {
            return Ok(_vehicleData.GetVehiclesFilter(attribute, value));
        }
    }
}
