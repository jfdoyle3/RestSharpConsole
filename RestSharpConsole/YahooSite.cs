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
            String jStocksStr = jStocks.ToString();

            var welcome = QuickType.Welcome.FromJson(jStocksStr);

           // Console.WriteLine(jStocks);
            Console.WriteLine(welcome);

           // ToFile(jStocks);


        }

        public static void YahooLogin()
        {
            Console.WriteLine("--> Login Authorized Method <--");
            string userName = "jfdoyle_iii";
            string password = "m93Fe8YHn";
            var restClient = new RestClient("https://finance.yahoo.com/portfolio/p_2/view/v1")
            {
                Authenticator = new HttpBasicAuthenticator(userName, password)
            };
            //RestRequest request = new RestRequest("https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-summary?region=US&lang=en", Method.GET);
            //request.AddHeader("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            //request.AddHeader("X-RapidAPI-Key", "bd2f89ddc5mshaafba2c2850cce3p1e4c01jsna4733c78a5d4");
            
    

        }
        static void ToFile(dynamic input)
        {
            
            String Folder = @"D:\repository\webScraper\dotNET\";
            String FileName = "Output.txt";

            String file = Folder + FileName;
            StreamWriter streamWriter = new StreamWriter(file);

            streamWriter.WriteLine(input);
            streamWriter.Close();
        }

    }
}