using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;

namespace CloudAssignment4
{
    public partial class Visualization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable allData = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["MyWebAppDatabase"].ConnectionString;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string sql = "SELECT * FROM dbo.StateVotingClean";
            SqlCommand cmd = new SqlCommand(sql, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(allData);

            DataGrid1.DataSource = allData;
            DataGrid1.DataBind();

            connection.Close();
        }

        [System.Web.Services.WebMethod]
        public static string GetData()
        {
            DataTable allData = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["MyWebAppDatabase"].ConnectionString;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string sql = "SELECT * FROM dbo.StateVotingClean";
            SqlCommand cmd = new SqlCommand(sql, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(allData);

            connection.Close();

            JavaScriptSerializer serializer = new JavaScriptSerializer(new SimpleTypeResolver());
            return serializer.Serialize(allData);
        }

    }
}