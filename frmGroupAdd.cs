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
    public partial class frmGroupAdd : Form
    {
        public frmGroupAdd()
        {
            InitializeComponent();
        }
        SqlConnect sqlconnect = new SqlConnect();
        private void FrmGroupAdd_Load(object sender, EventArgs e)
        {
            if (!frmMainPage.groupCreateOrModify)
            {
                pnlGroupModify.Visible = false;
                pnlGroupAdd.Visible = true;                          
            }
            else
            {                
                pnlGroupAdd.Visible = false;
                pnlGroupModify.Visible = true;
                for (int i = 0; i < 5; i++)
                {
                    sModify[i] = "";
                    bModify[i] = false;
                }
                refreshGroupModify();
            }
            t = true;
        }
        
        #region regionGroupAdd
        private void BtnGroupAddCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BtnGroupAddApply_Click(object sender, EventArgs e)
        {             
            if (txtGroupNameAdd.Text == "")
            {
                MessageBox.Show("Ad sahəsi boşdur!!!");
                return;
            }
            if (txtGroupCandidateCountAdd.Text == "")
            {
                MessageBox.Show("Namizəd sayı sahəsi boşdur!!!");
                return;
            }                     
            try
            {
                string query = "insert into Groups values(@Name,@Candidate_count)";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@Name", txtGroupNameAdd.Text);
                cmd.Parameters.AddWithValue("@Candidate_count", txtGroupCandidateCountAdd.Text);             
                cmd.ExecuteNonQuery();
                sqlconnect.close();
                MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
                frmMainPage.groupCreateOrModify = false;
                this.Hide();
                frmMainPage.idGroup = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        #endregion

        #region region GroupModify
        string[] sModify = new string[5];
        bool[] bModify = new bool[5];
        bool t = false;
        private void refreshGroupModify()
        {
            try
            {
                string query = "Select * from Groups where ID=" + frmMainPage.idGroup;
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    txtGroupNameModify .Text = dt.Rows[0][1].ToString();
                    txtGroupCandidateCountModify.Text = dt.Rows[0][2].ToString();                  
                }
                else
                {
                    MessageBox.Show("Qrup tapılmadı!");
                }
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void BtnGroupModifyCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BtnGroupModifyApply_Click(object sender, EventArgs e)
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
                        MessageBox.Show("Namizəd sayı sahəsi boşdur!!!");
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
                    string fullquery = "UPDATE Groups SET " + query + " Where ID=" + frmMainPage.idGroup;
                    try
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(fullquery, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Düzəliş uğurla tamamlandı");
                        frmMainPage.candidateCreateOrModify = false;
                        this.Hide();
                        sqlconnect.close();
                        frmMainPage.idGroup = -1;
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
        private void TxtGroupNameModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtGroupNameModify.Text != "")
                {
                    sModify[0] = "Name='" + txtGroupNameModify.Text + "'";
                }               
                bModify[0] = true;
            }
        }
        private void TxtGroupCandidateCountModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtGroupCandidateCountModify.Text != "")
                {
                    sModify[1] = "Candidate_count='" + txtGroupCandidateCountModify.Text + "'";
                }
                bModify[1] = true;
            }
        }
        #endregion
    }
}
