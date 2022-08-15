using System;
using System.Collections.Generic;
using System.Linq;
using Test_Vehicle.Models;

namespace Test_Vehicle.Data
{
    public class SqlVehicleData : IVehicleData
    {
        private VehicleContext _context;

        public SqlVehicleData(VehicleContext context)
        {
            _context = context;
        }

        public Vehicle AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            return vehicle;
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
        }

        public Vehicle EditVehicle(Vehicle vehicle)
        {
            var existingVehicle = _context.Vehicles.Find(vehicle.Id);
            if (existingVehicle != null)
            {
                existingVehicle.Year = vehicle.Year;
                existingVehicle.Make = vehicle.Make;
                existingVehicle.Model = vehicle.Model;
                _context.Vehicles.Update(existingVehicle);
                _context.SaveChanges();
            }
            return vehicle;
        }

        public List<Vehicle> GetVehicles()
        {
            return _context.Vehicles.ToList();
        }

        public Vehicle GetVehicles(Guid id)
        {
            return _context.Vehicles.SingleOrDefault(v => v.Id == id);
        }

        public List<Vehicle> GetVehiclesFilter(string attribute, string value)
        {
            throw new NotImplementedException();
        }
    }
}
