using DemoLibrary;
using DemoLibrary.Model.ResponseModel;

namespace ImdbCall
{
    internal static class IMDBconnectior
    {
        internal static List<Movie> movies = new();
        public static void Start()
        {
            ApiHelper.InitializeClient();
        }

        public async static void GetData()
        {
            Processor processor = new();
            movies = await processor.LoadFullData();

            PrintMovies();
            PrintYears();
        }

        private static void PrintMovies()
        {
            foreach (var item in movies.OrderByDescending(x => x.Year))
            {
                Console.WriteLine(String.Format("Year: {0}, Title: {1} ", item.Year, item.Title));
            }
        }

        private static void PrintYears()
        {
            List<int> years = movies
                .Select(x => x.Year)
                .Distinct()
                .OrderByDescending(o => o)
                .ToList();

            Console.WriteLine("Found years:");
            Console.WriteLine(String.Join(", ", years));
        }
    }
}
