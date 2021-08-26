using SPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SPA.Helpers
{
    public static class CustomerHelper
    {
        public static string GenerateCustomerCode(Customer customer)
        {
            var str = new StringBuilder();
            str.Append(customer.FirstName.ToLower());
            str.Append(customer.LastName.ToLower());
            str.Append(customer.BirthDate.ToString("yyyyMMdd"));

            return str.ToString();
        }
    }
}