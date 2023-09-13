using BAL;
using BOL;
using Microsoft.AspNetCore.Mvc;

namespace CakeWorldGurugram.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetCategory(string categoryName)
		{
			string view = string.Empty;
			CakeViewModel model = new CakeViewModel();

			if (!string.IsNullOrEmpty(categoryName))
			{
				model = GetDataByCategory(categoryName);
				view = "~/Views/Event/CakeDetailsPage.cshtml";
			}
			else
			{
				model = null;
				view = "~/Views/Home/Index.cshtml";
			}

			return View(view, model);
		}

        public CakeViewModel GetDataByCategory(string CakeCategory) 
        {
			BAL.BAL bAL = new BAL.BAL();
			CakeViewModel cakeViewModel = new CakeViewModel();
			cakeViewModel.CakeDetailsPage = bAL.loadCakeData(CakeCategory);

            return cakeViewModel;
        }
    }
}
