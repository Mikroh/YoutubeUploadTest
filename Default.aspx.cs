using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LabelFail.Visible = false;
        //if(Request.QueryString["haxor"] != null) {
        //    LabelFail.Text = "NEIN!!!!";
        //}
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ToString();

        SqlCommand getVideos = new SqlCommand();
        getVideos.Connection = con;
        getVideos.CommandText = "SELECT *, Users.Username FROM Videos INNER JOIN Users ON Videos.userID=Users.Id";

        con.Open();
        SqlDataReader videoReader = getVideos.ExecuteReader();
        RepeaterVideos.DataSource = videoReader;
        RepeaterVideos.DataBind();
        con.Close();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ToString();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "SELECT * FROM Users WHERE @username = username AND @password = password";
        cmd.Parameters.AddWithValue("@username", TextBoxUsernameLogin.Text);
        cmd.Parameters.AddWithValue("@password", TextBoxPasswordLogin.Text);

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Session["id"] = reader["id"];
            Session["username"] = reader["username"];
            Session["password"] = reader["password"];

            Response.Redirect("my_account.aspx");
        }
        else
        {
            LabelFail.Visible = true;
        }
        con.Close();
    }
}