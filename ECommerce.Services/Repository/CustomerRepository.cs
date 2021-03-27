using ECommerce.Services.Exceptions;
using ECommerce.Services.Models;
using ECommerce.Services.Repository.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Repository
{
    public interface ICustomerRepository
    {
        Task<string> CreateCustomersData(List<CustomerDetail> CustomerDetails);
        Task<string> CreateOrdersData(List<OrderDetail> OrderDetails);
        Task<List<OrderDetail>> GetOrderDeatails(string customerEmail);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _transactionsContext;

        public CustomerRepository(CustomerContext transactionsContext)
        {
            _transactionsContext = transactionsContext;
        }
        public async Task<string> CreateCustomersData(List<CustomerDetail> CustomerDetails)
        {
            string status = "Failed";
            using (var transaction = _transactionsContext.Database.BeginTransaction())
            {
                try
                {
                    await _transactionsContext.CustomerDetails.AddRangeAsync(CustomerDetails);
                    await _transactionsContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    status = "Sucess";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new CustomersException(ex.Message);
                }
            }
            return status;
        }

        public async Task<string> CreateOrdersData(List<OrderDetail> OrderDetails)
        {
            string status = "Failed";
            using (var transaction = _transactionsContext.Database.BeginTransaction())
            {
                try
                {
                   await _transactionsContext.OrderDetails.AddRangeAsync(OrderDetails);
                    await _transactionsContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    status = "Sucess";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new CustomersException(ex.Message);
                }
            }
            return status;
        }
        public async Task<List<OrderDetail>> GetOrderDeatails(string customerEmail)
        {
            return _transactionsContext.OrderDetails.Where(x => x.CustomerEmail.ToLower() == customerEmail.ToLower()).ToList();
        }
    }
}
