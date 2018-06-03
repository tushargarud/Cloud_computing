using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
        }
        catch(Exception ex)
        {
            ex.InnerException.ToString();
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlConnection conn;
        try
        {
            String connectionStr = "Server = tcp:cse6331project2sqlserver.database.windows.net,1433; Initial Catalog = CSE6331_Project2; Persist Security Info = False; User ID = abhidhotre91; Password = Password!23; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            conn = new SqlConnection(connectionStr);
            conn.Open();
            string checkuser = "select count(*) from dbo.Photos where UserId = '" + txtUserId.Text + "'";
            SqlCommand cmd = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            //if (temp == 0)
            //{
                conn.Close();
                Response.Redirect("Page2.aspx?UserId=" + txtUserId.Text);
            //}

            
        }
        catch (Exception)
        {
            
        }
        
    }
}