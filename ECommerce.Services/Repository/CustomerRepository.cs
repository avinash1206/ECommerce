using ECommerce.Services.Exceptions;
using ECommerce.Services.Models;
using ECommerce.Services.Repository.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Repository
{
    public interface ICustomerRepository
    {
        Task<string> CreateCustomersData(CustomerDetail CustomerDetails);
        Task<string> CreateOrdersData(OrderDetail OrderDetails);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _transactionsContext;

        public CustomerRepository(CustomerContext transactionsContext)
        {
            _transactionsContext = transactionsContext;
        }
        public async Task<string> CreateCustomersData(CustomerDetail CustomerDetails)
        {
            string status = "Failed";
            using (var transaction = _transactionsContext.Database.BeginTransaction())
            {
                try
                {
                    _transactionsContext.CustomerDetails.Add(CustomerDetails);
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

        public async Task<string> CreateOrdersData(OrderDetail OrderDetails)
        {
            string status = "Failed";
            using (var transaction = _transactionsContext.Database.BeginTransaction())
            {
                try
                {
                    _transactionsContext.OrderDetails.Add(OrderDetails);
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
    }
}
