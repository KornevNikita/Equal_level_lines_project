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
  public partial class FormFunctionsParameters : Form
  {
    FormMain F;
    public FormFunctionsParameters(FormMain F)
    {
      InitializeComponent();
      this.F = F;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
