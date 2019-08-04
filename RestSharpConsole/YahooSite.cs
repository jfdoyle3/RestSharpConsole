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
using QuickType;


namespace RestSharpConsole
{
   public class YahooSite
    {
        
        public static void YahooAPI()
        {

            Console.WriteLine("--> API Method <--");

            RestClient yahoo = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com");
            RestRequest request = new RestRequest("/market/get-summary?region=US&lang=en", Method.GET);
            request.AddHeader("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("X-RapidAPI-Key", "bd2f89ddc5mshaafba2c2850cce3p1e4c01jsna4733c78a5d4");
 

            IRestResponse restResponse = yahoo.Execute(request);

            dynamic  jStocks= JsonConvert.DeserializeObject(restResponse.Content);
            // var jStocks = JsonConvert.DeserializeObject(restResponse.Content);
            //String jStocksStr = jStocks.ToString();


           
            

      
            //ToFile(jStocks);


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