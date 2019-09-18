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
    public partial class frmGroupAddCandidate : Form
    {
        public frmGroupAddCandidate()
        {
            InitializeComponent();
        }
        SqlConnect sqlconnect = new SqlConnect();
        Dictionary<int, string> groupCandidate = new Dictionary<int, string>();
        List<int> lstcandidateIdDefult = new List<int>();
        List<int> lstcandidateId = new List<int>();
        int currentCandidateCount = 0;
        bool t = false;
        private void FrmGroupAddCandidate_Load(object sender, EventArgs e)
        {
            lstcandidateIdDefult.Clear();
            lstcandidateId.Clear();
            try
            {               
                string query = @"Select ID, 
                                  surname+'  '+name+'  --  Pin: '+pin  as candidate_info,
                                    CASE
                                        when c.ID in (select candidate_ID from Group_Candidate where Group_ID = @Group_ID) then 1
                                        else 0
                                    END in_out
                                from Candidate as c";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("Group_ID", frmMainPage.idGroup);
                SqlDataReader rd = cmd.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    groupCandidate.Add(Convert.ToInt32(rd[0].ToString()), rd[1].ToString());
                    chckdlstbxCandidateGroup.Items.Add(rd[1].ToString());
                    if (rd[2].ToString() == "1")
                    {
                        chckdlstbxCandidateGroup.SetItemChecked(i, true);
                        lstcandidateIdDefult.Add(Convert.ToInt32(rd[0].ToString()));
                        lstcandidateId.Add(Convert.ToInt32(rd[0].ToString()));
                        currentCandidateCount++; 
                    }
                    i++;
                }
                sqlconnect.close(); 
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
            t = true;
        }
        private void ChckdlstCandidateGroup_ItemCheck(object sender, ItemCheckEventArgs e)
        {            
            if (t)
            {
                if (!chckdlstbxCandidateGroup.GetItemChecked(chckdlstbxCandidateGroup.SelectedIndex))
                {                   
                    if (currentCandidateCount+1<=frmMainPage.defultCandidateCount)
                    {
                        lstcandidateId.Add(groupCandidate.First(y => y.Value == chckdlstbxCandidateGroup.SelectedItem.ToString()).Key);
                        currentCandidateCount++;
                    }
                    else
                    {
                        MessageBox.Show("Bu qrupda ən çoxu " + frmMainPage.defultCandidateCount + " nəfər namizəd ola bilər!!!");
                        MessageBox.Show(chckdlstbxCandidateGroup.SelectedIndex.ToString());
                        chckdlstbxCandidateGroup.SetItemChecked(chckdlstbxCandidateGroup.SelectedIndex, false);                        
                    }
                }
                else
                {
                    lstcandidateId.Remove(groupCandidate.First(y => y.Value == chckdlstbxCandidateGroup.SelectedItem.ToString()).Key);
                    currentCandidateCount--;
                }
            }
        }
        private void BtnGroupAddCandidate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstcandidateIdDefult.Count;)
                {
                    if (lstcandidateId.Contains(lstcandidateIdDefult.ElementAt(i)))
                        {
                            lstcandidateId.Remove(lstcandidateIdDefult.ElementAt(i));
                            lstcandidateIdDefult.Remove(lstcandidateIdDefult.ElementAt(i));
                    }
                    else
                    {
                        i++;
                    }
                }         
            foreach (int id in lstcandidateId)
            {
                try
                {
                    string query = "insert into Group_Candidate values(@Group_ID,@Candidate_ID)";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(query, sqlconnect.connect());
                    cmd.Parameters.AddWithValue("@Group_ID", frmMainPage.idGroup);
                    cmd.Parameters.AddWithValue("@Candidate_ID", id);
                    cmd.ExecuteNonQuery();
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            foreach (var idD in lstcandidateIdDefult)
            {
                try
                {
                    string query = "Delete from  Group_Candidate  Where Group_ID=@Group_ID and Candidate_ID=@Candidate_ID";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(query, sqlconnect.connect());
                    cmd.Parameters.AddWithValue("@Group_ID", frmMainPage.idGroup);
                    cmd.Parameters.AddWithValue("@Candidate_ID", idD);
                    cmd.ExecuteNonQuery();
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
            frmMainPage.idGroup = -1;
            this.Hide();
        }
    }
}
