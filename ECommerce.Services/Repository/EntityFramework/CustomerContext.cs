using ECommerce.Services.Repository.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Services.Repository.EntityFramework
{
    public partial class CustomerContext : DbContext
    {

        public CustomerContext()
        {
        }

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }
    }
}
