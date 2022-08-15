using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test_Vehicle.Models;

namespace Test_Vehicle.Data
{
    public interface IVehicleData
    {
        List<Vehicle> GetVehicles();

        Vehicle GetVehicles(Guid id);

        Vehicle AddVehicle(Vehicle vehicle);

        void DeleteVehicle(Vehicle vehicle);

        Vehicle EditVehicle(Vehicle vehicle);

        List<Vehicle> GetVehiclesFilter(string attribute, string value);
    }
}
