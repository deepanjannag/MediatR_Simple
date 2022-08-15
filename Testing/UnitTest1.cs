using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Test_Vehicle.Data;
using Test_Vehicle.Models;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetNumberOfVehiclesTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle { Make = "Maruti", Model = "800", Year = 2021 };
            Vehicle vehicle2 = new Vehicle { Make = "Contessa", Model = "Classic", Year = 2000 };
            Vehicle vehicle3 = new Vehicle { Make = "Padmini", Model = "Pad", Year = 1976 };

            //act
            MockVehicleData repo = new MockVehicleData();
            repo.AddVehicle(vehicle);
            repo.AddVehicle(vehicle2);
            repo.AddVehicle(vehicle3);


            //assert
            Assert.IsTrue(repo.GetVehicles().Count() == 7);
        }

        [TestMethod]
        public void AddVehicleTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle { Make = "Rolls Royce", Model = "Silver Spirit", Year = 1990 };

            //act
            MockVehicleData repo = new MockVehicleData();
            repo.AddVehicle(vehicle);

            //assert
            Assert.IsTrue(repo.GetVehicles().Contains(vehicle));
        }

        [TestMethod]
        public void GetVehicleByIdTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle { Make = "Impala", Model = "Unknown", Year = 1999 };


            //act
            MockVehicleData repo = new MockVehicleData();
            repo.AddVehicle(vehicle);


            //assert
            Assert.ReferenceEquals(repo.GetVehicles(vehicle.Id), vehicle);
        }

        [TestMethod]
        public void DeleteVehicleTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle { Make = "Buick", Model = "Unknown", Year = 1928 };


            //act
            MockVehicleData repo = new MockVehicleData();
            Guid id = repo.AddVehicle(vehicle).Id;
            repo.DeleteVehicle(vehicle);


            //assert
            Assert.IsNull(repo.GetVehicles(id));
        }

        [TestMethod]
        public void UpdateVehicleTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle { Make = "BMW", Model = "WWW", Year = 1988 };
            Vehicle updatedVehicle = new Vehicle { Make = "BMW", Model = "MMM", Year = 1977 };

            //act
            MockVehicleData repo = new MockVehicleData();

            Guid id = repo.AddVehicle(vehicle).Id;
            updatedVehicle.Id = id;
            repo.EditVehicle(updatedVehicle);

            //assert
            Assert.ReferenceEquals(vehicle, updatedVehicle);
        }

        [TestMethod]
        public void FilterVehicleTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle { Make = "Marc", Model = "SixDoor", Year = 1988 };
            Vehicle vehicle2 = new Vehicle { Make = "Marc", Model = "FourDoor", Year = 1945 };


            //act
            MockVehicleData repo = new MockVehicleData();
            repo.AddVehicle(vehicle);
            repo.AddVehicle(vehicle2);


            //assert
            Assert.IsTrue(repo.GetVehiclesFilter("Model", "Door").Count == 2);
        }
    }
}
