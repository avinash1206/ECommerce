using ECommerce.Services.Models;
using ECommerce.Services.Repository;
using ECommerce.Services.Repository.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Services
{
    public interface ICustomerService
    {
        Task<string> CustomerDetails(CustomerDetails customerDetails);
        Task<string> CreateorderDetails(OrderDetails orderDetails);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<string> CreateorderDetails(OrderDetails orderDetails)
        {
            Guid orderId = Guid.NewGuid();
            var customerData = BuildOrdersData(orderDetails, orderId);
            string sucess = await _customerRepository.CreateOrdersData(customerData);
            return sucess;
        }

        public async Task<string> CustomerDetails(CustomerDetails customerDetails)
        {
            Guid customerId = Guid.NewGuid();
            var customerData = BuildCustomerData(customerDetails, customerId);
            string sucess= await _customerRepository.CreateCustomersData(customerData);
            return sucess;
        }
        private CustomerDetail BuildCustomerData(CustomerDetails customerDetails, Guid customerId)
        {
            CustomerDetail customerDetail = new CustomerDetail();

            customerDetail.CustomerId = Guid.NewGuid().ToString();
            customerDetail.CustomerEmail = customerDetails.CustomerEmail;
            customerDetail.CustomerName = customerDetails.CustomerName;
            customerDetail.Address = customerDetails.Address;
            customerDetail.PhoneNumber = customerDetails.PhoneNumber;
            customerDetail.AlternatePhoneNumber = customerDetails.AlternatePhoneNumber;
            customerDetail.RegestationDate = DateTime.Now;
            return customerDetail;
        }
        private OrderDetail BuildOrdersData(OrderDetails orderDetail, Guid orderId)
        {
            OrderDetail orderDetails = new OrderDetail();

            orderDetails.OrderId = Guid.NewGuid().ToString();
            orderDetails.CustomerEmail = orderDetail.CustomerEmail;
            orderDetails.ProductName = orderDetail.ProductName;
            orderDetails.ProductSeller = orderDetail.ProductSeller;
            orderDetails.Location = orderDetail.Location;
            orderDetails.PinCode = orderDetail.PinCode.ToString();
            orderDetails.OrderPurchase = DateTime.Now;
            return orderDetails;
        }
    }
}
