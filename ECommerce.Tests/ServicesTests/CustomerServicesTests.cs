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

namespace ECommerce.Tests.ServicesTests
{
    [TestClass]
    public class CustomerServicesTests
    {
        private CustomerService _customerService;
        private Mock<ICustomerRepository> _mockICustomerRepository;
        [TestInitialize]
        public void TestInit()
        {
            _mockICustomerRepository = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_mockICustomerRepository.Object);
        }
        [TestMethod]
        public async Task CustomerDetailsShouldReturnSuccessResponse()
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
            _mockICustomerRepository.Setup(x => x.CreateCustomersData(It.IsAny<List<CustomerDetail>>())).Returns(Task.FromResult(status));
            var response = await _customerService.CustomerDetails(customerDetails);

            //Assert
            Assert.AreEqual(status, response);
        }

        [TestMethod]
        public async Task CustomerDetailsShouldReturnfailedResponse()
        {
            //Arrange
            string status = "Failed";
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
            _mockICustomerRepository.Setup(x => x.CreateCustomersData(It.IsAny<List<CustomerDetail>>())).Returns(Task.FromResult(status));
            var response = await _customerService.CustomerDetails(customerDetails);

            //Assert
            Assert.AreEqual(status, response);
        }

        [TestMethod]
        public async Task CreateorderDetailsShouldReturnSuccessResponse()
        {
            //Arrange
            string status = "Success";
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            OrderDetails details = new OrderDetails()
            {
                CustomerEmail = "abc@gmail.com",
                Location = "abc",
                OrderPurchase = DateTime.Now,
                PinCode = 1233,
                ProductName = "Book",
                ProductSeller = "xyz"
            };
            orderDetails.Add(details);

            //Act
            _mockICustomerRepository.Setup(x => x.CreateOrdersData(It.IsAny<List<OrderDetail>>())).Returns(Task.FromResult(status));
            var response = await _customerService.CreateorderDetails(orderDetails);

            //Assert
            Assert.AreEqual(status, response);
        }

        [TestMethod]
        public async Task CreateorderDetailsShouldReturnfailedResponse()
        {
            //Arrange
            string status = "Failed";
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            OrderDetails details = new OrderDetails()
            {
                CustomerEmail = "abc@gmail.com",//EmailId Doesnt Exists
                Location = "abc",
                OrderPurchase = DateTime.Now,
                PinCode = 1233,
                ProductName = "Book",
                ProductSeller = "xyz"
            };
            orderDetails.Add(details);

            //Act
            _mockICustomerRepository.Setup(x => x.CreateOrdersData(It.IsAny<List<OrderDetail>>())).Returns(Task.FromResult(status));
            var response = await _customerService.CreateorderDetails(orderDetails);

            //Assert
            Assert.AreEqual(status, response);
        }

        [TestMethod]
        public async Task GetOrderDeatailsShouldReturnSuccessResponse()
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
            _mockICustomerRepository.Setup(x => x.GetOrderDeatails(It.IsAny<string>())).Returns(Task.FromResult(orderDetails));
            var response = await _customerService.GetOrderDeatails(customerEmail);

            //Assert
            Assert.AreEqual(2, response.Count);
            Assert.AreEqual("abc@gmail.com", response[0].CustomerEmail);
        }

        [TestMethod]
        public async Task GetOrderDeatailsShouldReturnfailedNullResponse()
        {
            //Arrange
            string customerEmail = "abc@gmail.com";
            List<OrderDetail> orderDetails = new List<OrderDetail>()
            {
            };

            //Act
            _mockICustomerRepository.Setup(x => x.GetOrderDeatails(It.IsAny<string>())).Returns(Task.FromResult(orderDetails));
            var response = await _customerService.GetOrderDeatails(customerEmail);

            //Assert
            Assert.AreEqual(0, response.Count);
        }
    }
}
