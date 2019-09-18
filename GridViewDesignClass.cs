using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    class GridViewDesignClass
    {
        public void GridViewDesign(int count, DataGridView dg)
        {
            dg.Columns[0].Visible = false;            
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Name = "ID";
            column.HeaderText = "№";
            column.Width = 50;
            dg.Columns.Insert(1, column);

            for (int i = 0; i < count; i++)
            {
                dg.Rows[i].Cells[1].Value = (i + 1).ToString();
               // dg.Rows[i].Height = 30;
            }
            dg.Columns[1].Width = 50;
        }

        public string GridViewRow(DataGridView dg)
        {
            return dg.SelectedRows.ToString();           
        }

    }
}
