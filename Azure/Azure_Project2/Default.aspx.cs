using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNext_Click(object sender, EventArgs e)
    {

        /*        
            try
            {
               String connectionStr = "Server=tcp:azureproject2.database.windows.net,1433;Initial Catalog=PhotoAlbum;Persist Security Info=False;User ID=tushargarud;Password=password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
               System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionStr);
               conn.Open();
               string checkuser = "select count(*) from dbo.Photos;";
               System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(checkuser, conn);
               int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
               conn.Close();             
           }
           catch (Exception ex)
           {
               ex.Message.ToString();
           }   */

        if (txtUserName.Text.Length != 0)
            Response.Redirect("Upload.aspx?UserName=" + txtUserName.Text);
    }
}