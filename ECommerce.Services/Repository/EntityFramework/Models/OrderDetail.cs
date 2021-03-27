using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Services.Repository.EntityFramework.Models
{
    public partial class OrderDetail
    {
        public string OrderId { get; set; }
        public string CustomerEmail { get; set; }
        public string ProductName { get; set; }
        public string ProductSeller { get; set; }
        public string Location { get; set; }
        public string PinCode { get; set; }
        public DateTime OrderPurchase { get; set; }

        public virtual CustomerDetail CustomerEmailNavigation { get; set; }
    }
}
