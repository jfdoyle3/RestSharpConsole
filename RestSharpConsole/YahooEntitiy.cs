using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using unirest_net.http;
using RestSharp.Authenticators;
using System.IO;
using System.Data.Entity;



namespace RestSharpConsole
{
    public class YahooEntity
    {

        public static void YahooAPI_Entity()
        {
            Console.Write("Starting:\n Logging in: ");
            RestClient yahoo = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com");
            RestRequest request = new RestRequest("/market/get-summary?region=US&lang=en", Method.GET);
            request.AddHeader("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("X-RapidAPI-Key", "bd2f89ddc5mshaafba2c2850cce3p1e4c01jsna4733c78a5d4");
            Console.Write("Successful\n");
            IRestResponse restResponse = yahoo.Execute(request);

            dynamic jStocks = JsonConvert.DeserializeObject(restResponse.Content);


            JArray stockResult = jStocks["marketSummaryResponse"]["result"];

            Console.Write("Scraped Data:\n  Database: ");
            string method = "RS";

            List<string> restStocks = new List<string>();
            Console.WriteLine("Console Scrape:");
            for (int i = 0; i < stockResult.Count; i++)
            {
                restStocks.Add(DateTime.Now.ToString());
                restStocks.Add(stockResult[i]["symbol"].ToString());
                restStocks.Add(stockResult[i]["regularMarketChange"]["fmt"].ToString());
                restStocks.Add(stockResult[i]["regularMarketTime"]["fmt"].ToString());
                restStocks.Add(stockResult[i]["regularMarketChangePercent"]["fmt"].ToString());
                restStocks.Add(stockResult[i]["regularMarketPrice"]["fmt"].ToString());
                restStocks.Add(stockResult[i]["regularMarketPreviousClose"]["fmt"].ToString());
                restStocks.Add(method);
            }


            foreach (string items in restStocks)
                Console.WriteLine(items);

            Console.WriteLine("Writing to Database");
            using (RestStocksContext db = new RestStocksContext())
            {
                for (int i = 0; i < stockResult.Count; i++)
                {
                    RestStock stocks = new RestStock
                    {
                        TimeStamp = DateTime.Now.ToString(),
                        Symbol = stockResult[i]["symbol"].ToString(),
                        Change = stockResult[i]["regularMarketChange"]["fmt"].ToString(),
                        Time = stockResult[i]["regularMarketTime"]["fmt"].ToString(),
                        ChgPct = stockResult[i]["regularMarketChangePercent"]["fmt"].ToString(),
                        Price = stockResult[i]["regularMarketPrice"]["fmt"].ToString(),
                        Closing = stockResult[i]["regularMarketPreviousClose"]["fmt"].ToString(),
                        Method = method
                    };
                    db.RestStocks.Add(stocks);
                    db.SaveChanges();
                }
            }
            Console.WriteLine("Database Written and closed");
        }
    }
}
