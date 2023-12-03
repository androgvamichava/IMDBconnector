using System.Net.Http.Headers;

namespace DemoLibrary
{
    public class ApiHelper
    {
        // aspsettings parameters
        public static string Baseurl = "https://online-movie-database.p.rapidapi.com/title/v2/";
        public static string Key = "c6b5ac88f7msh192c3d2e63a0e92p17799djsn375994122d42";

        public static HttpClient ApiClient { get; set; }
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", Key);
            ApiClient.BaseAddress = new Uri(Baseurl);


            Console.WriteLine("Api Client has been initialized...");



        }
    }
}
