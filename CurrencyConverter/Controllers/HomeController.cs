using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurrencyConverter.ViewModel;
using CurrencyConverter.APICall;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    public class HomeController : Controller
    {
        CurrencyConverterEntities curr = new CurrencyConverterEntities();
        CurrencyClient client = new CurrencyClient();

       
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
           
            //getting this select list value form Currency client class
            var fromCurrencyList = CurrencyClient.GetFromCurrencyListAsync().Result;
            
            ViewBag.FromCurrencies = new SelectList(fromCurrencyList, "CurrencyCode", "Name");
           
           


            
            var ToCurrencyList = CurrencyClient.GetToCurrencyListAsync().Result;
           
            ViewBag.ToCurrencies = new SelectList(ToCurrencyList, "CurrencyCode", "Name");

            return View();
             
        }

        [HttpPost]
        public ActionResult Index(ConvertCurrencyViewModel cur)
        {
            if (ModelState.IsValid)
            {

                    string fromcurrname = cur.fromCurrency.Name;
                    string tocurrname = cur.toCurrency.Name;

                    //rate is taken by passing both dropdown currency code
                    decimal rate = CurrencyClient.GetConversionRate("Currency/GetConversionRate?fromcurrname=" + fromcurrname + "&tocurrname=" + tocurrname).Result;
                    ViewBag.result = cur.CurrencyToConvert * rate;

            }
                //getting this select list value form Currency client class
                var fromCurrencyList = CurrencyClient.GetFromCurrencyListAsync().Result;

                ViewBag.FromCurrencies = new SelectList(fromCurrencyList, "CurrencyCode", "Name");

                var ToCurrencyList = CurrencyClient.GetToCurrencyListAsync().Result;

                ViewBag.ToCurrencies = new SelectList(ToCurrencyList, "CurrencyCode", "Name");

                return View();
            
        }

    }
}
