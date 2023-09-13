using BOL;
using System.Data;
using System.Reflection;

namespace BAL
{
	public class BAL
	{
		private object getCakeConn()
        {
			CAKEDATA.CAKEDATA obj = new CAKEDATA.CAKEDATA();	
            return obj;
        }
		public List<CakeDisplayViewModel> loadCakeData(string CakeCategory)
		{
			List<CakeDisplayViewModel> cakes = new List<CakeDisplayViewModel>();
			CAKEDATA.CAKEDATA cD = (CAKEDATA.CAKEDATA)getCakeConn();
			DataTable dt = cD.loadCakeDetails(CakeCategory);

			if (dt != null)
			{
				if (dt.Rows.Count > 0)
				{
					dt.AsEnumerable().ToList<DataRow>().ForEach(dr => cakes.Add(
					new CakeDisplayViewModel
					{
						ProductName = dr["ProductName"].ToString(),
						Rating = dr["Rating"].ToString(),
						Description = dr["Description"].ToString(),
						//Image = dr["Image"].ToString(),
						Weight = dr["Weight"].ToString(),
						Weight1 = dr["Weight1"].ToString(),
						Weight2 = dr["Weight2"].ToString(),
						Price = dr["Price"].ToString(),
						Price1 = dr["Price1"].ToString(),
						Price2 = dr["Price2"].ToString()
					}
				  ));
				}
				else
				{
					dt.AsEnumerable().ToList<DataRow>().ForEach(dr => cakes.Add(
					new CakeDisplayViewModel
					{
						ProductName = "",
						Rating = "",
						Description = "",
						//Image = "",
						Weight = "",
						Weight1 = "",
						Weight2 = "",
						Price = "",
						Price1 = "",
						Price2 = ""
					}
				));
				}
			}
			else 
			{
				
			}
			return cakes;
		}
		public string AddInventory(CakeDisplayViewModel cakeDisplayViewModel)
		{
			try
			{
				string status = string.Empty;
				CAKEDATA.CAKEDATA cD = (CAKEDATA.CAKEDATA)getCakeConn();

				string validCheck = ValidateData(cakeDisplayViewModel);

				if(validCheck == "0")
				{
					status = cD.InsertProduct(cakeDisplayViewModel);
				}
				else
				{
					status = validCheck;
				}
				return status;
			}
			catch (Exception)
			{
				return null;
			}
		}
		public string ValidateData(CakeDisplayViewModel cake)
		{
			if (string.IsNullOrEmpty(cake.ProductName))
			{
				return "Please enter Product Name";
			}
			if (string.IsNullOrEmpty(cake.Description))
			{
				return "Please enter Product Description";
			}
			//if (string.IsNullOrEmpty(cake.Image))
			//{
			//	return "Please upload Product Image";
			//}
			if (string.IsNullOrEmpty(cake.Category) || cake.Category == "0")
			{
				return "Please select Product Category";
			}
			if (string.IsNullOrEmpty(cake.Weight) || cake.Weight == "0")
			{
				return "Please select Product Weight";
			}
			if (string.IsNullOrEmpty(cake.Price) || cake.Price == "0")
			{
				return "Please select Product Price";
			}

			return "0";
		}
	}
}