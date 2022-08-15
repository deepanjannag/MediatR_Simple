using Microsoft.EntityFrameworkCore;
using Test_Vehicle.Models;

namespace Test_Vehicle.Data
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        { }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
