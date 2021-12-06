using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
    internal class CurrencyApiClient
    {
        private readonly string key = "b013530ae839ca6807ae7d3d17059372";
        private const string URL = "http://data.fixer.io/api/";

        private string BuildUrl(string date, string[] currencies)
        {
            var builder = new UriBuilder(URL + date)
            {
                Port = -1
            };
            var query = System.Web.HttpUtility.ParseQueryString(builder.Query);
            query["access_key"] = key;

            if (currencies != null && currencies.Length > 0)
            {
                query["symbols"] = String.Join(",", currencies);
            }

            builder.Query = query.ToString();

            return builder.ToString();

        }
        private HttpClient GetHttpClient(string date, string[] currencies)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BuildUrl(date, currencies));

            return client;
        }
        private CurrencyResponse? GetRates(string date, string[] currencies)
        {
            using (HttpClient client = GetHttpClient(date, currencies))
            {

                HttpResponseMessage response = client.GetAsync("").Result;

                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.

                    return response.Content.ReadAsAsync<CurrencyResponse>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }
        }

        public CurrencyResponse? GetLatestRates(string[] currencies) => GetRates("latest", currencies);
        public CurrencyResponse? GetRatesByDate(string date ,string[] currencies)=> GetRates(date, currencies);
    }
}
