using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata.Ecma335;

namespace BOL
{
    public class CakeViewModel
    {
        public CakeViewModel()
        {
            CakeDetailsPage = new List<CakeDisplayViewModel>();
        }
        public List<CakeDisplayViewModel> CakeDetailsPage { get; set; }
    }
    public class CakeDisplayViewModel
    {
        public string ProductName { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
		public string Image { get; set; }
        public string Weight { get; set; }
        public string Price { get; set; }
        public string Weight1 { get; set; }
        public string Price1 { get; set; }
        public string? Weight2 { get; set; }
        public string? Price2 { get; set; }
        public string Category { get; set; }
        // Response
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
	}
    public class DataResponce
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}