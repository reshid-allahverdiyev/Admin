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
    public partial class frmUserAdd : Form
    {
        public frmUserAdd()
        {
            InitializeComponent();
        }
        SqlConnect sqlconnect = new SqlConnect();
        Random random = new Random();
        private void FrmUserAdd_Load(object sender, EventArgs e)
        {
            if (!frmMainPage.userCreateOrModify)
            {
                pnlUserModify.Visible = false;
                pnlUserAdd.Visible = true;
                txtUserPasswordAdd.Enabled = false;
                txtUserPasswordAdd1.Enabled = false;
                chckBxUserPasswordAdd.Checked = false;
                lblPasswordRepeatAdd.Enabled = false;
                lblUserPasswordAdd.Enabled = false;
            }
            else
            {

                chckBxUserPasswordModify.Enabled = false;
                pnlUserAdd.Visible = false;
                pnlUserModify.Visible = true;
                txtUserPasswordModify.Enabled = false;
                txtUserPasswordModify1.Enabled = false;
                chckBxUserPasswordModify.Checked = false;
                lblUserPasswordModify.Enabled = false;
                lblPasswordRepeatModify.Enabled = false;

                for (int i = 0; i < 6; i++)
                {
                    sModify[i] = "";
                    bModify[i] = false;
                }
                refreshUserModify();
            }
            t = true;
        }

        #region regionUserAdd
        private void BtnUserAddCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BtnUserAddApply_Click(object sender, EventArgs e)
        {
            string password = "";
            if (txtUserNameAdd.Text == "")
            {
                MessageBox.Show("Ad sahəsi boşdur!!!");
                return;
            }
            if (txtUserSurnameAdd.Text == "")
            {
                MessageBox.Show("Soyad sahəsi boşdur!!!");
                return;
            }
            if (txtUserPinAdd.Text == "")
            {
                MessageBox.Show("Pin sahəsi boşdur!!!");
                return;
            }
            if (txtUserUsernameAdd.Text == "")
            {
                MessageBox.Show("İstifadəçi sahəsi boşdur!!!");
                return;
            }
            if (!chckBxUserPasswordAdd.Checked)
            {
                password = "";
                for (int i = 0; i < 10; i++)
                {
                    password += random.Next(0, 9).ToString();
                }
            }
            else
            {
                if (txtUserPasswordAdd.Text == "")
                {
                    MessageBox.Show("Şifrə sahəsi boşdur!!!");
                    return;
                }
                if (txtUserPasswordAdd1.Text == "")
                {
                    MessageBox.Show("Şifrəni təkrar daxil edin!!!");
                    return;
                }
                if (txtUserPasswordAdd.Text != txtUserPasswordAdd1.Text)
                {
                    MessageBox.Show("Şifrənin təkrarı yalnışdır!!!");
                    return;
                }
                else
                {
                    password = txtUserPasswordAdd.Text;
                }
            }
            try
            {
                string query = "insert into Users values(@Name,@Surname,@Birthday,@Username,@Pin,@Password)";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@Name", txtUserNameAdd.Text);
                cmd.Parameters.AddWithValue("@Surname", txtUserSurnameAdd.Text);
                cmd.Parameters.AddWithValue("@Birthday", dateUserBirthdayAdd.Value);
                cmd.Parameters.AddWithValue("@Pin", txtUserPinAdd.Text);
                cmd.Parameters.AddWithValue("@Username", txtUserUsernameAdd.Text);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();
                sqlconnect.close();
                MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
                frmMainPage.userCreateOrModify = false;
                this.Hide();
                frmMainPage.idUser = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void ChckBxUserPasswordAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (chckBxUserPasswordAdd.Checked)
                {
                    txtUserPasswordAdd.Enabled = true;
                    txtUserPasswordAdd1.Enabled = true;
                    txtUserPasswordAdd.Text = "";
                    txtUserPasswordAdd1.Text = "";
                    lblPasswordRepeatAdd.Enabled = true;
                    lblUserPasswordAdd.Enabled = true;
                }
                else
                {
                    txtUserPasswordAdd.Enabled = false;
                    txtUserPasswordAdd1.Enabled = false;
                    lblPasswordRepeatAdd.Enabled = false;
                    lblUserPasswordAdd.Enabled = false;
                }
            }
        }
        #endregion

        #region regionUserModify
        string[] sModify = new string[6];
        bool[] bModify = new bool[6];
        bool t = false;
        private void refreshUserModify()
        {
            try
            {
                string query = "Select * from Users where ID=" + frmMainPage.idUser;
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    txtUserNameModify.Text = dt.Rows[0][1].ToString();
                    txtUserSurnameModify.Text = dt.Rows[0][2].ToString();
                    dateUserBirthdayModify.Value = Convert.ToDateTime(dt.Rows[0][3].ToString());
                    txtUserPinModify.Text = dt.Rows[0][4].ToString();
                    txtUserUsernameModify.Text = dt.Rows[0][5].ToString();
                    txtUserPasswordModify.Text = dt.Rows[0][6].ToString();
                    txtUserPasswordModify1.Text = dt.Rows[0][6].ToString();
                    txtUserPasswordModify1.PasswordChar = '*';
                }
                else
                {
                    MessageBox.Show("İstifadəçi tapılmadı!");
                }
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void BtnUserModifyCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BtnUserModifyApply_Click(object sender, EventArgs e)
        {
            string s = MessageBox.Show("Məlumata düzəliş edilməsinə əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (s == "Yes")
            {
                string password = "";             
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
                if (bModify[4])
                {
                    if (sModify[4] == "")
                    {
                        MessageBox.Show("İstifadəçi sahəsi boşdur!!!");
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
                if (chckBxUserPasswordModify1.Checked)
                {
                    if (!chckBxUserPasswordModify.Checked)
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
                        if (bModify[5])
                        {
                            if (txtUserPasswordModify.Text == "")
                            {
                                MessageBox.Show("Şifrə sahəsi boşdur!!!");
                                return;
                            }
                            if (txtUserPasswordModify1.Text == "")
                            {
                                MessageBox.Show("Şifrəni təkrar daxil edin!!!");
                                return;
                            }
                            if (txtUserPasswordModify.Text != txtUserPasswordModify1.Text)
                            {
                                MessageBox.Show("Şifrənin təkrarı yalnışdır!!!");
                                return;
                            }
                            else
                            {
                                if (query == "")
                                {
                                    query += sModify[5];
                                }
                                else
                                {
                                    query += ", " + sModify[5];
                                }
                            }
                        }
                    }
                }              
             
                if (query != "")
                {
                    string fullquery = "UPDATE Users SET " + query + " Where ID=" + frmMainPage.idUser;
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(fullquery, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Düzəliş uğurla tamamlandı");
                        frmMainPage.userCreateOrModify = false;
                        this.Hide();
                        sqlconnect.close();
                        frmMainPage.idUser = -1;
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
        private void TxtUserNameModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtUserNameModify.Text != "")
                {
                    sModify[0] = "Name='" + txtUserNameModify.Text + "'";
                }
                bModify[0] = true;
            }
        }
        private void TxtUserSurnameModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtUserSurnameModify.Text != "")
                {
                    sModify[1] = "Surname='" + txtUserSurnameModify.Text + "'";
                }
                bModify[1] = true;
            }
        }
        private void DateUserBirthdayModify_ValueChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (dateUserBirthdayModify.Value != DateTime.Now)
                {
                    sModify[2] = "Birthday='" + dateUserBirthdayModify.Value.ToString() + "'";
                }
                bModify[2] = true;
            }
        }
        private void TxtUserPinModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtUserPinModify.Text != "")
                {
                    sModify[3] = "Pin='" + txtUserPinModify.Text + "'";
                }
                bModify[3] = true;
            }
        }
        private void TxtUserUsernameModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtUserUsernameModify.Text != "")
                {
                    sModify[4] = "Username='" + txtUserUsernameModify.Text + "'";
                }
                bModify[4] = true;
            }
        }
        private void TxtUserPasswordModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtUserPasswordModify.Text != "")
                {
                    sModify[4] = "Password='" + txtUserPasswordModify.Text + "'";
                }
                bModify[4] = true;
            }
        }
        private void TxtUserPasswordModify1_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtUserPasswordModify1.Text != "")
                {
                    sModify[4] = "Password='" + txtUserPasswordModify1.Text + "'";
                }
                bModify[4] = true;
            }
        }
        private void ChckBxUserPasswordModify1_CheckedChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (chckBxUserPasswordModify1.Checked)
                {
                    chckBxUserPasswordModify.Enabled = true;
                }
                else
                {
                    chckBxUserPasswordModify.Enabled = false;
                    chckBxUserPasswordModify.Checked = false;
                }
            }
        }
        private void ChckBxUserPasswordModify_CheckedChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (chckBxUserPasswordModify.Checked)
                {
                    txtUserPasswordModify.Enabled = true;
                    txtUserPasswordModify1.Enabled = true;                  
                    chckBxUserPasswordModify.Checked = true;
                    lblUserPasswordModify.Enabled = true;
                    lblPasswordRepeatModify.Enabled = true;
                }
                else
                {
                    txtUserPasswordModify.Enabled = false;
                    txtUserPasswordModify1.Enabled = false;
                    chckBxUserPasswordModify.Checked = false;
                    lblUserPasswordModify.Enabled = false;
                    lblPasswordRepeatModify.Enabled = false;
                }
            }
        }
        #endregion

    }
}
