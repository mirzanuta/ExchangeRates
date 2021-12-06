using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExchangeRates
{

    internal class CurrencyResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("timestamp")]
        public int TimeStamp { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("rates")]
        public Dictionary<string,double> Rates { get; set; }

        public string FormatForConsole()
        {  
            if(!Success)
            {
                return "No currency information available, please check your request";
            }
            
            string str = "Date: " + Date + "\n";
            foreach(var item in Rates)
            {
                str+=item.Key + ": " + item.Value + "\n";
            }
            return str; 
        }
    }
}
