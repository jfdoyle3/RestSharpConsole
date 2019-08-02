using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace RestSharpConsole
{
    public class WorkingRSharp
    {
        public static void RSharpDemo()
        {
            RestClient restClient = new RestClient("http://ergast.com/api/f1");

            RestRequest restRequest = new RestRequest("2016/circuits.json", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            dynamic jsonResponse = JsonConvert.DeserializeObject(restResponse.Content);

            // dynamic jsonObject = jsonResponse.MRData.CircuitTable;
            //  int circuitId = (int)jsonObject.season;
            Console.WriteLine(jsonResponse);
        }
        public static void RSharpDemo2()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/");

            // navigate to /users
            RestRequest request = new RestRequest("/users", Method.GET);

            // execute the request
            IRestResponse response = client.Execute(request);
            string content = response.Content; // requested raw content available as string

            // Console.Write(content);

            // convert the string to an array of objects, could also convert this using fromObject
            object dataAsJsonObject = JsonConvert.DeserializeObject(content);

            // Console.Write(dataAsJsonObject);

            // parse the content into a jArray, an array of json
            JArray dataAsJArray = JArray.Parse(content);

            string dbConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Parsing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(dbConnString))
            {
                connection.Open();

                // convert the JArray of objects into separate JSON objects
                foreach (JToken user in dataAsJArray)
                {
                    // Console.Write(item);
                    // SQL Client Documentation on writing SQL commands in C#
                    SqlCommand insertStatement = new SqlCommand("INSERT into [User] (Id, name, username, email) VALUES (@id, @name, @username, @email)", connection);
                    insertStatement.Parameters.AddWithValue("@id", user["id"].ToObject<int>());
                    insertStatement.Parameters.AddWithValue("@name", user["name"].ToString());
                    insertStatement.Parameters.AddWithValue("@username", user["username"].ToString());
                    insertStatement.Parameters.AddWithValue("@email", user["email"].ToString());

                    // execute these above queries
                    insertStatement.ExecuteNonQuery();
                }

                Console.WriteLine("Database Updated");
                connection.Close();
            }
        }

    }
}