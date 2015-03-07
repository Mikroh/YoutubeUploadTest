using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;


public partial class video : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["logout"] != null)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ToString();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "SELECT *, Users.username FROM Videos INNER JOIN Users ON Videos.userID=Users.id WHERE Videos.id = @videoQuery";

        cmd.Parameters.AddWithValue("@videoQuery", Request.QueryString["id"]);

        con.Open();

        SqlDataReader reader = cmd.ExecuteReader();
        VideoRepeater.DataSource = reader;
        VideoRepeater.DataBind();

        con.Close();
    }
}