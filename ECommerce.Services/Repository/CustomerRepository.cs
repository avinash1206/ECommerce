using ECommerce.Services.Repository.EntityFramework;
using ECommerce.Services.Repository.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Repository
{
    public interface ICustomerRepository
    {
        Task<string> CreatePaymentData(CustomerDetail CustomerDetails);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _transactionsContext;

        public CustomerRepository(CustomerContext transactionsContext)
        {
            _transactionsContext = transactionsContext;
        }
        public async Task<string> CreatePaymentData(CustomerDetail CustomerDetails)
        {
            //bool status = false;
            using (var transaction = _transactionsContext.Database.BeginTransaction())
            {
                try
                {
                    _transactionsContext.CustomerDetails.Add(CustomerDetails);
                    await _transactionsContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    //status = true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    //throw new PaymentException(ex.Message);
                }
            }
            return "Sucess";
        }
    }
}
