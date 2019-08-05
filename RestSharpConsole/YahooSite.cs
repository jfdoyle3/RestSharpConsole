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
            Console.WriteLine("Start");
            RestClient yahoo = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com");
            RestRequest request = new RestRequest("/market/get-summary?region=US&lang=en", Method.GET);
            request.AddHeader("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("X-RapidAPI-Key", "bd2f89ddc5mshaafba2c2850cce3p1e4c01jsna4733c78a5d4");

            Console.WriteLine("API successful");

            IRestResponse restResponse = yahoo.Execute(request);

          dynamic jStocks = JsonConvert.DeserializeObject(restResponse.Content);

            //foreach (JToken item in jStocks)
            //    Console.WriteLine(item["symbol"].ToString());


            //string StrStocks = jStocks.ToString();

            //dynamic blogPosts = JArray.Parse(StrStocks);

            //dynamic blogPost = blogPosts[0];

            //dynamic title = blogPost.Title;


            string format = "fmt";
            dynamic stockResult = jStocks["marketSummaryResponse"]["result"];
            string type = "RS";

            Console.WriteLine("        Symbol    | Change |     Time     |   Chg%   |   Price    | Close");
            Console.WriteLine("------------------┼-----------┼--------------┼----------┼------------┼-----------");
            for (int row = 0; row < 15; row++)
            {
                string timeStamp = DateTime.Now.ToString();
                dynamic symbol = stockResult[row]["symbol"];
                dynamic change = stockResult[row]["regularMarketChange"][format];
                dynamic time = stockResult[row]["regularMarketTime"][format];
                dynamic chgPct = stockResult[row]["regularMarketChangePercent"][format];
                dynamic price = stockResult[row]["regularMarketPrice"][format];
                dynamic close = stockResult[row]["regularMarketPreviousClose"][format];
                string method = type;
                 Console.WriteLine("Row: {0}  {1}   {2}  {3}     {4}    {5}   {6}", row, symbol, change, time, chgPct, price, close);
            }



            // // HAL900
            // string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestSharp;Integrated Security=True";



            // string[] fields = { "@TimeStamp", "@Symbol", "@Change", "@Time", "@ChgPct", "@Price", "@Closing", "@Method" };


            // using (SqlConnection connection = new SqlConnection(connectionString))
            // {

            //     String query = "INSERT INTO Stocks (TimeStamp,Symbol,Change,Time,ChgPct,Price,Close,Method) VALUES (@TimeStamp,@Symbol,@Change,@Time,@ChgPct,@Currency,@Price,@Closing,@Method)";


            //     using (SqlCommand command = new SqlCommand(query, connection))
            //     {

            //         for (int row = 0; row < 15; row++)
            //         {
            //             string timeStamp = DateTime.Now.ToString();
            //             dynamic symbol = stockResult[row]["symbol"];
            //             dynamic change = stockResult[row]["regularMarketChange"][format];
            //             dynamic time = stockResult[row]["regularMarketTime"][format];
            //             dynamic chgPct = stockResult[row]["regularMarketChangePercent"][format];
            //             dynamic price = stockResult[row]["regularMarketPrice"][format];
            //             dynamic closing = stockResult[row]["regularMarketPreviousClose"][format];
            //             string method = type;
            //              Console.WriteLine("Row: {0}  {1}   {2}  {3}     {4}    {5}   {6}", row, symbol, change, time, chgPct, price, closing);

            //             command.Parameters.AddWithValue("@TimeStamp", timeStamp);
            //             command.Parameters.AddWithValue("@Symbol", symbol);
            //             command.Parameters.AddWithValue("@Time", time);
            //             command.Parameters.AddWithValue("@ChgPct", chgPct);
            //             command.Parameters.AddWithValue("@Price", price);
            //             command.Parameters.AddWithValue("@Closing", closing);
            //             command.Parameters.AddWithValue("@Method", method);

            //         }


            //         connection.Open();
            //         Console.WriteLine("DB Opened");
            //         int result = command.ExecuteNonQuery();
            //         // Check Error
            //         if (result < 0)
            //             Console.WriteLine("Error inserting data into Database!");
            //     }
            //     connection.Close();
            // }
            // Console.WriteLine("Database Closed");

        }
    }
}