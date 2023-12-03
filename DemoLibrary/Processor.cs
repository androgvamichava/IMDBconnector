using DemoLibrary.Model.ResponseModel;

namespace DemoLibrary
{
    public class Processor
    {
        public static List<Movie> MoviesList { get; set; } = new();
        public int PageLimit { get; set; } = 5;
        public int RequestPerSecondMaxCount { get; set; } = 5;

        public async Task<MoviesRequestModel> LoadData()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync("find?title=game&limit=100&paginationKey=0&sortArg=moviemeter%2Casc"))
            {
                if (response.IsSuccessStatusCode)
                {
                    MoviesRequestModel model = await response.Content.ReadAsAsync<MoviesRequestModel>();
                    return model;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<Movie>> LoadFullData()
        {
            ProcessStarted();
            int counterMilliseconds = 1000 / RequestPerSecondMaxCount + 1; 
            int counter = 0;
            var periodicTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(counterMilliseconds));
            while (await periodicTimer.WaitForNextTickAsync())
            {
                MoviesRequestModel data = await LoadData();
                List<Movie> portion = data.Results != null ? data.Results : new();
                MoviesList.AddRange(portion);
                counter++;

                InProgress();
                if (counter == PageLimit)
                {
                    Finished();
                    break;
                }
            }
            return MoviesList;
        }

        #region Helpers
        private void ProcessStarted()
        {
            Console.WriteLine("Recieving data now...");
        }

        private void InProgress()
        {
            Console.WriteLine(String.Format("Items count: {0}", MoviesList.Count));
        } 
        
        private void Finished()
        {
            Console.WriteLine(String.Format("Data is recieved! Count: {0} ", MoviesList.Count));
        }
        #endregion
    }
}