using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QGSVL.API.Controllers;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.API.Tests
{
    [TestClass]
    public class AdministratorTest
    {
        private readonly Mock<IAdministratorService> _administratorMock = new Mock<IAdministratorService>();
        private readonly AdministratorController _administratorController;

        public AdministratorTest()
        {
            _administratorController = new AdministratorController(_administratorMock.Object);
        }

        [TestMethod]
        public async Task GetAllQuotes_IfRecordsExist_ReturnsOkObjectResult()
        {
            //Arrange
            List<QuoteVM> quotes = new List<QuoteVM>();
            quotes.Add(new QuoteVM
            {
                Id = 1,
                Brand = "asdasd",
                Model = "asdasd",
                RentalDate = new DateTime(1998, 04, 30),
                Insurance = 223,
                Mileage = 234,
                PaybackTime = 2342,
                TotalPrice = 23423,
                QuoteStatus = "sdfsdf"
            });

            _administratorMock.Setup(x => x.GetAllQuotes()).ReturnsAsync(quotes);

            //Act
            var result = await _administratorController.GetAllQuotes() as OkObjectResult;

            //Assert
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetAllQuotes_IfRecordsNotExist_ReturnsNotFoundObjectResult()
        {
            //Arrange
            List<QuoteVM> quote = null;

            _administratorMock.Setup(x => x.GetAllQuotes()).ReturnsAsync(quote);

            //Act
            var result = await _administratorController.GetAllQuotes() as NotFoundObjectResult;

            //Assert
            Assert.AreEqual("No Records Found", result.Value);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public async Task GetAllQuoteStatus_IfRecordsExist_ReturnsOkObjectResult()
        {
            //Arrange
            List<QuoteStatus> quoteStatus = new List<QuoteStatus>() { 
            };
            quoteStatus.Add(new QuoteStatus
            {
                Id = 1,
                Name = "Pending"
            });
            quoteStatus.Add(new QuoteStatus
            {
                Id = 2,
                Name = "Accepted"
            });

            _administratorMock.Setup(x => x.GetAllQuoteStatus()).ReturnsAsync(quoteStatus);

            //Act
            var result = await _administratorController.GetAllQuoteStatus() as OkObjectResult;

            //Assert
            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetAllQuoteStatus_IfRecordsNotExist_ReturnsNotFoundObjectResult()
        {
            //Arrange
            List<QuoteStatus> quoteStatus = null;

            _administratorMock.Setup(x => x.GetAllQuoteStatus()).ReturnsAsync(quoteStatus);

            //Act
            var result = await _administratorController.GetAllQuoteStatus() as NotFoundObjectResult;

            //Assert
            Assert.AreEqual("No Statuses Found.", result.Value);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

    }
}
