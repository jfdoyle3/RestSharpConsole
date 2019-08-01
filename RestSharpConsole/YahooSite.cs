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

namespace RestSharpConsole
{
    class YahooSite
    {
        public static void YahooStocks()
        {
            HttpResponse<MyClass.RootObject> response = Unirest.get("https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-summary?region=US&lang=en")
                                                          .header("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com")
                                                          .header("X-RapidAPI-Key", "bd2f89ddc5mshaafba2c2850cce3p1e4c01jsna4733c78a5d4")
                                                          .asJson<MyClass.RootObject>();
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.ToString());

            Console.WriteLine(jsonResponse);

            //RestClient restClient = new RestClient("http://ergast.com/api/f1");

            //RestRequest restRequest = new RestRequest("2016/circuits.json", Method.GET);

            //IRestResponse restResponse = restClient.Execute(restRequest);

            //dynamic jsonResponse = JsonConvert.DeserializeObject(restResponse.Content);

            //// dynamic jsonObject = jsonResponse.MRData.CircuitTable;
            ////  int circuitId = (int)jsonObject.season;
            //
        }
        internal class MyClass
        {
            public class Result
            {
                public string name { get; set; }
                public string score { get; set; }
                public string url { get; set; }
                public string rlsdate { get; set; }
                public string rating { get; set; }
                public string summary { get; set; }
                public string platform { get; set; }
            }

            public class RootObject
            {
                public List<Result> results { get; set; }
            }
        }
    }
}
