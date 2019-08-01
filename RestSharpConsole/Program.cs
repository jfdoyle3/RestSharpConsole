using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace RestSharpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var restClient = new RestClient("http://ergast.com/api/f1");

            var restRequest = new RestRequest("2016/circuits.json", Method.GET);

            var restResponse = restClient.Execute(restRequest);

            dynamic jsonResponse = JsonConvert.DeserializeObject(restResponse.Content);

            dynamic jsonObject = jsonResponse.MRData.CircuitTable;
            int circuitId = (int)jsonObject.season;
            System.Console.WriteLine(jsonObject);



        }
    }
}
