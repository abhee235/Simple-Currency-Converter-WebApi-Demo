using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
using CurrencyConverter.Models;
using Newtonsoft.Json;
using System.Web.Http;

namespace CurrencyConverter.Controllers
{
    public class CurrencyController : ApiController
    {
         private readonly CurrencyConverterEntities curr = new CurrencyConverterEntities();

        // GET api/currency
        
        [HttpGet]
        public IEnumerable<Currency> FromCurrencyList()
        {

            var fromCurrencyList = curr.Currencies
               .Join(curr.CurrencyRates,
               u => u.CurrencyCode,
               p => p.FromCurrencyCode,
               (u, p) => new
               {
                   Name = u.Name,
                   CurrencyCode = u.CurrencyCode
               }).Distinct().ToList();


            List<Currency> currencyList = new List<Currency>();
            foreach (var item in fromCurrencyList)
            {
                currencyList.Add(new Currency
                {
                    Name = item.Name,
                    CurrencyCode = item.CurrencyCode
                });
            }

            return currencyList;
            //return new List<string>() { "string1", "string2" };
        }

        // GET api/currency/5
        [HttpGet]
        public IEnumerable<Currency> ToCurrencyList(int id)
        {

            var ToCurrencyList = curr.Currencies
                .Join(curr.CurrencyRates,
                u => u.CurrencyCode,
                p => p.ToCurrencyCode,
                (u, p) => new
                {
                    Name = u.Name,
                    CurrencyCode = u.CurrencyCode
                }).Distinct().ToList();

            List<Currency> tocurrencyList = new List<Currency>();
            foreach (var item in ToCurrencyList)
            {
                tocurrencyList.Add(new Currency
                {
                    Name = item.Name,
                    CurrencyCode = item.CurrencyCode
                });
            }

            return tocurrencyList;

        }

        [HttpGet]
        public decimal GetConversionRate(string fromcurrname, string tocurrname)
        {
            int rateid = curr.CurrencyRates
                       .Where(c => c.FromCurrencyCode == fromcurrname && c.ToCurrencyCode == tocurrname)
                       .OrderByDescending(o => o.ModifiedDate).FirstOrDefault().CurrencyRateID;

            return curr.CurrencyRates.Where(c => c.CurrencyRateID == rateid).FirstOrDefault().AverageRate;
        }

        // POST api/currency
        public void Post([FromBody]string value)
        {
        }

        // PUT api/currency/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/currency/5
        public void Delete(int id)
        {
        }
    }
}
