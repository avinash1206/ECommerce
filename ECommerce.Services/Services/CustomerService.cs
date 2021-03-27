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
        Task<string> CustomerDetails(List<CustomerDetails> customerDetails);
        Task<string> CreateorderDetails(List<OrderDetails> orderDetails);
        Task<List<OrderDetail>> GetOrderDeatails(string customerEmail);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<string> CreateorderDetails(List<OrderDetails> orderDetails)
        {
            var customerData = BuildOrdersData(orderDetails);
            string sucess = await _customerRepository.CreateOrdersData(customerData);
            return sucess;
        }

        public async Task<string> CustomerDetails(List<CustomerDetails> customerDetails)
        {
            var customerData = BuildCustomerData(customerDetails);
            string sucess = await _customerRepository.CreateCustomersData(customerData);
            return sucess;
        }
        public async Task<List<OrderDetail>> GetOrderDeatails(string customerEmail)
        {
            return await _customerRepository.GetOrderDeatails(customerEmail);
        }
        private List<CustomerDetail> BuildCustomerData(List<CustomerDetails> customerDetails)
        {
            List<CustomerDetail> customerDetail = new List<CustomerDetail>();
            foreach (var details in customerDetails)
            {

                CustomerDetail customerDetail1 = new CustomerDetail()
                {

                    CustomerId = Guid.NewGuid().ToString(),
                    CustomerEmail = details.CustomerEmail,
                    CustomerName = details.CustomerName,
                    Address = details.Address,
                    PhoneNumber = details.PhoneNumber,
                    AlternatePhoneNumber = details.AlternatePhoneNumber,
                    RegestationDate = DateTime.Now,
                };
                customerDetail.Add(customerDetail1);
            }
            return customerDetail;
        }
        private List<OrderDetail> BuildOrdersData(List<OrderDetails> orderDetail)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var orders in orderDetail)
            {
                OrderDetail details = new OrderDetail()
                {
                    OrderId = Guid.NewGuid().ToString(),
                    CustomerEmail = orders.CustomerEmail,
                    ProductName = orders.ProductName,
                    ProductSeller = orders.ProductSeller,
                    Location = orders.Location,
                    PinCode = orders.PinCode.ToString(),
                    OrderPurchase = DateTime.Now
                };
                orderDetails.Add(details);
            }
            return orderDetails;

        }
    }
}
