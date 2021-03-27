using ECommerce.Services.Constants;
using ECommerce.Services.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Services.Models
{
    public class CustomerDetails
    {
        [Required(ErrorMessage = LogMessages.Required)]
        [StringLength(100, ErrorMessage =LogMessages.InvalidEmail)]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = LogMessages.Required)]
        [StringLength(100, ErrorMessage = LogMessages.InvalidName)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = LogMessages.Required)]
        public string Address { get; set; }

        [Required(ErrorMessage = LogMessages.Required)]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[0-9]{3}[0-9]{4,6}$", ErrorMessage = LogMessages.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[0-9]{3}[0-9]{4,6}$", ErrorMessage = LogMessages.InvalidPhoneNumber)]
        public string AlternatePhoneNumber { get; set; }

        [Required(ErrorMessage = LogMessages.Required)]
        [DateTime(ErrorMessage =LogMessages.RegistrationDate)]
        public DateTime RegestationDate { get; set; }

        //public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
