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
    public partial class frmCandidateAdd : Form
    {
        public frmCandidateAdd()
        {
            InitializeComponent();
        }
        private void FrmCandidateAdd_Load(object sender, EventArgs e)
        {
            if (!frmMainPage.candidateCreateOrModify)
            {
                pnlCandidateModify.Visible = false;
                pnlCandidateAdd.Visible = true;
                txtCandidatePasswordAdd.Enabled = false;
                txtCandidatePasswordAdd1.Enabled = false;
                chckBxCandidatePasswordAdd.Checked = false;
                lblPasswordRepeat.Enabled = false;
                lblCandidatePasswordAdd.Enabled = false;
            }
            else
            {

                chckBxCandidatePasswordModify.Enabled = false;
                pnlCandidateAdd.Visible = false;
                pnlCandidateModify.Visible = true;
                txtCandidatePasswordModify.Enabled = false;
                txtCandidatePasswordModify1.Enabled = false;
                chckBxCandidatePasswordModify.Checked = false;
                lblCandidatePasswordModify.Enabled = false;
                lblPasswordRepeat1.Enabled = false;

                for (int i = 0; i < 5; i++)
                {
                    sModify[i] = "";
                    bModify[i] = false;
                }
                refreshCandidateModify();
            }
            t = true;
        }
        SqlConnect sqlconnect = new SqlConnect();
        Random random = new Random();

        #region regionCandidateAdd
        private void BtnCandidateAddApply_Click_1(object sender, EventArgs e)
        {
            string password = "";
            if (txtCandidateNameAdd.Text == "")
            {   
                MessageBox.Show("Ad sahəsi boşdur!!!");
                return;
            }
            if (txtCandidateSurnameAdd.Text == "")
            {
                MessageBox.Show("Soyad sahəsi boşdur!!!");
                return;
            }
            if (txtCandidatePinAdd.Text == "")
            {
                MessageBox.Show("Pin sahəsi boşdur!!!");
                return;
            }
            if (!chckBxCandidatePasswordAdd.Checked)
            {
                password = "";
                for (int i = 0; i < 10; i++)
                {
                    password+= random.Next(0, 9).ToString();
                }                     
            }
            else
            {
                if (txtCandidatePasswordAdd.Text == "")
                {
                    MessageBox.Show("Şifrə sahəsi boşdur!!!");
                    return;
                }
                if (txtCandidatePasswordAdd1.Text == "")
                {
                    MessageBox.Show("Şifrəni təkrar daxil edin!!!");
                    return;
                }
                if (txtCandidatePasswordAdd.Text != txtCandidatePasswordAdd1.Text)
                {
                    MessageBox.Show("Şifrənin təkrarı yalnışdır!!!");
                    return;
                }
                else
                {
                    password = txtCandidatePasswordAdd.Text;
                }
            }
            try
            {
                string query = "insert into Candidate values(@Name,@Surname,@Birthday,@Pin,@Password)";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@Name", txtCandidateNameAdd.Text);
                cmd.Parameters.AddWithValue("@Surname", txtCandidateSurnameAdd.Text);
                cmd.Parameters.AddWithValue("@Birthday", dateCandidateBirthdayAdd.Value);
                cmd.Parameters.AddWithValue("@Pin", txtCandidatePinAdd.Text);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();
                sqlconnect.close();
                MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
                frmMainPage.candidateCreateOrModify = false;
                this.Hide();
                frmMainPage.idCandidate = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void ChckBxCandidatePasswordAdd_CheckedChanged_1(object sender, EventArgs e)
        {
            if (t)
            {
                if (chckBxCandidatePasswordAdd.Checked)
                {
                    txtCandidatePasswordAdd.Enabled = true;
                    txtCandidatePasswordAdd1.Enabled = true;
                    txtCandidatePasswordAdd.Text = "";
                    txtCandidatePasswordAdd1.Text = "";
                    lblPasswordRepeat.Enabled = true;
                    lblCandidatePasswordAdd.Enabled = true;
                }
                else
                {
                    txtCandidatePasswordAdd.Enabled = false;
                    txtCandidatePasswordAdd1.Enabled = false;
                    lblPasswordRepeat.Enabled = false;
                    lblCandidatePasswordAdd.Enabled = false;
                }
            }
        }
        private void BtnCandidateAddCancel_Click_1(object sender, EventArgs e)
        {
            this.Hide();    
        }
        #endregion

        #region regionCandidateModify
        string[] sModify = new string[5];
        bool[] bModify = new bool[5];
        bool t = false;
        private void refreshCandidateModify()
        {
            try
            {
                string query = "Select * from Candidate where ID=" + frmMainPage.idCandidate;
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    txtCandidateNameModify.Text = dt.Rows[0][1].ToString();
                    txtCandidateSurnameModify.Text = dt.Rows[0][2].ToString();
                    dateCandidateBirthdayModify.Value = Convert.ToDateTime(dt.Rows[0][3].ToString());
                    txtCandidatePinModify.Text = dt.Rows[0][4].ToString();
                    txtCandidatePasswordModify.Text = dt.Rows[0][5].ToString();
                    txtCandidatePasswordModify1.Text = dt.Rows[0][5].ToString();
                    txtCandidatePasswordModify1.PasswordChar = '*';
                }

                else
                {
                    MessageBox.Show("Namizəd tapılmadı!");
                }
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void BtnCandidateModifyApply_Click(object sender, EventArgs e)
        {
            string s = MessageBox.Show("Məlumata düzəliş edilməsinə əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (s == "Yes")
            {
                string password = "";
                #region
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
                        MessageBox.Show("Soyad sahəsi boşdur!!!");
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

                if (bModify[2])
                {
                    if (sModify[2] == "")
                    {
                        MessageBox.Show("Tarix sahəsi boşdur!!!");
                        return;
                    }
                    else
                    {
                        if (query == "")
                        {
                            query += sModify[2];
                        }
                        else
                        {
                            query += ", " + sModify[2];
                        }

                    }
                }

                if (bModify[3])
                {
                    if (sModify[3] == "")
                    {
                        MessageBox.Show("Pin sahəsi boşdur!!!");
                        return;
                    }
                    else
                    {
                        if (query == "")
                        {
                            query += sModify[3];
                        }
                        else
                        {
                            query += ", " + sModify[3];
                        }

                    }
                }

                if (chckBxCandidatePasswordModify1.Checked)
                {
                    if (!chckBxCandidatePasswordModify.Checked)
                    {
                        password = "";
                        for (int i = 0; i < 10; i++)
                        {
                            password += random.Next(0, 9).ToString();
                        }
                        if (query == "")
                        {
                            query += "Password='" + password + "'";
                        }
                        else
                        {
                            query += ",Password='" + password + "'";
                        }
                    }
                    else
                    {
                        if (bModify[4])
                        {
                            if (txtCandidatePasswordModify.Text == "")
                            {
                                MessageBox.Show("Şifrə sahəsi boşdur!!!");
                                return;
                            }
                            if (txtCandidatePasswordModify1.Text == "")
                            {
                                MessageBox.Show("Şifrəni təkrar daxil edin!!!");
                                return;
                            }
                            if (txtCandidatePasswordModify.Text != txtCandidatePasswordModify1.Text)
                            {
                                MessageBox.Show("Şifrənin təkrarı yalnışdır!!!");
                                return;
                            }
                            else
                            {
                                if (query == "")
                                {
                                    query += sModify[4];
                                }
                                else
                                {
                                    query += ", " + sModify[4];
                                }
                            }
                        }
                    }
                }

                #endregion
                #region
                if (query != "")
                {
                    string fullquery = "UPDATE Candidate SET " + query + " Where ID=" + frmMainPage.idCandidate;
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
                        frmMainPage.idCandidate = -1;
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
                #endregion                
            }
        }
        private void BtnCandidateModifyCancel_Click(object sender, EventArgs e)
        {
            this.Hide();            
        }
        private void TxtCandidateNameModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtCandidateNameModify.Text!="")
                {
                    sModify[0] = "Name='" + txtCandidateNameModify.Text + "'";
                }              
                bModify[0] = true;
            }           
        }
        private void TxtCandidateSurnameModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtCandidateSurnameModify.Text!="")
                {
                    sModify[1] = "Surname='" + txtCandidateSurnameModify.Text + "'";
                }              
                bModify[1] = true;
            }           
        }
        private void DateCandidateBirthdayModify_ValueChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (dateCandidateBirthdayModify.Value!=DateTime.Now)
                {
                    sModify[2] = "Birthday='" + dateCandidateBirthdayModify.Value.ToString() + "'";
                }                
                bModify[2] = true;
            }           
        }
        private void TxtCandidatePinModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtCandidatePinModify.Text!="")
                {
                    sModify[3] = "Pin='" + txtCandidatePinModify.Text + "'";
                }               
                bModify[3] = true;
            }         
        }
        private void TxtCandidatePasswordModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtCandidatePasswordModify.Text!="")
                {
                    sModify[4] = "Password='" + txtCandidatePasswordModify.Text + "'";
                }
                bModify[4] = true;
            }           
        }
        private void TxtCandidatePasswordModify1_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtCandidatePasswordModify.Text!="")
                {
                    sModify[4] = "Password='" + txtCandidatePasswordModify.Text + "'";
                }                
                bModify[4] = true;
            }          
        }
        private void ChckBxCandidatePasswordModify_CheckedChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (chckBxCandidatePasswordModify.Checked)
                {
                    txtCandidatePasswordModify.Enabled = true;
                    txtCandidatePasswordModify1.Enabled = true;
                    //txtCandidatePasswordModify.Text = "";
                    //txtCandidatePasswordModify1.Text = "";
                    chckBxCandidatePasswordModify.Checked = true;
                    lblCandidatePasswordModify.Enabled = true;
                    lblPasswordRepeat1.Enabled = true;
                }
                else
                {
                    txtCandidatePasswordModify.Enabled = false;
                    txtCandidatePasswordModify1.Enabled = false;
                    chckBxCandidatePasswordModify.Checked = false;
                    lblCandidatePasswordModify.Enabled = false;
                    lblPasswordRepeat1.Enabled = false;
                }
            }
        }
        private void ChckBxCandidatePasswordModify1_CheckedChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (chckBxCandidatePasswordModify1.Checked)
                {
                    chckBxCandidatePasswordModify.Enabled = true;
                }
                else
                {
                    chckBxCandidatePasswordModify.Enabled = false;
                    chckBxCandidatePasswordModify.Checked = false;
                }
            }
        }
        #endregion
 
    }
}
