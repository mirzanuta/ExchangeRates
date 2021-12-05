using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
    internal class CurrencyResponse
    {
        public bool success { get; set; }
        public int timestamp { get; set; }
        public string @base { get; set; }
        public string date { get; set; }
        public Dictionary<string,double> rates { get; set; }

        public override string ToString()
        {
            string str = "Date: " + date + "\n";
            foreach(var item in rates)
            {
                str+=item.Key + ": " + item.Value + "\n";
            }
            return str; 
        }
    }
}
