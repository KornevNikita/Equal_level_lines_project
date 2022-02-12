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
  public partial class FormLinesParameters : Form
  {
    FormMain F;
    public FormLinesParameters(FormMain F)
    {
      InitializeComponent();
      this.F = F;
      dataGridView1.Rows.Add(F.N, F.M1, F.M2, F.M3);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      F.N = int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
      F.M1 = int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
      F.M2 = int.Parse(dataGridView1.Rows[0].Cells[2].Value.ToString());
      F.M3 = int.Parse(dataGridView1.Rows[0].Cells[3].Value.ToString());
      this.Close();
    }
  }
}
