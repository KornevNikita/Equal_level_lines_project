using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Equal_level_lines_UI
{
  public partial class FormVariables : Form
  {
    FormMain form1;
    public FormVariables(FormMain form1)
    {
      InitializeComponent();
      this.form1 = form1;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      form1.NumOfFixedVariables = 0;
      for (int i = 0; i < dataGridView1.RowCount; i++)
      {
        form1.TheTaskVariables[i].Fixed = bool.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
        if (form1.TheTaskVariables[i].Fixed == true)
          form1.NumOfFixedVariables++;
        form1.TheTaskVariables[i].Value = double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
        form1.TheTaskVariables[i].Min = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
        form1.TheTaskVariables[i].Max = double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
      }
      form1.CurrentTaskDim = form1.TaskDim - form1.NumOfFixedVariables;
      form1.tBox_CurrentTaskDim.Text = form1.CurrentTaskDim.ToString();
      this.Close();
    }
  }
}
