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
    public partial class frmExamAdd : Form
    {
        public frmExamAdd()
        {
            InitializeComponent();
        }
        SqlConnect sqlconnect = new SqlConnect();
        private void FrmExamAdd_Load(object sender, EventArgs e)
        {
            if (!frmMainPage.examCreateOrModify)
            {
                pnlExamModify.Visible = false;
                pnlExamAdd.Visible = true;
                FillExamAddTopic();
                FillExamAddGroup();
            }
            else
            {
                pnlExamAdd.Visible = false;
                pnlExamModify.Visible = true;
                for (int i = 0; i < 8; i++)
                {
                    sModify[i] = "";
                    bModify[i] = false;
                }               
                FillcmbbxExamTopicModify();
                FillcmbbxExamGroupModify();
                FillExamModify();
            }
            t = true;
        }

        #region regionExamAdd
        private void FillExamAddTopic()
        {
            try
            {
                string query = "Select ID,Name from Topic";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmbbxExamTopicAdd.DataSource = ds.Tables[0];
                cmbbxExamTopicAdd.DisplayMember = "Name";
                cmbbxExamTopicAdd.ValueMember = "ID";
                cmbbxExamTopicAdd.SelectedItem = null;
                cmbbxExamTopicAdd.Text = "Mövzunu seçin";               
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void FillExamAddGroup()
        {
            try
            {
                string query = "Select ID,Name from Groups";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);              
                cmbbxExamGroupAdd.DataSource = ds.Tables[0];
                cmbbxExamGroupAdd.DisplayMember = "Name";
                cmbbxExamGroupAdd.ValueMember = "ID";
                cmbbxExamGroupAdd.SelectedItem = null;
                cmbbxExamGroupAdd.Text = "Qrupu seçin";
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void BtnExamAddCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BtnExamAddApply_Click(object sender, EventArgs e)
        {
            if (txtExamNameAdd.Text == "")
            {
                MessageBox.Show("Imatahan adını daxil edin!!!");
                return;
            }
            if (txtExamAddressAdd.Text == "")
            {
                MessageBox.Show("Ünvan sahəsi boşdur!!!");
                return;
            }
            if (txtExamTestCountAdd.Text == "")
            {
                MessageBox.Show("Test sayı sahəsi boşdur!!!");
                return;
            }
            if (txtExamPeriodAdd.Text == "")
            {
                MessageBox.Show("İmtahan müddəti sahəsi boşdur!!!");
                return;
            }
            if (txtExamMinPointAdd.Text == "")
            {
                MessageBox.Show("Keçid balı sahəsi boşdur!!!");
                return;
            }           
            if (cmbbxExamTopicAdd.SelectedItem == null)
            {
                MessageBox.Show("Mövzunu seçin!!!");
                return;
            }
            if (cmbbxExamTopicAdd.SelectedItem == null)
            {
                MessageBox.Show("Qrupu seçin!!!");
                return;
            }
            try
            {
                string query = "insert into Exam values(@Name,@Address,@Test_count,@Period,@Min_point,@Begin_date,@Begin_time,@Topic_ID,@Group_ID)";
                SqlCommand cmd = new SqlCommand();          
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@Name", txtExamNameAdd.Text);
                cmd.Parameters.AddWithValue("@Address", txtExamAddressAdd.Text);
                cmd.Parameters.AddWithValue("@Test_count", txtExamTestCountAdd.Text);
                cmd.Parameters.AddWithValue("@Period", txtExamPeriodAdd.Text);
                cmd.Parameters.AddWithValue("@Min_point", txtExamMinPointAdd.Text);
                cmd.Parameters.AddWithValue("@Begin_date", dttmExamDateAdd.Value.ToString());
                cmd.Parameters.AddWithValue("@Begin_time",maskedTxtExamTimeAdd.Text);
                cmd.Parameters.AddWithValue("@Topic_ID", cmbbxExamTopicAdd.SelectedValue);
                cmd.Parameters.AddWithValue("@Group_ID", cmbbxExamGroupAdd.SelectedValue); 
                cmd.ExecuteNonQuery();               
                sqlconnect.close();
                MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
                frmMainPage.examCreateOrModify = false;
                this.Hide();   
                frmMainPage.idExam = -1; txtExamNameAdd.Text = query; return;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        #endregion

        #region regionExamModify
        string[] sModify = new string[8];
        bool[] bModify = new bool[8];
        bool t = false;
        private void FillExamModify()
        {
            try
            {
                string query = "Select * from Exam where ID=" + frmMainPage.idExam;
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    txtExamNameModify.Text = dt.Rows[0][1].ToString();
                    txtExamAddressModify.Text = dt.Rows[0][2].ToString();
                    txtExamTestCountModify.Text = dt.Rows[0][3].ToString();
                    txtExamPeriodModify.Text = dt.Rows[0][4].ToString();
                    txtExamMinPointModify.Text = dt.Rows[0][5].ToString();
                    dttmExamDateModify.Value =Convert.ToDateTime(dt.Rows[0][6].ToString());
                    cmbbxExamTopicModify.SelectedValue = Convert.ToInt32(dt.Rows[0][7].ToString());
                    cmbbxExamGroupModify.SelectedValue = Convert.ToInt32(dt.Rows[0][8].ToString());
                }
                else
                {
                    MessageBox.Show("Test tapılmadı!");
                }
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void FillcmbbxExamTopicModify()
        {
            try
            {
                string query = "Select * from Topic";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmbbxExamTopicModify.DataSource = ds.Tables[0];
                cmbbxExamTopicModify.DisplayMember = "Name";
                cmbbxExamTopicModify.ValueMember = "ID";
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void FillcmbbxExamGroupModify()
        {
            try
            {
                string query = "Select * from Groups";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmbbxExamGroupModify.DataSource = ds.Tables[0];
                cmbbxExamGroupModify.DisplayMember = "Name";
                cmbbxExamGroupModify.ValueMember = "ID";
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void BtnExamModifyCancel_Click(object sender, EventArgs e)
        {
            frmMainPage.idExam = -1;
            this.Hide();
        }
        private void BtnExamModifyApply_Click(object sender, EventArgs e)
        {
            string s = MessageBox.Show("Məlumata düzəliş edilməsinə əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (s == "Yes")
            {
                string query = "";
                if (bModify[0])
                {
                    if (sModify[0] == "")
                    {
                        MessageBox.Show("İmtahan adı sahəsi boşdur!!!");
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
                        MessageBox.Show("Ünvan sahəsi boşdur!!!");
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
                        MessageBox.Show("Test sayı sahəsi boşdur!!!");
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
                        MessageBox.Show("İmtahan müddəti sahəsi boşdur!!!");
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
                        MessageBox.Show("Keçid balı sahəsi  boşdur!!!");
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
                if (bModify[5])
                {
                    if (sModify[5] == "")
                    {
                        MessageBox.Show("Başlama tarixini qeyd edin!!!");
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
                if (bModify[6])
                {
                    if (query == "")
                    {
                        query += sModify[6];
                    }
                    else
                    {
                        query += ", " + sModify[6];
                    }
                }
                if (bModify[7])
                {
                    if (query == "")
                    {
                        query += sModify[7];
                    }
                    else
                    {
                        query += ", " + sModify[7];
                    }
                }
                if (query != "")
                {
                    string fullquery = "UPDATE Exam SET " + query + " Where ID=" + frmMainPage.idExam;
                    try
                    {                        
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(fullquery, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Düzəliş uğurla tamamlandı");
                        frmMainPage.examCreateOrModify = false;
                        this.Hide();
                        sqlconnect.close();
                        frmMainPage.idExam = -1;
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
        private void TxtExamNameModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtExamNameModify.Text != "")
                {
                    sModify[0] = "Name='" + txtExamNameModify.Text + "'";
                }
                else
                {
                    sModify[0] = "";
                }
                bModify[0] = true;
            }
        }
        private void TxtExamAddressModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtExamAddressModify.Text != "")
                {
                    sModify[1] = "Address='" + txtExamAddressModify.Text + "'";
                }
                else
                {
                    sModify[1] = "";
                }
                bModify[1] = true;
            }
        }
        private void TxtExamTestCountModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtExamTestCountModify.Text != "")
                {
                    sModify[2] = "Test_count='" + txtExamTestCountModify.Text + "'";
                }
                else
                {
                    sModify[2] = "";
                }
                bModify[2] = true;
            }
        }
        private void TxtExamPeriodModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtExamPeriodModify.Text != "")
                {
                    sModify[3] = "Period='" + txtExamPeriodModify.Text + "'";
                }
                else
                {
                    sModify[3] = "";
                }
                bModify[3] = true;
            }
        }
        private void TxtExamMinPointModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (txtExamMinPointModify.Text != "")
                {
                    sModify[4] = "Min_point='" + txtExamMinPointModify.Text + "'";
                }
                else
                {
                    sModify[4] = "";
                }
                bModify[4] = true;
            }
        }
        private void DttmExamDateModify_ValueChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (dttmExamDateModify.Value != DateTime.Now)
                {
                    sModify[5] = "Begin_date='" + dttmExamDateModify.Value + "'";
                }
                else
                {
                    sModify[5] = "";
                }
                bModify[5] = true;
            }
        }
        private void CmbbxExamTopicModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t)
            {
                sModify[6] = "Topic_ID=" + cmbbxExamTopicModify.SelectedValue+ "";
                bModify[6] = true;
            }
        }
        private void CmbbxExamGroupModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t)
            {
                sModify[7] = "Group_ID=" + cmbbxExamGroupModify.SelectedValue + "";
                bModify[7] = true;
            }
        }
        #endregion
    }
}


