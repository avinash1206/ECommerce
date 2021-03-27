﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Services.Models
{
   public class OrderDetails
    {
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductSeller { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int PinCode { get; set; }
        [Required]
        public DateTime OrderPurchase { get; set; }

        //[ForeignKey("CustomerEmail")]
        //public virtual CustomerDetail CustomerDetail { get; set; }
        //public virtual CustomerDetail CustomerDetail { get; set; }
    }
}
