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
    public partial class frmTestAdd : Form
    {
        public frmTestAdd()
        {
            InitializeComponent();
        }
        SqlConnect sqlconnect = new SqlConnect();
        private void FrmTestAdd_Load(object sender, EventArgs e)
        {
            if (!frmMainPage.testCreateOrModify)
            {
                pnlTestModify.Visible = false;
                pnlTestAdd.Visible = true;
                FillTestAdd();
            }
            else
            {                
                pnlTestAdd.Visible = false;
                pnlTestModify.Visible = true;
                for (int i = 0; i < 8; i++)
                {
                    sModify[i] = "";
                    bModify[i] = false;
                }
                FillcmbbxTestModify();
                FillTestModify();
            }
            t = true;
        }

        #region regionTestAdd
        private void FillTestAdd()
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
                cmbbxTestTopicAdd.DataSource = ds.Tables[0];
                cmbbxTestTopicAdd.DisplayMember = "Name";
                cmbbxTestTopicAdd.ValueMember = "ID";              
                cmbbxTestTrueVariantAdd.Text = "Düzgün variantı seçin";
                cmbbxTestTrueVariantAdd.SelectedItem = null;
                cmbbxTestTopicAdd.SelectedItem = null;
                cmbbxTestTopicAdd.Text = "Testin mövzusunu seçin";
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void BtnTestAddCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BtnTestAddApply_Click(object sender, EventArgs e)
        {            
            if (rchtxtTestTitleAdd.Text == "")
            {
                MessageBox.Show("Testin şərtini daxil edin!!!");
                return;
            }
            if (rchtxtTestVariantAAdd.Text == "")
            {
                MessageBox.Show("Variant_A sahəsi boşdur!!!");
                return;
            }
            if (rchtxtTestVariantBAdd.Text == "")
            {
                MessageBox.Show("Variant_B sahəsi boşdur!!!");
                return;
            }
            if (rchtxtTestVariantCAdd.Text == "")
            {
                MessageBox.Show("Variant_C sahəsi boşdur!!!");
                return;
            }
            if (rchtxtTestVariantDAdd.Text == "")
            {
                MessageBox.Show("Variant_D sahəsi boşdur!!!");
                return;
            }
            if (rchtxtTestVariantEAdd.Text == "")
            {
                MessageBox.Show("Variant_E sahəsi boşdur!!!");
                return;
            }
            if (cmbbxTestTrueVariantAdd.SelectedItem==null)
            {
                MessageBox.Show("Düzgün variantı seçin!!!");
                return;
            }
            if (cmbbxTestTopicAdd.SelectedItem == null)
            {
                MessageBox.Show("Mövzunu seçin!!!");
                return;
            }
            //try
            //{
                string query = "insert into Test values(@Title,@Variant_A,@Variant_B,@Variant_C,@Variant_D,@Variant_E,@True_variant,@Topic_ID)";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@Title", rchtxtTestTitleAdd.Text);
                cmd.Parameters.AddWithValue("@Variant_A", rchtxtTestVariantAAdd.Text);
                cmd.Parameters.AddWithValue("@Variant_B", rchtxtTestVariantBAdd.Text);
                cmd.Parameters.AddWithValue("@Variant_C", rchtxtTestVariantCAdd.Text);
                cmd.Parameters.AddWithValue("@Variant_D", rchtxtTestVariantDAdd.Text);
                cmd.Parameters.AddWithValue("@Variant_E", rchtxtTestVariantEAdd.Text);
                cmd.Parameters.AddWithValue("@True_variant", cmbbxTestTrueVariantAdd.SelectedItem);
                cmd.Parameters.AddWithValue("@Topic_ID", cmbbxTestTopicAdd.SelectedValue);

                cmd.ExecuteNonQuery();
                sqlconnect.close();
                MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
                frmMainPage.groupCreateOrModify = false;
                this.Hide();
                frmMainPage.idGroup = -1;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            //}
        }
        #endregion

        #region regionTestModify
        string[] sModify = new string[8];
        bool[] bModify = new bool[8];
        bool t = false;
        private void FillTestModify()
        {
            try
            {
                string query = "Select * from Test where ID=" + frmMainPage.idTest;
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    rchtxtTestTitleModify.Text = dt.Rows[0][1].ToString();
                    rchTestVariantAModify.Text = dt.Rows[0][2].ToString();
                    rchTestVariantBModify.Text = dt.Rows[0][3].ToString();
                    rchTestVariantCModify.Text = dt.Rows[0][4].ToString();
                    rchTestVariantDModify.Text = dt.Rows[0][5].ToString();
                    rchTestVariantEModify.Text = dt.Rows[0][6].ToString();
                    cmbbxTestTrueVariantModify.Text= dt.Rows[0][7].ToString();
                    cmbbxlTestTopicModify.SelectedValue= Convert.ToInt32(dt.Rows[0][8].ToString());
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
        private void FillcmbbxTestModify()
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
                cmbbxlTestTopicModify.DataSource = ds.Tables[0];
                cmbbxlTestTopicModify.DisplayMember = "Name";
                cmbbxlTestTopicModify.ValueMember = "ID";
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void BtnTestModifyApply_Click(object sender, EventArgs e)
        {
            string s = MessageBox.Show("Məlumata düzəliş edilməsinə əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (s == "Yes")
            {
                string query = "";
                if (bModify[0])
                {
                    if (sModify[0] == "")
                    {
                        MessageBox.Show("Testin şərti boşdur!!!");
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
                        MessageBox.Show("Variant A  boşdur!!!");
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
                        MessageBox.Show("Variant B  boşdur!!!");
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
                        MessageBox.Show("Variant C boşdur!!!");
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
                        MessageBox.Show("Variant D  boşdur!!!");
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
                        MessageBox.Show("Variant E  boşdur!!!");
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
                    string fullquery = "UPDATE Test SET " + query + " Where ID=" + frmMainPage.idTest;
                    try
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(fullquery, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Düzəliş uğurla tamamlandı");
                        frmMainPage.testCreateOrModify = false;
                        this.Hide();
                        sqlconnect.close();
                        frmMainPage.idTest = -1;
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
        private void BtnTestModifyCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void RchtxtTestTitleModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (rchtxtTestTitleModify.Text != "")
                {
                    sModify[0] = "Title='" + rchtxtTestTitleModify.Text + "'";
                }
                else
                {
                    sModify[0] = "";
                }
                bModify[0] = true;
            }
        }
        private void RchTestVariantAModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (rchTestVariantAModify.Text != "")
                {
                    sModify[1] = "Variant_A='" + rchTestVariantAModify.Text + "'";
                }
                else
                {
                    sModify[1] = "";
                }
                bModify[1] = true;
            }
        }
        private void RchTestVariantBModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (rchTestVariantBModify.Text != "")
                {
                    sModify[2] = "Variant_B='" + rchTestVariantBModify.Text + "'";
                }
                else
                {
                    sModify[2] = "";
                }
                bModify[2] = true;
            }
        }
        private void RchTestVariantCModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (rchTestVariantCModify.Text != "")
                {
                    sModify[3] = "Variant_C='" + rchTestVariantCModify.Text + "'";
                }
                else
                {
                    sModify[3] = "";
                }
                bModify[3] = true;
            }
        }
        private void RchTestVariantDModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (rchTestVariantDModify.Text != "")
                {
                    sModify[4] = "Variant_D='" + rchTestVariantDModify.Text + "'";
                }
                else
                {
                    sModify[4] = "";
                }
                bModify[4] = true;
            }
        }
        private void RchTestVariantEModify_TextChanged(object sender, EventArgs e)
        {
            if (t)
            {
                if (rchTestVariantEModify.Text != "")
                {
                    sModify[5] = "Variant_E='" + rchTestVariantEModify.Text + "'";
                }
                else
                {
                    sModify[5] = "";
                }
                bModify[5] = true;
            }
        }
        private void CmbbxTestTrueVariantModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t)
            {
                sModify[6] = "True_variant='" + cmbbxTestTrueVariantModify.SelectedItem + "'";                
                bModify[6] = true;
            }
        }
        private void CmbbxlTestTopicModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t)
            {
                sModify[7] = "Topic_ID=" + cmbbxlTestTopicModify.SelectedValue;
                bModify[7] = true;
            }
        }
        #endregion
    }
}
