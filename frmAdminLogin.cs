using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class frmAdminLogin : Form
    {
        public frmAdminLogin()
        {
            InitializeComponent();
        }
        public static string user_name = "";
        private static int user_ID=0;
        public static int loggedUser_ID = 0;
        SqlConnect sqlconnect = new SqlConnect();
        private void loggedUsers()
        {
            try
            {
                string query = "insert into Logged_user(User_ID,Login_date) values(@user_ID,@Login_date)";       
                SqlCommand cmd = new SqlCommand();             
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@user_ID", user_ID);
                cmd.Parameters.AddWithValue("@Login_date", DateTime.Now);
                cmd.ExecuteNonQuery();
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void getLoggedUserID()
        {
            try
            {
                string query = "Select * from Logged_user where ID=";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());            
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    loggedUser_ID = Int32.Parse(Convert.ToString(dt.Rows[0]["ID"]));
                    sqlconnect.close();                
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //try
            //{
                lblNote.Text = "";
                string query = "Select * from Users u where u.Username=@username and u.Password=@password";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtUserPassword.Text);
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    user_name = Convert.ToString(dt.Rows[0]["Name"]);    
                    user_ID = Int32.Parse(Convert.ToString(dt.Rows[0]["ID"]));                   
                    sqlconnect.close();
                    this.Hide();
                    frmMainPage frmMainPage = new frmMainPage();
                    frmMainPage.Show();
                }
                else
                {
                    lblNote.Text = "İstifadəçi adı və ya parolu yalnışdır!";
                }
              //  loggedUsers();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            //}
        }
        private void FrmAdminLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }       
    }
}
