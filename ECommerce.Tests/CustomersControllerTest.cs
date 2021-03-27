using ECommerce.Controllers;
using ECommerce.Services.Models;
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
    public class CustomersControllerTest
    {
        private CustomersController _customersController;
        private Mock<ICustomerService> _mockICustomerService;
        [TestInitialize]
        public void TestInit()
        {
            _mockICustomerService = new Mock<ICustomerService>();
            _customersController = new CustomersController(_mockICustomerService.Object);
        }
        [TestMethod]
        public async Task CustomersControllerShouldReturnSuccess()
        {
            //Arrange
            string status = "Success";
            List<CustomerDetails> customerDetails = new List<CustomerDetails>();
            CustomerDetails customerDetails1 = new CustomerDetails()
            {
                Address = "Abc",
                AlternatePhoneNumber = "1122334455",
                CustomerEmail = "abc@gmail.com",
                CustomerName = "abc",
                PhoneNumber = "1122331122",
                RegestationDate = DateTime.Now
            };
            customerDetails.Add(customerDetails1);

            //Act
            _mockICustomerService.Setup(x => x.CustomerDetails(It.IsAny<List<CustomerDetails>>())).Returns(Task.FromResult(status));
            var response = await _customersController.CustomerDetails(customerDetails);

            //Assert
            Assert.AreEqual(status, response);
        }
    }
}
