using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;

public partial class Page2 : System.Web.UI.Page
{
    String UserId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserId"] = Request.QueryString["UserId"];
        lblWelcome.Text = "Welcome " + Session["UserId"].ToString();
    }

    protected void btnUploadPhotos_Click(object sender, EventArgs e)
    {
        SqlConnection conn;
        try
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    String connectionStr = "Server = tcp:cse6331project2sqlserver.database.windows.net,1433; Initial Catalog = CSE6331_Project2; Persist Security Info = False; User ID = abhidhotre91; Password = Password!23; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                    conn = new SqlConnection(connectionStr);
                    using (conn)
                    {
                        string query = "insert into dbo.Photos (UserId, " +
                            "Title, " +
                            "CreateTime, " +
                            "LikesNumber, " +
                            "PeopleNumber, " +
                            "Photo) " +
                            "values (@UserId, " +
                            "@Title, " +
                            "@CreateTime, " +
                            "@LikesNumber, " +
                            "@PeopleNumber, " +
                            "@Photo)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = conn;
                            cmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString());
                            cmd.Parameters.AddWithValue("@Title", filename);
                            cmd.Parameters.AddWithValue("@CreateTime", DateTime.Now.ToString());
                            cmd.Parameters.AddWithValue("@LikesNumber", 0);
                            cmd.Parameters.AddWithValue("@PeopleNumber", 0);
                            cmd.Parameters.AddWithValue("@Photo", bytes);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnViewPhotos_Click(object sender, EventArgs e)
    {
        RefreshGrid();
    }

    private void LikePhoto(int photoId)
    {
        SqlConnection conn;
        try
        {
            String connectionStr = "Server = tcp:cse6331project2sqlserver.database.windows.net,1433; Initial Catalog = CSE6331_Project2; Persist Security Info = False; User ID = abhidhotre91; Password = Password!23; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            conn = new SqlConnection(connectionStr);
            conn.Open();
            using (conn)
            {
                string likes = "select LikesNumber from dbo.Photos where PhotoId = '" + photoId + "'";
                SqlCommand cmd = new SqlCommand(likes, conn);
                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                string update = "Update dbo.Photos set LikesNumber = " + (temp + 1) + " " +
                    "where PhotoId = " + photoId;
                cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            RefreshGrid();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void RefreshGrid()
    {
        SqlConnection conn;
        DataTable dt;
        try
        {
            String connectionStr = "Server = tcp:cse6331project2sqlserver.database.windows.net,1433; Initial Catalog = CSE6331_Project2; Persist Security Info = False; User ID = abhidhotre91; Password = Password!23; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            conn = new SqlConnection(connectionStr);
            using (conn)
            {
                string query = "select PhotoId, Title, UserId, CreateTime, Photo, LikesNumber from dbo.Photos";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt = new DataTable();
                        dt.Load(dr);
                        gvImages.DataSource = dt;
                        gvImages.DataBind();
                    }
                    conn.Close();
                }
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            byte[] bytes = (byte[])(e.Row.DataItem as DataRowView)["Photo"];
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            (e.Row.FindControl("Image1") as Image).ImageUrl = "data:image/png;base64," + base64String;
        }
    }

    protected void gvImages_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "LikePhoto")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvImages.Rows[index];
            int photoId = (int)gvImages.DataKeys[index].Value;
            LikePhoto(photoId);
        }
    }
}