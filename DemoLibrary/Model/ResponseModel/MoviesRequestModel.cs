using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Model.ResponseModel
{
    public class MoviesRequestModel
    {
        public int PaginationKey { get; set; }
        public int TotalMatches { get; set; }
        public List<Movie> Results { get; set; }
    }
}
