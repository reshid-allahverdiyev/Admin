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
    public partial class frmTopicAdd : Form
    {
        public frmTopicAdd()
        {
            InitializeComponent();
        }

        SqlConnect sqlconnect = new SqlConnect();
        private void FrmTopicAdd_Load(object sender, EventArgs e)
        {
            if (!frmMainPage.topicCreateOrModify)
            {
                pnlTopicModify.Visible = false;
                pnlTopicAdd.Visible = true;
            }
            else
            {
                pnlTopicAdd.Visible = false;
                pnlTopicModify.Visible = true;
                for (int i = 0; i < 5; i++)
                {
                    sModify[i] = "";
                    bModify[i] = false;
                }
                refreshTopicModify();
            }
            t = true;
        }

        #region region TopicAdd
        private void BtnTopicAddCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BtnTopicAddApply_Click(object sender, EventArgs e)
        {
            string password = "";
            if (txtTopicNameAdd.Text == "")
            {
                MessageBox.Show("Ad sahəsi boşdur!!!");
                return;
            }            
            try
            {
                string query = "insert into Topic values(@Name)";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@Name", txtTopicNameAdd.Text);                
                cmd.ExecuteNonQuery();
                sqlconnect.close();
                MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
                frmMainPage.topicCreateOrModify = false;
                this.Hide();
                frmMainPage.idGroup = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }

        }
        #endregion

        #region region TopicModify
        string[] sModify = new string[5];
        bool[] bModify = new bool[5];
        bool t = false;
        private void refreshTopicModify()
        {
            try
            {
                string query = "Select * from Topic where ID=" + frmMainPage.idTopic;
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    txtTopicNameModify.Text = dt.Rows[0][1].ToString();                    
                }
                else
                {
                    MessageBox.Show("Mövzu tapılmadı!");
                }
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void BtnTopicModifyCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BtnTopicModifyApply_Click(object sender, EventArgs e)
        {
            string s = MessageBox.Show("Məlumata düzəliş edilməsinə əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (s == "Yes")
            {
                string query = "";
                if (bModify[0])
                {
                    if (sModify[0] == "")
                    {
                        MessageBox.Show("Ad sahəsi boşdur!!!");
                        return;
                    }
                    else
                    {
                        query += sModify[0];
                    }
                }
                if (bModify[1])
                {
                    if (sModify[1] == "")
                    {
                        MessageBox.Show("Mövzu sayı sahəsi boşdur!!!");
                        return;
                    }
                    else
                    {
                        if (query == "")
                        {
                            query += sModify[1];
                        }
                        else
                        {
                            query += ", " + sModify[1];
                        }
                    }
                }
                if (query != "")
                {
                    string fullquery = "UPDATE Topic SET " + query + " Where ID=" + frmMainPage.idTopic;
                    try
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(fullquery, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Düzəliş uğurla tamamlandı");
                        frmMainPage.topicCreateOrModify = false;
                        this.Hide();
                        sqlconnect.close();
                        frmMainPage.idTopic = -1;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
                else
                {
                    MessageBox.Show("Düzəlişləri daxil edin!");
                }
            }
        }
        private void TxtTopicNameModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtTopicNameModify.Text != "")
                {
                    sModify[0] = "Name='" + txtTopicNameModify.Text + "'";
                }
                bModify[0] = true;
            }
        }
        #endregion
    }
}
