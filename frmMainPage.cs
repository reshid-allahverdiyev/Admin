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
    public partial class frmMainPage : Form
    {        
        public frmMainPage()
        {
            InitializeComponent();
        }
        SqlConnect sqlconnect = new SqlConnect();
        GridViewDesignClass g = new GridViewDesignClass();

        #region regionMain
        private void FrmMainPage_Load(object sender, EventArgs e)
        {
            lblCurrentUserName.Text = frmAdminLogin.user_name;
            refreshCandidate();
            cleanCandidate();      
            //refreshGroup();  
            //refreshTopic(); 
            //refreshTest();
            //cleanTest();
            //refreshExam();
            //cleanExam();
            //refreshResult();
            //refreshUser();  
        }         
        private void FrmMainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void LblCurrentUserName_Click_1(object sender, EventArgs e)
        {
            cntxtmnstrpCurrentUsername.Show();
        }
        private void ÇıxışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminLogin frmAdminLogin = new frmAdminLogin();
            frmAdminLogin.Show();
        }
        private void TbCtrlMainPage_Click(object sender, EventArgs e)
        {
            switch (tbCtrlMainPage.SelectedTab.Name)
            {
                case "tbCandidate": refreshCandidate(); break;
                case "tbGroup": refreshGroup(); break;
                case "tbTopic": refreshTopic(); break;
                case "tbTest": refreshTest(); cleanTest(); break;
                case "tbExam": refreshExam(); cleanExam(); break;
                case "tbResult": refreshResult(); break;
                case "tbUser": refreshUser(); break;
            }
        }
        #endregion

        #region regionCandidate
        public static bool candidateCreateOrModify = false;
        public static int idCandidate = -1;
        private void refreshCandidate()
        {
            try
            {
                grdvwCandidate.Columns.Clear();
                string query = "Select * from Candidate";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwCandidate.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwCandidate);
                }
                else
                {
                    MessageBox.Show("Namizəd tapılmadı!");
                }

                sqlconnect.close();
                idCandidate = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cleanCandidate()
        {
            txtCandidateID.Text = "";
            txtCandidateName.Text = "";
            txtCandidateSurname.Text = "";
            dateCandidateBirthday.Value = DateTime.Now;
            txtCandidatePin.Text = "";
            txtCandidatePassword.Text = "";
            txtCandidatePassword.Text = "";
        }
        private void BtnCandidateRefresh_Click(object sender, EventArgs e)
        {
            refreshCandidate();
            cleanCandidate();
        }
        private void BtnCandidateSearch_Click(object sender, EventArgs e)
        {
            string query = "";

            if (txtCandidateID.Text != "")
            {
                query += "ID=" + Int32.Parse(txtCandidateID.Text);
            }

            if (txtCandidateName.Text != "")
            {
                if (query != "")
                {
                    query += " and Name='" + txtCandidateName.Text + "'";
                }
                else
                {
                    query += " Name='" + txtCandidateName.Text + "'";
                }
            }


            if (txtCandidateSurname.Text != "")
            {
                if (query != "")
                {
                    query += " and Surname='" + txtCandidateSurname.Text + "'";
                }
                else
                {
                    query += " Surname='" + txtCandidateSurname.Text + "'";
                }
            }
            ////if (query != "")
            ////{
            ////    query += " and Birthday='" + dateCandidateBirthday.Value + "'";
            ////}
            ////else
            ////{
            ////    query += " Birthday='" + dateCandidateBirthday.Value + "'";
            ////}

            if (txtCandidatePin.Text != "")
            {
                if (query != "")
                {
                    query += " and Pin='" + txtCandidatePin.Text + "'";
                }
                else
                {
                    query += " Pin='" + txtCandidatePin.Text + "'";
                }
            }


            string fullquery = "Select * from Candidate where " + query;
            if (query != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    if (dt.Rows.Count != 0)
                    {
                        grdvwCandidate.Columns.Clear();
                        grdvwCandidate.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwCandidate);
                    }
                    else
                    {
                        MessageBox.Show("Uyğun namizəd tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }          
        }
        private void BtnCandidateAdd_Click(object sender, EventArgs e)
        {
            candidateCreateOrModify = false;
            frmCandidateAdd frmCandidateAdd = new frmCandidateAdd();
            frmCandidateAdd.Text = "Yeni namizəd";
            frmCandidateAdd.ShowDialog();
        }
        private void BtnCandidateModify_Click(object sender, EventArgs e)
        {
            if (idCandidate != -1)
            {
                candidateCreateOrModify = true;
                frmCandidateAdd frmCandidateAdd = new frmCandidateAdd();
                frmCandidateAdd.Text = "Düzəliş";
                frmCandidateAdd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
        }
        private void BtnCandidateDelete_Click(object sender, EventArgs e)
        {
            if (idCandidate != -1)
            {
                string s = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (s == "Yes")
                {
                    string query = "Delete from Candidate Where ID=" + idCandidate;
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(query, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Silinmə uğurla tamamlandı");
                        refreshCandidate();
                        cleanCandidate();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
            idCandidate = -1;
        }
        private void GrdvwCandidate_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cleanCandidate();
            int index = e.RowIndex;
            DataGridViewRow row = grdvwCandidate.Rows[index];
            txtCandidateID.Text = row.Cells[0].Value.ToString();
            idCandidate = Int32.Parse(row.Cells[0].Value.ToString());
            txtCandidateName.Text = row.Cells[2].Value.ToString();
            txtCandidateSurname.Text = row.Cells[3].Value.ToString();
            dateCandidateBirthday.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
            txtCandidatePin.Text = row.Cells[5].Value.ToString();
            txtCandidatePassword.Text = row.Cells[6].Value.ToString();
            txtCandidatePassword.PasswordChar = '*';
        }
        private void GrdvwCandidate_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwCandidate.Rows.Count; i++)
            {
                grdvwCandidate.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }
        #endregion

        #region regionGroup
        public static bool groupCreateOrModify = false;
        public static int idGroup = -1, defultCandidateCount=0;
        private void refreshGroup()
        {
            try
            {
                grdvwGroup.Columns.Clear();
                string query = "Select * from Groups";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwGroup.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwGroup);
                }
                else
                {
                    MessageBox.Show("Qrup tapılmadı!");
                }

                sqlconnect.close();
                idGroup = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cleanGroup()
        {
            txtGroupID.Text = "";
            txtGroupName.Text = "";
            txtGroupCandidateCount.Text = "";
        }
        private void BtnGroupRefresh_Click(object sender, EventArgs e)
        {
            refreshGroup();
            cleanGroup();
        }
        private void BtnGroupSearch_Click(object sender, EventArgs e)
        {
            string query = "";
            if (txtGroupID.Text != "")
            {
                query += "ID=" + Int32.Parse(txtGroupID.Text);
            }

            if (txtGroupName.Text != "")
            {
                if (query != "")
                {
                    query += " and Name='" + txtGroupName.Text + "'";
                }
                else
                {
                    query += " Name='" + txtGroupName.Text + "'";
                }
            }


            if (txtGroupCandidateCount.Text != "")
            {
                if (query != "")
                {
                    query += " and Candidate_count=" + txtGroupCandidateCount.Text + "";
                }
                else
                {
                    query += " Candidate_count=" + txtGroupCandidateCount.Text + "";
                }
            }

            string fullquery = "Select * from Groups where " + query;
            if (query != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    if (dt.Rows.Count != 0)
                    {
                        grdvwGroup.Columns.Clear();
                        grdvwGroup.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwGroup);
                    }
                    else
                    {
                        MessageBox.Show("Uyğun qrup tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
        }
        private void BtnGroupAdd_Click(object sender, EventArgs e)
        {
            groupCreateOrModify = false;
            frmGroupAdd frmGroupAdd = new frmGroupAdd();
            frmGroupAdd.Text = "Yeni qrup";
            frmGroupAdd.ShowDialog();
        }
        private void BtnGroupDelete_Click(object sender, EventArgs e)
        {
            if (idGroup != -1)
            {
                string s = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (s == "Yes")
                {
                    string query = "Delete from Groups Where ID=" + idGroup;
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(query, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Silinmə uğurla tamamlandı");
                        refreshGroup();
                        cleanGroup();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
            idGroup = -1;
        }
        private void BtnGroupModify_Click(object sender, EventArgs e)
        {
            if (idGroup != -1)
            {
                groupCreateOrModify = true;
                frmGroupAdd frmGroupAdd = new frmGroupAdd();
                frmGroupAdd.Text = "Düzəliş";
                frmGroupAdd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
        }
        private void GrdvwGroup_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cleanGroup();
            int index = e.RowIndex;
            DataGridViewRow row = grdvwGroup.Rows[index];
            idGroup = Int32.Parse(row.Cells[0].Value.ToString());
            defultCandidateCount = Int32.Parse(row.Cells[3].Value.ToString());
            txtGroupID.Text = row.Cells[0].Value.ToString();
            txtGroupName.Text = row.Cells[2].Value.ToString();
            txtGroupCandidateCount.Text = row.Cells[3].Value.ToString();
        }
        private void GrdvwGroup_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwGroup.Rows.Count; i++)
            {
                grdvwGroup.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }
        #endregion

        #region regionTopic
        public static bool topicCreateOrModify = false;
        public static int idTopic= -1;
        private void refreshTopic()
        {
            try
            {
                grdvwTopic.Columns.Clear();
                string query = "Select * from Topic";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwTopic.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwTopic);
                }
                else
                {
                    MessageBox.Show("Mövzu tapılmadı!");
                }
                sqlconnect.close();
                idTopic = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cleanTopic()
        {
            txtTopicID.Text = "";
            txtTopicName.Text = "";          
        }
        private void BtnTopicSearch_Click(object sender, EventArgs e)
        {
            string query = "";
            if (txtTopicID.Text != "")
            {
                query += "ID=" + Int32.Parse(txtTopicID.Text);
            }

            if (txtTopicName.Text != "")
            {
                if (query != "")
                {
                    query += " and Name='" + txtTopicName.Text + "'";
                }
                else
                {
                    query += " Name='" + txtTopicName.Text + "'";
                }
            }        
            string fullquery = "Select * from Topic where " + query;
            if (query != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    if (dt.Rows.Count != 0)
                    {
                        grdvwTopic.Columns.Clear();
                        grdvwTopic.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwTopic);
                    }
                    else
                    {
                        MessageBox.Show("Uyğun mövzu tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
        }
        private void BtnTopicRefresh_Click(object sender, EventArgs e)
        {
            refreshTopic();
            cleanTopic();
        }
        private void BtnTopicAdd_Click(object sender, EventArgs e)
        {
            topicCreateOrModify = false;
            frmTopicAdd frmTopicAdd = new frmTopicAdd();
            frmTopicAdd.Text = "Yeni mövzu";
            frmTopicAdd.ShowDialog();
        }
        private void BtnTopicModify_Click(object sender, EventArgs e)
        {
            if (idTopic != -1)
            {
                topicCreateOrModify = true;
                frmTopicAdd frmTopicAdd = new frmTopicAdd();
                frmTopicAdd.Text = "Düzəliş";
                frmTopicAdd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
        }
        private void BtnTopicDelete_Click(object sender, EventArgs e)
        {
            if (idTopic != -1)
            {
                string s = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (s == "Yes")
                {
                    string query = "Delete from Topic Where ID=" + idTopic;
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(query, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Silinmə uğurla tamamlandı");
                        refreshTopic();
                        cleanTopic();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
            idTopic = -1;
        }
        private void GrdvwTopic_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cleanTopic();
            int index = e.RowIndex;
            DataGridViewRow row = grdvwTopic.Rows[index];
            idTopic = Int32.Parse(row.Cells[0].Value.ToString());
            txtTopicID.Text = row.Cells[0].Value.ToString();
            txtTopicName.Text = row.Cells[2].Value.ToString();           
        }
        private void GrdvwTopic_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwTopic.Rows.Count; i++)
            {
                grdvwTopic.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }
        #endregion

        #region regionTest
        public static bool testCreateOrModify = false;
        public static int idTest = -1;
        private void refreshTest()
        {
            comboboxTestTopicFill();        
            try
            {
                grdvwTest.Columns.Clear();
                string query = "Select * from Test";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwTest.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwTest);
                }
                else
                {
                    MessageBox.Show("Test tapılmadı!");
                }
                sqlconnect.close();
                idTest = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void comboboxTestTopicFill()
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
                cmbbxTestTopic.DataSource = ds.Tables[0];
                cmbbxTestTopic.DisplayMember = "Name";
                cmbbxTestTopic.ValueMember = "ID";                
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void cleanTest()
        {
            txtTestID.Text = "";
            rchtxtTestTitle.Text = "";
            rchtxtTestVariantA.Text = "";
            rchtxtTestVariantB.Text = "";
            rchtxtTestVariantC.Text = "";
            rchtxtTestVariantD.Text = "";
            rchtxtTestVariantE.Text = "";
            cmbbxTestTrueVariant.SelectedItem = null;
            cmbbxTestTrueVariant.Text = "Düzgün variantı seçin";
            cmbbxTestTopic.SelectedItem = null;
            cmbbxTestTopic.Text = "Testin mövzusunu seçin";
        }
        private void BtnTestRefresh_Click(object sender, EventArgs e)
        {
            refreshTest();
            cleanTest();
        }
        private void BtnTestSearch_Click(object sender, EventArgs e)
        {
            string query = "";
            if (txtTestID.Text != "")
            {
                query += "ID=" + Int32.Parse(txtTestID.Text);
            }
            if (rchtxtTestTitle.Text != "")
            {
                if (query != "")
                {
                    query += " and  Title='" + rchtxtTestTitle.Text + "'";
                }
                else
                {
                    query += " Title='" + rchtxtTestTitle.Text + "'";
                }
            }
            if (rchtxtTestVariantA.Text != "")
            {
                if (query != "")
                {
                    query += " and  Variant_A='" + rchtxtTestVariantA.Text + "'";
                }
                else
                {
                    query += " Variant_A='" + rchtxtTestVariantA.Text + "'";
                }
            }
            if (rchtxtTestVariantB.Text != "")
            {
                if (query != "")
                {
                    query += " and  Variant_B='" + rchtxtTestVariantB.Text + "'";
                }
                else
                {
                    query += " Variant_B='" + rchtxtTestVariantB.Text + "'";
                }
            }
            if (rchtxtTestVariantC.Text != "")
            {
                if (query != "")
                {
                    query += " and  Variant_C='" + rchtxtTestVariantC.Text + "'";
                }
                else
                {
                    query += " Variant_C='" + rchtxtTestVariantC.Text + "'";
                }
            }
            if (rchtxtTestVariantD.Text != "")
            {
                if (query != "")
                {
                    query += " and  Variant_D='" + rchtxtTestVariantD.Text + "'";
                }
                else
                {
                    query += " Variant_D='" + rchtxtTestVariantD.Text + "'";
                }
            }
            if (rchtxtTestVariantE.Text != "")
            {
                if (query != "")
                {
                    query += " and  Variant_E='" + rchtxtTestVariantE.Text + "'";
                }
                else
                {
                    query += " Variant_E='" + rchtxtTestVariantE.Text + "'";
                }
            }
            if (cmbbxTestTrueVariant.SelectedItem != null)
            {
                if (query != "")
                {
                    query += " and  True_variant='" + cmbbxTestTrueVariant.SelectedItem + "'";
                }
                else
                {
                    query += " True_variant='" + cmbbxTestTrueVariant.SelectedItem + "'";
                }
            }
            if (cmbbxTestTopic.SelectedItem != null)
            {
                if (query != "")
                {
                    query += " and  Topic_ID=" + cmbbxTestTopic.ValueMember;
                }
                else
                {
                    query += "  Topic_ID=" + cmbbxTestTopic.ValueMember;
                }
            }
            string fullquery = "Select * from Test where " + query;
            if (query != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    if (dt.Rows.Count != 0)
                    {
                        grdvwTest.Columns.Clear();
                        grdvwTest.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwTest);
                    }
                    else
                    {
                        MessageBox.Show("Uyğun Test tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
        }
        private void BtnTestDelete_Click(object sender, EventArgs e)
        {
            if (idTest != -1)
            {
                string s = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (s == "Yes")
                {
                    string query = "Delete from Test Where ID=" + idTest;
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(query, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Silinmə uğurla tamamlandı");
                        refreshTest();
                        cleanTest();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
            idTest = -1;
        }
        private void BtnTestAdd_Click(object sender, EventArgs e)
        {
            testCreateOrModify = false;
            frmTestAdd frmTestAdd = new frmTestAdd();
            frmTestAdd.Text = "Yeni test";
            frmTestAdd.ShowDialog();
        }
        private void BtnTestModify_Click(object sender, EventArgs e)
        {
            if (idTest != -1)
            {
                testCreateOrModify = true;
                frmTestAdd frmTestAdd = new frmTestAdd();
                frmTestAdd.Text = "Düzəliş";
                frmTestAdd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
        }       
        private void GrdvwTest_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cleanTest();
            int index = e.RowIndex;
            DataGridViewRow row = grdvwTest.Rows[index];
            idTest = Int32.Parse(row.Cells[0].Value.ToString());
            txtTestID.Text = row.Cells[0].Value.ToString();
            rchtxtTestTitle.Text= row.Cells[2].Value.ToString();
            rchtxtTestVariantA.Text= row.Cells[3].Value.ToString();
            rchtxtTestVariantB.Text = row.Cells[4].Value.ToString();
            rchtxtTestVariantC.Text = row.Cells[5].Value.ToString();
            rchtxtTestVariantD.Text = row.Cells[6].Value.ToString();
            rchtxtTestVariantE.Text = row.Cells[7].Value.ToString();
            cmbbxTestTrueVariant.Text= row.Cells[8].Value.ToString();
            cmbbxTestTopic.SelectedValue = Convert.ToInt32(row.Cells[9].Value.ToString());
        }
        private void GrdvwTest_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwTest.Rows.Count; i++)
            {
                grdvwTest.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }
        #endregion

        #region regionExam
        public static bool examCreateOrModify = false;
        public static int idExam = -1;
        private void refreshExam()
        {
            comboboxExamTopicFill();
            comboboxExamGroupFill();
            try
            {
                grdvwExam.Columns.Clear();
                string query = "Select * from Exam";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwExam.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwExam);
                }
                else
                {
                    MessageBox.Show("İmtahan tapılmadı!");
                }
                sqlconnect.close();
                idExam = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void comboboxExamTopicFill()
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
                cmbbxExamTopic.DataSource = ds.Tables[0];
                cmbbxExamTopic.DisplayMember = "Name";
                cmbbxExamTopic.ValueMember = "ID";
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void comboboxExamGroupFill()
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
                cmbbxExamGroup.DataSource = ds.Tables[0];
                cmbbxExamGroup.DisplayMember = "Name";
                cmbbxExamGroup.ValueMember = "ID";
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void cleanExam()
        {
            txtExamName.Text = "";
            txtExamAddress.Text = "";            
            txtExamTestCount.Text = "";
            txtExamPeriod.Text = "";
            txtExamMinPoint.Text = "";
            maskedTxtExamTime.Clear();
            dttmExamDate.Value =DateTime.Now;
            cmbbxExamTopic.SelectedItem = null;        
            cmbbxExamTopic.Text = "İmatahan mövzusu seçin";
            cmbbxExamGroup.SelectedItem = null;
            cmbbxExamGroup.Text = "Qrupu seçin";           
        }
        private void BtnExamRefresh_Click(object sender, EventArgs e)
        {
            refreshExam();
            cleanExam();
        }
        private void BtnExamSearch_Click(object sender, EventArgs e)
        {
            string query = "";
            if (txtExamName.Text != "")
            {
                if (query != "")
                {
                    query += " and  Name='" + txtExamName.Text + "'";
                }
                else
                {
                    query += " Name='" + txtExamName.Text + "'";
                }
            }
            if (txtExamAddress.Text != "")
            {
                if (query != "")
                {
                    query += " and  Address='" + txtExamAddress.Text + "'";
                }
                else
                {
                    query += " Address='" + txtExamAddress.Text + "'";
                }
            }
            if (txtExamTestCount.Text != "")
            {
                if (query != "")
                {
                    query += " and  Test_count='" + txtExamTestCount.Text + "'";
                }
                else
                {
                    query += " Test_count='" + txtExamTestCount.Text + "'";
                }
            }
            if (txtExamPeriod.Text != "")
            {
                if (query != "")
                {
                    query += " and  Period='" + txtExamPeriod.Text + "'";
                }
                else
                {
                    query += " Period='" + txtExamPeriod.Text + "'";
                }
            }
            if (txtExamMinPoint.Text != "")
            {
                if (query != "")
                {
                    query += " and  Min_point='" + txtExamMinPoint.Text + "'";
                }
                else
                {
                    query += " Min_point='" + txtExamMinPoint.Text + "'";
                }
            }
            //if (dttmExamDate.Value.ToString() != DateTime.Now.ToString())
            //{
            //    if (query != "")  
            //    {
            //        query += " and  Begin_date='" + dttmExamDate.Value.ToString() + "'";
            //    }
            //    else
            //    {
            //        query += " Begin_date='" + dttmExamDate.Value.ToString() + "'";
            //    }
            //}
            if (cmbbxExamTopic.SelectedItem != null)
            {
                if (query != "")
                {
                    query += " and  Topic_ID=" + cmbbxExamTopic.ValueMember;
                }
                else
                {
                    query += "  Topic_ID=" + cmbbxExamTopic.ValueMember;
                }
            }
            if (cmbbxExamGroup.SelectedItem != null)
            {
                if (query != "")
                {
                    query += " and  Group_ID=" + cmbbxExamGroup.ValueMember;
                }
                else
                {
                    query += "  Group_ID=" + cmbbxExamGroup.ValueMember;
                }
            }
            string fullquery = "Select * from Exam where " + query;
            if (query != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    if (dt.Rows.Count != 0)
                    {
                        grdvwExam.Columns.Clear();
                        grdvwExam.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwExam);
                    }
                    else
                    {
                        MessageBox.Show("Uyğun İmtahan tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
        }
        private void BtnExamDelete_Click(object sender, EventArgs e)
        {
            if (idExam != -1)
            {
                string s = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (s == "Yes")
                {
                    string query = "Delete from Exam Where ID=" + idExam;
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(query, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Silinmə uğurla tamamlandı");
                        refreshExam();
                        cleanExam();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
            idExam = -1;
        }
        private void BtnExamAdd_Click(object sender, EventArgs e)
        {
            examCreateOrModify = false;
            frmExamAdd frmExamAdd = new frmExamAdd();
            frmExamAdd.Text = "Yeni İmtahan";
            frmExamAdd.ShowDialog();
        }
        private void BtnExamModify_Click(object sender, EventArgs e)
        {
            if (idExam != -1)
            {
                examCreateOrModify = true;
                frmExamAdd frmExamAdd = new frmExamAdd();
                frmExamAdd.Text = "Düzəliş";
                frmExamAdd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
        }
        private void GrdvwExam_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwExam.Rows.Count; i++)
            {
                grdvwExam.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }
        private void GrdvwExam_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cleanExam();
            int index = e.RowIndex;
            DataGridViewRow row = grdvwExam.Rows[index];
            idExam = Int32.Parse(row.Cells[0].Value.ToString());
            txtExamName.Text = row.Cells[2].Value.ToString();
            txtExamAddress.Text= row.Cells[3].Value.ToString();
            txtExamTestCount.Text = row.Cells[4].Value.ToString();
            txtExamPeriod.Text= row.Cells[5].Value.ToString();
            txtExamMinPoint.Text = row.Cells[6].Value.ToString();
            dttmExamDate.Value= Convert.ToDateTime(row.Cells[7].Value.ToString());
            maskedTxtExamTime.Text =row.Cells[8].Value.ToString();
            cmbbxExamTopic.Text= row.Cells[8].Value.ToString();
            cmbbxExamGroup.Text= row.Cells[9].Value.ToString();  
        }
        #endregion

        #region regionUser
        public static bool userCreateOrModify = false;
        public static int idUser = -1;
        private void refreshUser()
        {
            try
            {
                grdvwUser.Columns.Clear();
                string query = "Select * from Users";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwUser.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwUser);
                }
                else
                {
                    MessageBox.Show("İstifadəçi tapılmadı!");
                }
                sqlconnect.close();
                idUser = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cleanUser()
        {     
            txtUserName.Text = "";        
            txtUserUsername.Text = "";
            dttmUserBirthday.Value = DateTime.Now;
            txtUserPin.Text = "";
            txtUserPassword.Text = "";
            txtUserUsername.Text = "";
        }
        private void BtnUserRefresh_Click(object sender, EventArgs e)
        {
            refreshUser();
            cleanUser();
        }
        private void BtnUserSearch_Click(object sender, EventArgs e)
        {
            string query = "";

            if (txtUserName.Text != "")
            {
                query += "Name='" + txtUserName.Text+"'";
            }

            if (txtUserSurname.Text != "")
            {
                if (query != "")
                {
                    query += " and Surname='" + txtUserSurname.Text + "'";
                }
                else
                {
                    query += " Surname='" + txtUserSurname.Text + "'";
                }
            }
            ////if (query != "")
            ////{
            ////    query += " and Birthday='" + dttmUserBirthday.Value + "'";
            ////}
            ////else
            ////{
            ////    query += " Birthday='" + dttmUserBirthday.Value + "'";
            ////}

            if (txtUserPin.Text != "")
            {
                if (query != "")
                {
                    query += " and Pin='" + txtUserPin.Text + "'";
                }
                else
                {
                    query += " Pin='" + txtUserPin.Text + "'";
                }
            }
            if (txtUserUsername.Text != "")
            {
                if (query != "")
                {
                    query += " and Username='" + txtUserUsername.Text + "'";
                }
                else
                {
                    query += " Username='" + txtUserUsername.Text + "'";
                }
            }
            string fullquery = "Select * from Users where " + query;
            if (query != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    if (dt.Rows.Count != 0)
                    {
                        grdvwUser.Columns.Clear();
                        grdvwUser.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwUser);
                    }
                    else
                    {
                        MessageBox.Show("Uyğun istifadəçi tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
        }
        private void BtnUserDelete_Click(object sender, EventArgs e)
        {
            if (idUser != -1)
            {
                string s = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (s == "Yes")
                {
                    string query = "Delete from Users Where ID=" + idUser;
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(query, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Silinmə uğurla tamamlandı");
                        refreshUser();
                        cleanUser();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
            idCandidate = -1;
        }
        private void BtnUserAdd_Click(object sender, EventArgs e)
        {
            userCreateOrModify = false;
            frmUserAdd frmUserAdd = new frmUserAdd();
            frmUserAdd.Text = "Yeni istifadəçi";
            frmUserAdd.ShowDialog();
        }
        private void BtnUserModify_Click(object sender, EventArgs e)
        {
            if (idUser != -1)
            {
                userCreateOrModify = true;
                frmUserAdd frmUserAdd = new frmUserAdd();
                frmUserAdd.Text = "Düzəliş";
                frmUserAdd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
        }
        private void GrdvwUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cleanUser();
            int index = e.RowIndex;
            DataGridViewRow row = grdvwUser.Rows[index];            
            idUser = Int32.Parse(row.Cells[0].Value.ToString());
            txtUserName.Text = row.Cells[2].Value.ToString();
            txtUserSurname.Text = row.Cells[3].Value.ToString();
            dttmUserBirthday.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
            txtUserPin.Text = row.Cells[5].Value.ToString();
            txtUserUsername.Text = row.Cells[6].Value.ToString();
            txtUserPassword.Text = row.Cells[6].Value.ToString();
            txtUserPassword.PasswordChar = '*';
        }
        private void GrdvwUser_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwUser.Rows.Count; i++)
            {
                grdvwUser.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }

        #endregion

        #region regionGroupCnadidate
        private void BtnGroupAddCandidate_Click(object sender, EventArgs e)
        {
            if (idGroup != -1)
            {
                frmGroupAddCandidate frmGroupAddCandidate = new frmGroupAddCandidate();
                frmGroupAddCandidate.ShowDialog();
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
        }
        #endregion

        #region regionResult
        private void refreshResult()
        {
            comboboxResultGroupFill();
            comboboxResultTopicFill();
            cleanResult();
            try
            {
                grdvwResult.Columns.Clear();
                //string query = "Select * from Result";
                string query = @"Select ID, Exam_name as 'İmtahanın adı', Name+' '+Surname+'-- Pin: '+Pin as  'Namizəd',
                                Point as 'Topladığı bal', 
                                case
                                   when Passed=1 then 'keçib'
                                   else 'keçməyib'  
                                end  'Nəticə'  
                                from Result";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwResult.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwResult);
                }
                else
                {
                    MessageBox.Show("Nəticə tapılmadı!");
                }
                sqlconnect.close();             
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void comboboxResultTopicFill()
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
                cmbbxResultTopic.DataSource = ds.Tables[0];
                cmbbxResultTopic.DisplayMember = "Name";
                cmbbxResultTopic.ValueMember = "ID";
                sqlconnect.close();             
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void comboboxResultGroupFill()
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
                cmbbxResultGroup.DataSource = ds.Tables[0];
                cmbbxResultGroup.DisplayMember = "Name";
                cmbbxResultGroup.ValueMember = "ID";
                sqlconnect.close();                
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void cleanResult()
        {
            txtResultAddress.Text = "";
            txtResultCandName.Text = "";
            txtResultCandSurname.Text = "";
            txtResultExamName.Text = "";
            txtResultCandPin.Text = "";
            dttmResultExamDate.Value = DateTime.Now;
            cmbbxResultTopic.SelectedItem = null;
            cmbbxResultTopic.Text = "İmatahan mövzusu seçin";
            cmbbxResultGroup.SelectedItem = null;
            cmbbxResultGroup.Text = "Qrupu seçin";           
            txtExamMinPoint.Text = "";
            dttmExamDate.Value = DateTime.Now;

            grpbxResultYesNo.Enabled = true;           
            grpbxResultPassed.Enabled = false;
            rdbtnResultYes.Checked = true;
            rdbtnResultEventNo.Checked = false;
            rdbtnResultEventYes.Checked = false;
            rdbtnResultPassedNo.Checked = false;
            rdbtnResultPassedYes.Checked = false;         
        }
        private void RdbtnResultYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnResultYes.Checked)
            {
                grpbxResultEvent.Enabled = true;
            }
            else
            {
                grpbxResultEvent.Enabled = false;
            }
        }
        private void RdbtnResultNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnResultNo.Checked)
            {
                rdbtnResultEventNo.Checked = false;
                rdbtnResultEventYes.Checked = false;
                rdbtnResultPassedNo.Checked = false;
                rdbtnResultPassedYes.Checked = false;
                grpbxResultEvent.Enabled = false;  
                grpbxResultPassed.Enabled = false;
                            
            }
            else
            {
                grpbxResultEvent.Enabled = true;
            }
        }
        private void RdbtnResultEventYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnResultEventYes.Checked)
            {
                grpbxResultPassed.Enabled = true;
            }
            else
            {
                grpbxResultPassed.Enabled = false;
            }
        }
        private void RdbtnResultEventNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnResultEventNo.Checked)
            {               
                grpbxResultPassed.Enabled = false;                 
                rdbtnResultPassedNo.Checked = false;
                rdbtnResultPassedYes.Checked = false;
            }
            else
            {
                grpbxResultEvent.Enabled = true;
            }
        }
        private void BtnResultsRefresh_Click(object sender, EventArgs e)
        {
            refreshResult();
        }
        private void BtnResultSearch_Click(object sender, EventArgs e)
        {
            string  eventS = "";
            if (rdbtnResultEventYes.Checked)
            {
                eventS = " Event=1 ";
            }
            if (rdbtnResultEventNo.Checked)
            {
                eventS = " Event=0 ";  
            }
            //MessageBox.Show(eventS);
            string passedS = "";
            if (rdbtnResultPassedYes.Checked)
            {
                passedS = " Passed=1 ";
            }
            if (rdbtnResultPassedNo.Checked)
            {
                passedS = " Passed=0 ";
            }

            string queryC = "";
            if (txtResultCandName.Text!="")
            {
                queryC += " Name='" + txtResultCandName.Text + "'";
            }
            if (txtResultCandSurname.Text!="")
            {
                if (queryC!="")
                {
                    queryC += " and Surname='" + txtResultCandSurname.Text + "'";
                }
                else
                {
                    queryC += " Surname='" + txtResultCandSurname.Text + "'";
                }
            }
            if (txtResultCandPin.Text != "")
            {
                if (queryC != "")
                {
                    queryC += " and Pin='" + txtResultCandPin.Text+"'";
                }
                else
                {
                    queryC += " Pin='" + txtResultCandPin.Text+"'";
                }
            }
            if (queryC!="")
            {
                queryC = " Candidate_ID in  (select ID from Candidate where " + queryC + " )";
            }

            string queryE = "";
            if (txtResultExamName.Text!="")
            {
                queryE += " Name='" + txtResultExamName.Text + "'";
            }
            if (txtResultAddress.Text != "")
            {
                if (queryE!="")
                {
                    queryE += " and Address='" + txtResultAddress.Text + "'";
                }
                else
                {
                    queryE += " Address='" + txtResultAddress.Text + "'";
                }
            }
            //if (dttmExamDate.Value !=DateTime.Now)
            //{
            //    if (queryE != "")
            //    {
            //        queryE += " and Begin_date='" + dttmExamDate.Value.ToString()+ "'";
            //    }
            //    else
            //    {
            //        queryE += " Begin_date='" + dttmExamDate.Value.ToString() + "'";
            //    }
            //}
            if (cmbbxResultGroup.SelectedValue!=null)
            {
                if (queryE!="")
                {
                    queryE += " and Group_ID=" + cmbbxResultGroup.SelectedValue;
                }
                else
                {
                    queryE += " Group_ID=" + cmbbxResultGroup.SelectedValue;
                }
            }
            if (cmbbxResultTopic.SelectedValue !=null)
            {
                if (queryE != "")
                {
                    queryE += " and Topic_ID=" + cmbbxResultTopic.SelectedValue;
                }
                else
                {
                    queryE += " Topic_ID=" + cmbbxResultTopic.SelectedValue;
                }
            }
            if (queryE!="")
            {
                queryE = " Exam_ID in (select ID from Exam  where " + queryE + " )"; 
            }

           // MessageBox.Show(queryC);
           // MessageBox.Show(queryE);
            string queryEC = "";
            if (queryE!="")
            {
                queryEC += queryE;
            }
            if (queryC!="")
            {
                if (queryEC!="")
                {
                    queryEC += " and " + queryC;
                }
                else
                {
                    queryEC += queryC;
                }
            }
            //MessageBox.Show(queryEC);
            if (eventS!="")
            {
                if (queryEC!="")
                {
                    queryEC += " and " + eventS; 
                }
                else
                {
                    queryEC += eventS; 
                }  
            }
          //  MessageBox.Show(queryEC);
            if (queryEC !="")
            {
                queryEC = " Exam_process_ID in   (select ID from Exam_process  where " + queryEC + " )";
            }
            //MessageBox.Show(queryEC);
            string fullquery = "";
            if (passedS!="")
            {
                if (queryEC!="")
                {
                    queryEC += " and " + passedS;
                }
                else
                {
                    queryEC += passedS;
                }
            }
           // MessageBox.Show(fullquery);
            if (queryEC!="")
            {
                fullquery = @"Select ID, Exam_name as 'İmtahanın adı', Name + ' ' + Surname + '-- Pin: ' + Pin as  'Namizəd',
                                Point as 'Topladığı bal', 
                                case
                                   when Passed = 1 then 'keçib'
                                   else 'keçməyib'
                                end  'Nəticə'
                                from Result where"+ queryEC;
            }
            else
            {
                fullquery = @"Select ID, Exam_name as 'İmtahanın adı', Name + ' ' + Surname + '-- Pin: ' + Pin as  'Namizəd',
                                Point as 'Topladığı bal', 
                                case
                                   when Passed = 1 then 'keçib'
                                   else 'keçməyib'
                                end  'Nəticə'
                                from Result";
            }
            //MessageBox.Show(fullquery);           
            //try
            //{
                grdvwResult.Columns.Clear();                
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(fullquery, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwResult.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwResult);
                }
                else
                {
                    MessageBox.Show("Nəticə tapılmadı!");
                }
                sqlconnect.close();               
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            //}
        }

        private void RchtxtTestVariantE_TextChanged(object sender, EventArgs e)
        {

        }

        private void RchtxtTestVariantD_TextChanged(object sender, EventArgs e)
        {

        }

        private void RchtxtTestVariantC_TextChanged(object sender, EventArgs e)
        {

        }

        private void RchtxtTestVariantB_TextChanged(object sender, EventArgs e)
        {

        }

        private void RchtxtTestTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblTestVariantE_Click(object sender, EventArgs e)
        {

        }

        private void LblTestVariantD_Click(object sender, EventArgs e)
        {

        }

        private void LblTestVariantC_Click(object sender, EventArgs e)
        {

        }

        private void LblTestVariantB_Click(object sender, EventArgs e)
        {

        }

        private void LblTestVariantA_Click(object sender, EventArgs e)
        {

        }

        private void RchtxtTestVariantA_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblExamTime_Click(object sender, EventArgs e)
        {

        }

        private void GrdvwResult_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwResult.Rows.Count; i++)
            {
                grdvwResult.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }
        #endregion
    }
}



