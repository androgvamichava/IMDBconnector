using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Model.ResponseModel
{
    public class Movie
    {
        public string Id { get; set; }
        public MovieImage Image { get; set; }
        public string Title { get; set; }
        public string TitleType { get; set; }
        public int Year { get; set; }
    }
}
