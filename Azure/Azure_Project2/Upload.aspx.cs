using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        welcomeText.Text = "Hello " + Request.QueryString["UserName"];

        if (!this.IsPostBack)
        {
            this.BindRepeater();
        }

        string connectionStr = "Server=tcp:azureproject2.database.windows.net,1433;Initial Catalog=PhotoAlbum;Persist Security Info=False;User ID=tushargarud;Password=password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection conn = new SqlConnection(connectionStr);
        conn.Open();
        string checkuser = "SELECT photo FROM dbo.Photos where photoId=12";
        SqlCommand cmd = new SqlCommand(checkuser, conn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //int temp = Convert.ToBase64String(cmd.ExecuteScalar().ToString());
        DataTable dt = new DataTable();
        sda.Fill(dt);

        foreach (DataRow dr in dt.Rows)
        {
            if (dr["photo"] != null)
            {
                byte[] bytes = (byte[])dr["photo"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                catImage.ImageUrl = "data:image/png;base64," + base64String;
            }
        }

        conn.Close();

     //   byte[] bytes = (byte[])dr["photo"];
     //   string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
     //   dr["photoContent"] = "data:image/png;base64," + base64String;


    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string userName = Request.QueryString["UserName"];

            string imageName = txtPhotoTitle.Text;
            if(imageName.Length==0)
                imageName = Path.GetFileName(fudUploadPhoto.PostedFile.FileName);

            Stream fileInputStream = fudUploadPhoto.PostedFile.InputStream;
            BinaryReader fileBinaryReader = new BinaryReader(fileInputStream);
            byte[] byteArr = fileBinaryReader.ReadBytes((Int32)fileInputStream.Length);

            fileBinaryReader.Close();
            fileInputStream.Close();

            string queryStr = "insert into dbo.Photos values (@UserName, @photoTitle, @timestamp, @numberOfLikes, @numberOfPeople, @photo)";
            SqlCommand command = new SqlCommand(queryStr);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@photoTitle", imageName);
            command.Parameters.AddWithValue("@timestamp", DateTime.Now.ToString());
            command.Parameters.AddWithValue("@numberOfLikes", 0);
            command.Parameters.AddWithValue("@numberOfPeople", 0);
            command.Parameters.AddWithValue("@photo", byteArr);

            String connectionStr = "Server=tcp:azureproject2.database.windows.net,1433;Initial Catalog=PhotoAlbum;Persist Security Info=False;User ID=tushargarud;Password=password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionStr);

            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            this.BindRepeater();

        }
        catch (Exception ex)
        {
        }

    }

    protected void btnViewAlbum_Click(object sender, EventArgs e)
    {

    }

    private void BindRepeater()
    {
        string constr = "Server=tcp:azureproject2.database.windows.net,1433;Initial Catalog=PhotoAlbum;Persist Security Info=False;User ID=tushargarud;Password=password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT photoId, userName, photoTitle, timestamp, numberOfLikes, numberOfPeople, photo FROM dbo.Photos WHERE photoId<>12 ORDER BY photoId DESC", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dt.Columns.Add("photoContent", typeof(string));

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["photo"] != null) 
                        {
                            byte[] bytes = (byte[])dr["photo"];
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            dr["photoContent"] = "data:image/png;base64," + base64String;
                        }
                    }

                    rptPhotos.DataSource = dt;
                    rptPhotos.DataBind();
                }
            }
        }
    }

    protected void rptPhotos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        /* 
        int photoID = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "cmd_Like") // check command is cmd_delete
        {         
            string queryStr = "UPDATE dbo.Photos SET numberOfLikes = numberOfLikes + 1 WHERE photoId=" + photoID.ToString();
            SqlCommand command = new SqlCommand(queryStr);

            String connectionStr = "Server=tcp:azureproject2.database.windows.net,1433;Initial Catalog=PhotoAlbum;Persist Security Info=False;User ID=tushargarud;Password=password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionStr);

            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            this.BindRepeater();    

        }   */
    }

    /*
     <img src='<%#GetImage(Eval("photo"))%>' alt="" width="" height="" />    
      public string GetImage(object imageBytes)
      {
          if (imageBytes != null)
          {
              byte[] bytes = (byte[])imageBytes;
              string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
              return "data:image/png;base64," + base64String;
          }
          else
          {
              return "";
          }

      }   */
}