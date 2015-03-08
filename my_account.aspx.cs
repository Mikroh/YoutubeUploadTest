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

public partial class my_account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["logout"] != null) {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        if (Session["id"] == null || Session["username"] == null || Session["password"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        LabelSuccess.Visible = false;

    }
        
    protected void ButtonUpload_Click(object sender, EventArgs e)
    {
        TextBoxURL.Text = TextBoxURL.Text.Replace("https://www.youtube.com/watch?v=", "");
        TextBoxURL.Text = TextBoxURL.Text.Replace("http://www.youtube.com/watch?v=", "");
        TextBoxURL.Text = TextBoxURL.Text.Replace("www.youtube.com/watch?v=", "");
        TextBoxURL.Text = TextBoxURL.Text.Replace("youtube.com/watch?v=", "");
        TextBoxURL.Text = TextBoxURL.Text.Replace("http://youtube.com/watch?v=", "");
        TextBoxURL.Text = TextBoxURL.Text.Replace("https://youtube.com/watch?v=","");

        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ToString();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Videos SET title=title WHERE URL = @URL IF @@ROWCOUNT=0 INSERT INTO Videos (title, URL, userID) VALUES (@title, @URL, @userID)";

        cmd.Parameters.AddWithValue("@title", TextBoxTitle.Text);
        cmd.Parameters.AddWithValue("@URL", TextBoxURL.Text);
        cmd.Parameters.AddWithValue("@userID", Session["id"]);

        con.Open();
        int result = cmd.ExecuteNonQuery();
        con.Close();

        if(result != 1) {
            TextBoxURL.Text = "";
            LabelSuccess.Text = "Der var en fejl. Din video er måske allerede blevet tilføjet.";
            LabelSuccess.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            LabelSuccess.Visible = true;
        }
        else {
        TextBoxTitle.Text = "";
        TextBoxURL.Text = "";
        LabelSuccess.Text = "Le upload is complete";
        LabelSuccess.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00E31A");
        LabelSuccess.Visible = true;
        }
        }
}