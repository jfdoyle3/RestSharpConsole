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



namespace RestSharpConsole
{
   public class YahooSite
    {

        public static void YahooAPI()
        {

            RestClient yahoo = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com");
            RestRequest request = new RestRequest("/market/get-summary?region=US&lang=en", Method.GET);
            request.AddHeader("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("X-RapidAPI-Key", "bd2f89ddc5mshaafba2c2850cce3p1e4c01jsna4733c78a5d4");

            IRestResponse restResponse = yahoo.Execute(request);

            dynamic jStocks = JsonConvert.DeserializeObject(restResponse.Content);

            // jStocks["marketSummaryResponse"]["result"][i]["regularMarketChange"]["fmt"]
            string format = "fmt";
            dynamic stockResult = jStocks["marketSummaryResponse"]["result"];
            dynamic symbol = stockResult[0]["symbol"];
            dynamic Change = stockResult[0]["regularMarketChange"][format];
            dynamic time = stockResult[0]["regularMarketTime"][format];
            dynamic ChgPercent = stockResult[0]["regularMarketChangePercent"][format];
            dynamic Price= stockResult[0]["regularMarketPrice"][format];
            dynamic Close = stockResult[0]["regularMarketPreviousClose"][format];


            // for (int i=0; i<15; i++)
            Console.WriteLine("Row: 1 {0} {1} {2} {3} {4} {5}",symbol,Change,time,ChgPercent,Price,Close);            

            
            ToFile(jStocks["marketSummaryResponse"]["result"][0]);


        }

        
        static void ToFile(dynamic input)
        {
            String time = DateTime.Now.TimeOfDay.ToString().Replace(":", "!").Remove(8);
            String folder = @"D:\repository\webScraper\dotNET\";
            String fileName = "Output_"+time+".txt";
            

            String file = folder + fileName;
            StreamWriter streamWriter = new StreamWriter(file);

            streamWriter.WriteLine(input);
            streamWriter.Close();
        }

    }
}