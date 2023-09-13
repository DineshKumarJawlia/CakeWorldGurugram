using BOL;
using Microsoft.AspNetCore.Mvc;

namespace CakeWorldGurugram.Controllers
{
	public class InventoryController : Controller
	{
		[HttpGet]
		public IActionResult AddProduct()
		{
			return View("~/Views/Event/AddInventory.cshtml");
		}

		[HttpPost]
		public IActionResult AddProduct(CakeDisplayViewModel cake, IFormFile file)
		{

			string path = "./wwwroot/ProductImages/" + cake.Image;
			IFormFile File;

			using (var stream = System.IO.File.OpenRead(path))
			{
				File = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
			}

			BAL.BAL bAL = new BAL.BAL();

			//if(string.IsNullOrEmpty(cake.Image))
			//{
			//	byte[] image = cake.Image;
			//	cake.Image = Convert.ToBase64String(cake.Image);
			//}

			string status = bAL.AddInventory(cake);

			if(status == "0")
			{
				cake.IsSuccess = true;
				cake.Message = "Product Addeed Successfully !";
			}
			else if(status.ToLower().Contains("please"))
			{
				cake.IsSuccess = true;
				cake.Message = status;
			}
			else
			{
				cake.IsSuccess = true;
				cake.Message = "Product Addition Failed !!";
			}

			return View("~/Views/Event/AddInventory.cshtml", cake);
		}
	}
}
