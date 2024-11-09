using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
namespace UnitTests
{
    internal class GarageTests
    {
    }
}





/*

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp.Models;
using ConsoleApp;
*/



namespace UnitTests
{
    [TestClass]
    public class GarageTests
    {
        [TestMethod]
        public void ParkVehicle_ShouldAddVehicle()
        {
            var garage = new ParkingGarage();
            var vehicle = new Car("ABC123");

            garage.ParkVehicle(vehicle);

            Assert.IsTrue(garage.IsVehicleParked("ABC123"));
        }

        [TestMethod]
        public void RemoveVehicle_ShouldRemoveVehicle()
        {
            var garage = new ParkingGarage();
            var vehicle = new Car("XYZ789");
            garage.ParkVehicle(vehicle);

            garage.RemoveVehicle("XYZ789");

            Assert.IsFalse(garage.IsVehicleParked("XYZ789"));
        }
    }
}
