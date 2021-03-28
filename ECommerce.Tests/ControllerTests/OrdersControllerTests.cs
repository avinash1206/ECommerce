using ECommerce.Controllers;
using ECommerce.Services.Models;
using ECommerce.Services.Repository;
using ECommerce.Services.Repository.EntityFramework.Models;
using ECommerce.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Tests
{
    [TestClass]
    public class OrdersControllerTests
    {
        private OrderController _orderController;
        private Mock<ICustomerService> _mockICustomerService;

        [TestInitialize]
        public void TestInit()
        {
            _mockICustomerService = new Mock<ICustomerService>();
            _orderController = new OrderController(_mockICustomerService.Object);
        }

        [TestMethod]
        public async Task OrdersControllerShouldReturnSuccess()
        {
            //Arrange
            string status = "Success";
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            OrderDetails details = new OrderDetails()
            {
                CustomerEmail="abc@gmail.com",
                Location="abc",
                OrderPurchase=DateTime.Now,
                PinCode=1233,
                ProductName="Book",
                ProductSeller="xyz"
            };
            orderDetails.Add(details);

            //Act
            _mockICustomerService.Setup(x => x.CreateorderDetails(It.IsAny<List<OrderDetails>>())).Returns(Task.FromResult(status));
            var response = await _orderController.OrderDetails(orderDetails);

            //Assert
            Assert.AreEqual(status, response);
        }

        [TestMethod]
        public async Task OrdersControllerShouldReturnFailedResponse()
        {
            //Arrange
            string status = "Failed";
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            OrderDetails details = new OrderDetails()
            {
                CustomerEmail = "abc@gmail.com",//Existing EmailId
                Location = "abc",
                OrderPurchase = DateTime.Now,
                PinCode = 1233,
                ProductName = "Book",
                ProductSeller = "xyz"
            };
            orderDetails.Add(details);

            //Act
            _mockICustomerService.Setup(x => x.CreateorderDetails(It.IsAny<List<OrderDetails>>())).Returns(Task.FromResult(status));
            var response = await _orderController.OrderDetails(orderDetails);

            //Assert
            Assert.AreEqual(status, response);
        }

        [TestMethod]
        public async Task OrdersControllerShouldReturnResponse()
        {
            //Arrange
            string customerEmail = "abc@gmail.com";
            List<OrderDetail> orderDetails = new List<OrderDetail>()
            {
                new OrderDetail()
                {
                    CustomerEmail = "abc@gmail.com",
                    Location = "abc",
                    OrderPurchase = DateTime.Now,
                    PinCode = "1233",
                    ProductName = "Book",
                    ProductSeller = "xyz"
                },
                new OrderDetail()
                {
                    CustomerEmail = "abc@gmail.com",
                    Location = "abc",
                    OrderPurchase = DateTime.Now,
                    PinCode = "1233",
                    ProductName = "Mobile",
                    ProductSeller = "xyz"
                }
            };
           
            //Act
            _mockICustomerService.Setup(x => x.GetOrderDeatails(It.IsAny<string>())).Returns(Task.FromResult(orderDetails));
            var response = await _orderController.GetOrderDeatails(customerEmail);

            //Assert
            Assert.AreEqual(2, response.Count);
            Assert.AreEqual("abc@gmail.com", response[0].CustomerEmail);
        }

        [TestMethod]
        public async Task OrdersControllerShouldReturnNullResponse()
        {
            //Arrange
            string customerEmail = "abc@gmail.com";
            List<OrderDetail> orderDetails = new List<OrderDetail>()
            {
            };

            //Act
            _mockICustomerService.Setup(x => x.GetOrderDeatails(It.IsAny<string>())).Returns(Task.FromResult(orderDetails));
            var response = await _orderController.GetOrderDeatails(customerEmail);

            //Assert
            Assert.AreEqual(0, response.Count);
        }
    }
}
