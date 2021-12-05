
using ExchangeRates;

var apiclient = new CurrencyApiClient();
string[] arr = { "AMD", "USD", "RUB" };

var currResponse = apiclient.GetLatestRates(arr);

Console.WriteLine(currResponse?.ToString());

var dt = "2021-11-30";
currResponse = apiclient.GetRatesByDate(dt, arr);
Console.WriteLine(currResponse?.ToString());

string[] arr1 = {};
currResponse = apiclient.GetLatestRates(arr1);
Console.WriteLine(currResponse?.ToString());