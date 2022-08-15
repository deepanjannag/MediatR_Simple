using System;
using System.Collections.Generic;
using System.Linq;
using Test_Vehicle.Models;

namespace Test_Vehicle.Data
{
    public class MockVehicleData : IVehicleData
    {
        private List<Vehicle> _vehicles = new List<Vehicle> {
            new Vehicle{
                Id = Guid.NewGuid(),
                Year = 1980,
                Model ="Z",
                Make = "Rolls Royce"
            },
            new Vehicle{
                Id = Guid.NewGuid(),
                Year = 1990,
                Model ="A",
                Make = "Buick"
            },
            new Vehicle{
                Id = Guid.NewGuid(),
                Year = 1970,
                Model ="B",
                Make = "Cadillac"
            },
            new Vehicle{
                Id = Guid.NewGuid(),
                Year = 1960,
                Model ="C",
                Make = "Pontiac"
            }
        };

        public Vehicle AddVehicle(Vehicle vehicle)
        {
            vehicle.Id = Guid.NewGuid();
            _vehicles.Add(vehicle);
            return vehicle;
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            _vehicles.Remove(vehicle);
        }

        public Vehicle EditVehicle(Vehicle vehicle)
        {
            var vehicleToBeEdited = GetVehicles(vehicle.Id);
            vehicleToBeEdited.Make = vehicle.Make;
            vehicleToBeEdited.Year = vehicle.Year;
            vehicleToBeEdited.Model = vehicle.Model;
            return vehicleToBeEdited;
        }

        public List<Vehicle> GetVehicles()
        {
            return _vehicles;
        }

        public Vehicle GetVehicles(Guid id)
        {
            return _vehicles.SingleOrDefault(v => v.Id == id);
        }

        public List<Vehicle> GetVehiclesFilter(string attribute, string value)
        {
            if (string.IsNullOrEmpty(attribute) || string.IsNullOrEmpty(value))
                return _vehicles;

            var vehicles = new List<Vehicle>();

            switch (attribute.ToLower())
            {
                case "year": _vehicles.Where(v => v.Year.ToString().ToLower().Contains(value.ToLower())).ToList().ForEach(v => vehicles.Add(v)); break;
                case "make": _vehicles.Where(v => v.Make.ToString().ToLower().Contains(value.ToLower())).ToList().ForEach(v => vehicles.Add(v)); break;
                case "model": _vehicles.Where(v => v.Model.ToString().ToLower().Contains(value.ToLower())).ToList().ForEach(v => vehicles.Add(v)); break;
                case "id": _vehicles.Where(v => v.Id.ToString().ToLower().Contains(value.ToLower())).ToList().ForEach(v => vehicles.Add(v)); break;
                default: vehicles = _vehicles; break;
            }
            return vehicles;
        }


    }
}
