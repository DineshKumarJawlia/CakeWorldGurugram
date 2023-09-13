using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DAL
{
    public class DAL
    {
		private SqlConnection getConnectionString()
		{
			var appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
			string Constring = appConfig.ConnectionStrings.ConnectionStrings["D2PRODBConn"].ToString();
			SqlConnection sqlConnString = new SqlConnection(Constring);
			return sqlConnString;
		}
		public DataTable executeSQLQuery(SqlCommand cmd, List<SqlParameter> parmList)
		{
			//call the SQLConnection Method -con string
			DataTable DT = new DataTable();
			using (SqlConnection sqlcon = getConnectionString())
			{
				using (SqlCommand Command = new SqlCommand(cmd.CommandText, sqlcon))
				{
					sqlcon.Open();
					Command.CommandType = cmd.CommandType;
					foreach (SqlParameter Pr in parmList)
					{
						Command.Parameters.Add(Pr);
					}
					using (var Obj = Command.ExecuteReader())
					{
						DT.Load(Obj);
						sqlcon.Close();
						return DT;
					}
				}
			}
		}
	}
}