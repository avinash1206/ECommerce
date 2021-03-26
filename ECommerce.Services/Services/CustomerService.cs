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
        Task<string> CustomerDetails(CustomerDetail customerDetails);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<string> CustomerDetails(CustomerDetail customerDetails)
        {
            Guid customerId = Guid.NewGuid();
            var customerData = BuildCustomerData(customerDetails, customerId);
            string sucess= await _customerRepository.CreatePaymentData(customerData);
            return sucess;
        }
        private CustomerDetail BuildCustomerData(CustomerDetail customerDetails, Guid customerId)
        {
            CustomerDetail customerDetail = new CustomerDetail();

            customerDetail.CustomerId = customerId;
            customerDetail.CustomerEmail = customerDetails.CustomerEmail;
            customerDetail.CustomerName = customerDetails.CustomerName;
            customerDetail.Address = customerDetails.Address;
            customerDetail.PhoneNumber = customerDetails.PhoneNumber;
            customerDetail.AlternatePhoneNumber = customerDetails.AlternatePhoneNumber;
            customerDetail.RegestationDate = DateTime.Now;
            return customerDetail;
        }
    }
}
