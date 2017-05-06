using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using CurrencyConverter.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace CurrencyConverter.APICall
{
    public class CurrencyClient
    {

        private static HttpClient client; 

        //static async Task RunAsync()
        //{
        //    // New code:
        //    client.BaseAddress = new Uri("http://localhost:62029/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //}

        public CurrencyClient()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:62029/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
          
        }
       

        //this method is used for taking dropdown element for from dropdwn 
        public static async Task<IEnumerable<Currency>> GetFromCurrencyListAsync()
        {
            
            List<Currency> fromCurrencyList = new List<Currency>();
            HttpResponseMessage response =  client.GetAsync("Currency").Result;
            if (response.IsSuccessStatusCode)
            {
                    var resposeData = response.Content.ReadAsStringAsync().Result;
                    fromCurrencyList = JsonConvert.DeserializeObject<List<Currency>>(resposeData);
            }

            return fromCurrencyList;
            // JavaScriptSerializer()
        }


        //this method is used for taking dropdown element for TO dropdwn 
        public static async Task<List<Currency>> GetToCurrencyListAsync()
        {
            
       
            List<Currency> toCurrencyList = new List<Currency>();
            HttpResponseMessage response =  client.GetAsync("Currency/1").Result;
           // response.EnsureSuccessStatusCode(); 
            if (response.IsSuccessStatusCode)
            {
                var resposeData = response.Content.ReadAsStringAsync().Result;
                toCurrencyList = JsonConvert.DeserializeObject<List<Currency>>(resposeData);
            }

            return toCurrencyList;
        }

        //this method is used for taking conversion rate based on both dropdown
        public static async Task<decimal> GetConversionRate(string path)
        {
            decimal converstionRate = new decimal();

            HttpResponseMessage response =  client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var resposeData = response.Content.ReadAsStringAsync().Result;
                converstionRate = JsonConvert.DeserializeObject<decimal>(resposeData);
            }

            return converstionRate;
        }
    }
}