using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Services.Repository.EntityFramework.Models
{
    public partial class CustomerDetail
    {
        public CustomerDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string CustomerId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public DateTime RegestationDate { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
