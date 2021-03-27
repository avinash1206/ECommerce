using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Services.CustomValidators
{
    public class DateTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime Date = (DateTime)value;

            if (Date > DateTime.MinValue)
            {
                return true;
            }

            return false;
        }
    }
}
