using Newtonsoft.Json.Linq;

namespace RestSharpConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            JArray rsStocks = RSYahooAPI.YahooApiScrape();
            SQLWrite.WriteDB(rsStocks);

        }
    }
}
