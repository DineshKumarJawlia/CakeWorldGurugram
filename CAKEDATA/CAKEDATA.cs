using BOL;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace CAKEDATA
{
	public class CAKEDATA
	{
		private object DALCon()
		{
			DAL.DAL obj = new DAL.DAL();
			return obj;
		}
		public DataTable loadCakeDetails(string CakeCategory)
		{
			try
			{
				DAL.DAL dalConnection = (DAL.DAL)DALCon();
				DataTable loadOrders = new DataTable();
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "usp_GetCategoryWiseDetails";

				List<SqlParameter> sqlParameters = new List<SqlParameter>();
				sqlParameters.Add(new SqlParameter("@CakeCategory", CakeCategory));
				sqlParameters.Add(new SqlParameter("@QUERYTYPE", "GET_CAKEDETAILS_BY_CATEGORY"));

				loadOrders = dalConnection.executeSQLQuery(cmd, sqlParameters);
				return loadOrders;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		public string InsertProduct(CakeDisplayViewModel cake)
		{
			try
			{
				DAL.DAL dalConnection = (DAL.DAL)DALCon();
				DataTable loadOrders = new DataTable();
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "usp_UploadProduct";

				List<SqlParameter> sqlParameters = new List<SqlParameter>();
				sqlParameters.Add(new SqlParameter("@ProductName", cake.ProductName));
				sqlParameters.Add(new SqlParameter("@Description", cake.Description));
				sqlParameters.Add(new SqlParameter("@Price", cake.Price));
				sqlParameters.Add(new SqlParameter("@Price1", cake.Price1));
				sqlParameters.Add(new SqlParameter("@Price2", cake.Price2));
				sqlParameters.Add(new SqlParameter("@Weight", cake.Weight));
				sqlParameters.Add(new SqlParameter("@Weight1", cake.Weight1));
				sqlParameters.Add(new SqlParameter("@Weight2", cake.Weight2));
				sqlParameters.Add(new SqlParameter("@Category", cake.Category));
				sqlParameters.Add(new SqlParameter("@Image", cake.Image));
				sqlParameters.Add(new SqlParameter("@QUERYTYPE", "INSERT_PRODUCT"));

				loadOrders = dalConnection.executeSQLQuery(cmd, sqlParameters);
				if (loadOrders.Rows.Count > 0)
					return "0";
				else
					return "1";
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}