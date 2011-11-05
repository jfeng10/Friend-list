using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                String connectStr = "Provider=Microsoft.Jet.Oledb.4.0;data source=" + HttpContext.Current.Server.MapPath("~/App_Data/friends.mdb");
                //Label1.Text = connectStr;
                string seleceStr = "Select ID, Name, already_in from Friend_information order by ID";
                OleDbConnection accessCon = connn(connectStr);
                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(seleceStr, accessCon);
                DataSet ds = new DataSet();
                accessCon.Open();
                da.Fill(ds, "Friend_information");
                accessCon.Close();
                DataRow dr;
                string id = "";
                string name = "";
                bool already_in;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    id = dr[0].ToString();
                    name = (string)dr[1];
                    already_in = (bool)dr[2];
                    if (already_in)
                        List_friends.Items.Add(new ListItem(name, id));
                    else
                        List_recommand.Items.Add(new ListItem(name, id));
                }

            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            for (int i = List_friends.Items.Count - 1; i >= 0; i--)
            {
                if (List_friends.Items[i].Selected)
                {
                    List_recommand.Items.Insert(0, List_friends.Items[i]);
                    List_friends.Items.RemoveAt(i);
                }
            }
        }

        protected void List_recommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "changed";

            //Label1.Text = List_recommand.Items[List_recommand.SelectedIndex].Value;
        }
        public OleDbConnection connn(string sqlFromAccess)
        {
            OleDbConnection accessConn = new OleDbConnection(sqlFromAccess);
            return accessConn;
        }



        public bool accessCommExec(string accessCon, string _strcomm)
        {
            try
            {
                OleDbConnection sqlConn = new OleDbConnection(accessCon);
                OleDbCommand sqlComm = new OleDbCommand(_strcomm, sqlConn);
                sqlConn.Open();
                sqlComm.ExecuteNonQuery();
                sqlConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
                return false;
            }
        }

        protected void List_friends_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "changed";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = List_recommand.Items.Count - 1; i >= 0; i--)
            {
                if (List_recommand.Items[i].Selected)
                {
                    List_friends.Items.Insert(0, List_recommand.Items[i]);
                    List_recommand.Items.RemoveAt(i);
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label1.Text = "updating";
            String connectStr = "Provider=Microsoft.Jet.Oledb.4.0;data source=" + HttpContext.Current.Server.MapPath("~/App_Data/friends.mdb");
            //Label1.Text = connectStr;
            string setStr = "UPDATE Friend_information SET already_in=true WHERE already_in=false AND ID IN (";
            for (int i = List_friends.Items.Count - 1; i > 0; i--)
            {
                setStr += (List_friends.Items[i].Value + ",");

            }
            if (List_friends.Items.Count >= 1)
                setStr += (List_friends.Items[0].Value);
            setStr += ")";
            bool suc_friend = true;
            bool suc_recommand = true;
            if (List_friends.Items.Count >= 1)
                suc_friend = accessCommExec(connectStr, setStr);

            setStr = "UPDATE Friend_information SET already_in=false WHERE already_in=true AND ID IN (";
            for (int i = List_recommand.Items.Count - 1; i > 0; i--)
            {
                setStr += (List_recommand.Items[i].Value + ",");

            }
            if (List_recommand.Items.Count >= 1)
                setStr += (List_recommand.Items[0].Value);
            setStr += ")";
            if (List_recommand.Items.Count >= 1)
                suc_recommand = accessCommExec(connectStr, setStr);
            if (suc_friend && suc_recommand)
                Label1.Text = "update sucessfully!";
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String connectStr = "Provider=Microsoft.Jet.Oledb.4.0;data source=" + HttpContext.Current.Server.MapPath("~/App_Data/friends.mdb");
            //Label1.Text = connectStr;
            string setStr = "UPDATE Friend_information SET already_in=false WHERE already_in=true AND ID IN (6,8)";
            bool suc_recommand = accessCommExec(connectStr, setStr);
            //if (suc_recommand)
            //    Label1.Text = "suc~";
            //else
            //    Label1.Text = "fail~";
        }

        protected void Button_Rco_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= List_recommand.Items.Count - 1; i++)
            {
                if (List_recommand.Items[i].Selected)
                {
                    String connectStr = "Provider=Microsoft.Jet.Oledb.4.0;data source=" + HttpContext.Current.Server.MapPath("~/App_Data/friends.mdb");
                    //Label1.Text = connectStr;
                    string seleceStr = "Select * from Friend_information where ID="+List_recommand.Items[i].Value;
                    OleDbConnection accessCon = connn(connectStr);
                    System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(seleceStr, accessCon);
                    DataSet ds = new DataSet();
                    accessCon.Open();
                    da.Fill(ds, "Friend_information");
                    accessCon.Close();
                    string temp = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        temp += "ID: " + ds.Tables[0].Rows[0]["ID"].ToString()+"<br />";
                        temp += "name: " + ds.Tables[0].Rows[0]["Name"].ToString() + "<br />";
                        temp += "gender: " + ds.Tables[0].Rows[0]["Gender"].ToString() + "<br />";
                        temp += "tele: " + ds.Tables[0].Rows[0]["tel"].ToString() + "<br />";
                        temp += "email: " + ds.Tables[0].Rows[0]["email"].ToString() + "<br />";
                    }
                    Label1.Text = temp;
                    break;
                }
            }
            
        }

        protected void Button_friend_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= List_friends.Items.Count - 1; i++)
            {
                if (List_friends.Items[i].Selected)
                {
                    String connectStr = "Provider=Microsoft.Jet.Oledb.4.0;data source=" + HttpContext.Current.Server.MapPath("~/App_Data/friends.mdb");
                    //Label1.Text = connectStr;
                    string seleceStr = "Select * from Friend_information where ID=" + List_friends.Items[i].Value;
                    OleDbConnection accessCon = connn(connectStr);
                    System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(seleceStr, accessCon);
                    DataSet ds = new DataSet();
                    accessCon.Open();
                    da.Fill(ds, "Friend_information");
                    accessCon.Close();
                    string temp = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        temp += "ID: " + ds.Tables[0].Rows[0]["ID"].ToString() + "<br />";
                        temp += "name: " + ds.Tables[0].Rows[0]["Name"].ToString() + "<br />";
                        temp += "gender: " + ds.Tables[0].Rows[0]["Gender"].ToString() + "<br />";
                        temp += "tele: " + ds.Tables[0].Rows[0]["tel"].ToString() + "<br />";
                        temp += "email: " + ds.Tables[0].Rows[0]["email"].ToString() + "<br />";
                    }
                    Label1.Text = temp;
                    break;
                }
            }
        }

    }
}
