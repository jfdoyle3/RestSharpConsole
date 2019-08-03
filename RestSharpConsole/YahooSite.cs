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

namespace RestSharpConsole
{
    class YahooSite
    {
        public static void YahooAPI()
        {
            Console.WriteLine("--> API Method <--");
            //HttpResponse<Yahoo> response = Unirest.get("https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-summary?region=US&lang=en")
            //                                               .header("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com")
            //                                               .header("X-RapidAPI-Key", "bd2f89ddc5mshaafba2c2850cce3p1e4c01jsna4733c78a5d4");

            RestRequest request = new RestRequest("https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-summary?region=US&lang=en", Method.GET);
            request.AddHeader("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("X-RapidAPI-Key", "bd2f89ddc5mshaafba2c2850cce3p1e4c01jsna4733c78a5d4");
            request.RequestFormat = DataFormat.Json;

            //Console.WriteLine(request.RequestFormat.ToString);
            Console.WriteLine();

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
        }
    }
}
