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
  public partial class FormPictureParameters : Form
  {
    FormMain F;
    public FormPictureParameters(FormMain F)
    {
      InitializeComponent();
      this.F = F;
      cBox_AddGrid.Checked = F.DrawGrid;
      cBox_AddXAxis.Checked = F.AddXAxis;
      cBox_AddYAxis.Checked = F.AddYAxis;
      cBox_DrawLimit.Checked = F.DrawLimit;
      cBox_DrawFilling.Checked = F.DrawFilling;
      tBox_NumOfGridLines.Text = F.NGridLines.ToString();
      tBox_GridLinesThickness.Text = F.GridLinesThickness.ToString();
    }

    private void btn_ApplyPictureParameteres_Click(object sender, EventArgs e)
    {
      F.DrawGrid = cBox_AddGrid.Checked;
      F.AddXAxis = cBox_AddXAxis.Checked;
      F.AddYAxis = cBox_AddYAxis.Checked;
      F.DrawLimit = cBox_DrawLimit.Checked;
      F.DrawFilling = cBox_DrawFilling.Checked;
      F.NGridLines = int.Parse(tBox_NumOfGridLines.Text);
      F.GridLinesThickness = int.Parse(tBox_GridLinesThickness.Text);
    }
  }
}
