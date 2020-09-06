using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QGSVL.API.Controllers;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL.EntityLayer.Entities.BusinessEntity;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.API.Tests
{
    [TestClass]
    public class VehicleTest
    {
        private readonly Mock<IVehicleService> _vehicleService = new Mock<IVehicleService>();
        private readonly VehicleController vehicleController;
        public VehicleTest()
        {
            vehicleController = new VehicleController(_vehicleService.Object);
        }

        [TestMethod]
        public async Task GetVehicles_IfRecordsExist_ReturnsOkObjectResult()
        {
            //Arrange
            List<VehicleDetail> vehicles = new List<VehicleDetail>();
            vehicles.Add(new VehicleDetail
            {
                Id = 1,
                Image = "sdfsd",
                Type = "sdfsdf",
                Brand = "sdfsd",
                ModelName = "sdfsdf",
                HorsePower = "sdfsdf",
                FuelConsumption = "sdfsdf",
                CO2Emission = "sdfsdf",
                FuelType = "sdfsdf",
                Seating = 2,
                ABS = true,
                Airbag = 3,
                Transmission = "sdfsdf",
                Colour = "sdfsdf",
                Price = 3
            });

            _vehicleService.Setup(x => x.GetVehicles()).ReturnsAsync(vehicles);

            //Act
            var result = await vehicleController.GetVehicles() as OkObjectResult ;

            //Assert
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetVehicles_IfRecordsNotExist_ReturnsNotFoundResult()
        {
            //Arrange
            List<VehicleDetail> vehicles = null;

            _vehicleService.Setup(x => x.GetVehicles()).ReturnsAsync(vehicles);

            //Act
            IActionResult result = await vehicleController.GetVehicles();

            //Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetVehicle_IfRecordExist_ReturnsOkObjectResult()
        {
            //Arrange
            VehicleDetail vehicleDetail = new VehicleDetail()
            {
                Id = 1,
                Image = "sdfsd",
                Type = "sdfsdf",
                Brand = "sdfsd",
                ModelName = "sdfsdf",
                HorsePower = "sdfsdf",
                FuelConsumption = "sdfsdf",
                CO2Emission = "sdfsdf",
                FuelType = "sdfsdf",
                Seating = 2,
                ABS = true,
                Airbag = 3,
                Transmission = "sdfsdf",
                Colour = "sdfsdf",
                Price = 3
            };
            string[] mainEqupment = new string[] { "asasd","asdasd"};
            string[] standardEquipment = new string[] { "asasd","asdasd"};
            string[] IncludedServices = new string[] { "asasd","asdasd"};
            VehicleDetailVM vehicle = new VehicleDetailVM(){
                Vehicle = vehicleDetail,
                MainEquipments = mainEqupment,
                StandardEquipments = standardEquipment,
                IncludedServices = IncludedServices,
            };
            int VehicleId = 2;
            _vehicleService.Setup(x => x.GetVehicle(VehicleId)).ReturnsAsync(vehicle);

            //Act
            var result = await vehicleController.GetVehicle(VehicleId) as OkObjectResult;

            //Assert
            Assert.AreEqual(vehicle, result.Value);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetVehicle_IfRecordNotExist_ReturnsNotFoundObjectResult()
        {
            //Arrange
            VehicleDetailVM vehicle = null ;
            int VehicleId = 1;

            _vehicleService.Setup(x => x.GetVehicle(VehicleId)).ReturnsAsync(vehicle);

            //Act
            var result = await vehicleController.GetVehicle(VehicleId) as NotFoundObjectResult;

            //Assert
            Assert.AreEqual("Data not found!", result.Value);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public async Task GetVehicleFilters_IfRecordsExist_ReturnsOkObjectResult()
        {
            //Arrange
            string[] item1 = new string[] { "asda" };
            string[] item2 = new string[] { "asda" };
            string[] item3 = new string[] { "asda" };
            string[] item4 = new string[] { "asda" };
            List<object> filters = new List<object>()
            {
                item1,item2,item3,item4
            };

            _vehicleService.Setup(x => x.GetVehicleFilters()).ReturnsAsync(filters);

            //Act
            var result = await vehicleController.GetVehicles() as OkObjectResult;

            //Assert
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetVehicleFilters_IfRecordsNotExist_ReturnsNotFound()
        {
            //Arrange
            List<object> filters = new List<object>();
            filters = null;
            _vehicleService.Setup(x => x.GetVehicleFilters()).ReturnsAsync(filters);

            //Act
            var result = await vehicleController.GetVehicleFilters() as NotFoundObjectResult;

            //Assert
            Assert.AreEqual("No Filters Found", result.Value);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}
