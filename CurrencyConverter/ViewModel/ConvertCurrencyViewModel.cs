using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurrencyConverter.Models;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.ViewModel
{
    public class ConvertCurrencyViewModel
    {
         [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter amount to convert")]
        public decimal CurrencyToConvert { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select country Name")]
        public Currency fromCurrency { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select country Name")]
        public Currency toCurrency { get; set; }
        
        public double ConvertedCurrency { get; set; }
    }
}