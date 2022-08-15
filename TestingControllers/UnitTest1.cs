using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Test_Vehicle.Controllers;
using Test_Vehicle.Data;
using Test_Vehicle.Models;
using System.Net.Http;
using System.Web.Http;

namespace TestingControllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void AllVehiclesCounter()
        {
            //Arrange
            MockVehicleData repo = new MockVehicleData();

            Vehicle vehicle = new Vehicle { Make = "Maruti", Model = "800", Year = 2021 };
            Vehicle vehicle2 = new Vehicle { Make = "Contessa", Model = "Classic", Year = 2000 };
            Vehicle vehicle3 = new Vehicle { Make = "Padmini", Model = "Pad", Year = 1976 };

            repo.AddVehicle(vehicle);
            repo.AddVehicle(vehicle2);
            repo.AddVehicle(vehicle3);

            var controller = new VehiclesController(repo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()

            };



            //Act

            //Assert
        }
    }
}
