
namespace Equal_level_lines_UI
{
  partial class FormPictureParameters
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.cBox_AddGrid = new System.Windows.Forms.CheckBox();
      this.cBox_AddXAxis = new System.Windows.Forms.CheckBox();
      this.cBox_AddYAxis = new System.Windows.Forms.CheckBox();
      this.tBox_GridLinesThickness = new System.Windows.Forms.TextBox();
      this.tBox_NumOfGridLines = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.btn_ApplyPictureParameteres = new System.Windows.Forms.Button();
      this.cBox_DrawLimit = new System.Windows.Forms.CheckBox();
      this.cBox_DrawFilling = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // cBox_AddGrid
      // 
      this.cBox_AddGrid.AutoSize = true;
      this.cBox_AddGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.cBox_AddGrid.Location = new System.Drawing.Point(12, 12);
      this.cBox_AddGrid.Name = "cBox_AddGrid";
      this.cBox_AddGrid.Size = new System.Drawing.Size(80, 22);
      this.cBox_AddGrid.TabIndex = 0;
      this.cBox_AddGrid.Text = "Add grid";
      this.cBox_AddGrid.UseVisualStyleBackColor = true;
      // 
      // cBox_AddXAxis
      // 
      this.cBox_AddXAxis.AutoSize = true;
      this.cBox_AddXAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.cBox_AddXAxis.Location = new System.Drawing.Point(12, 40);
      this.cBox_AddXAxis.Name = "cBox_AddXAxis";
      this.cBox_AddXAxis.Size = new System.Drawing.Size(66, 22);
      this.cBox_AddXAxis.TabIndex = 1;
      this.cBox_AddXAxis.Text = "Add X";
      this.cBox_AddXAxis.UseVisualStyleBackColor = true;
      // 
      // cBox_AddYAxis
      // 
      this.cBox_AddYAxis.AutoSize = true;
      this.cBox_AddYAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.cBox_AddYAxis.Location = new System.Drawing.Point(12, 68);
      this.cBox_AddYAxis.Name = "cBox_AddYAxis";
      this.cBox_AddYAxis.Size = new System.Drawing.Size(65, 22);
      this.cBox_AddYAxis.TabIndex = 2;
      this.cBox_AddYAxis.Text = "Add Y";
      this.cBox_AddYAxis.UseVisualStyleBackColor = true;
      // 
      // tBox_GridLinesThickness
      // 
      this.tBox_GridLinesThickness.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tBox_GridLinesThickness.Location = new System.Drawing.Point(270, 33);
      this.tBox_GridLinesThickness.Name = "tBox_GridLinesThickness";
      this.tBox_GridLinesThickness.Size = new System.Drawing.Size(40, 24);
      this.tBox_GridLinesThickness.TabIndex = 3;
      this.tBox_GridLinesThickness.Text = "1";
      this.tBox_GridLinesThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_NumOfGridLines
      // 
      this.tBox_NumOfGridLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tBox_NumOfGridLines.Location = new System.Drawing.Point(270, 10);
      this.tBox_NumOfGridLines.Name = "tBox_NumOfGridLines";
      this.tBox_NumOfGridLines.Size = new System.Drawing.Size(40, 24);
      this.tBox_NumOfGridLines.TabIndex = 4;
      this.tBox_NumOfGridLines.Text = "5";
      this.tBox_NumOfGridLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(98, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(119, 18);
      this.label1.TabIndex = 5;
      this.label1.Text = "Num of grid lines";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(98, 36);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(166, 18);
      this.label2.TabIndex = 6;
      this.label2.Text = "Grid lines thickness (px)";
      // 
      // btn_ApplyPictureParameteres
      // 
      this.btn_ApplyPictureParameteres.AutoSize = true;
      this.btn_ApplyPictureParameteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btn_ApplyPictureParameteres.Location = new System.Drawing.Point(12, 152);
      this.btn_ApplyPictureParameteres.Name = "btn_ApplyPictureParameteres";
      this.btn_ApplyPictureParameteres.Size = new System.Drawing.Size(75, 28);
      this.btn_ApplyPictureParameteres.TabIndex = 7;
      this.btn_ApplyPictureParameteres.Text = "Apply";
      this.btn_ApplyPictureParameteres.UseVisualStyleBackColor = true;
      this.btn_ApplyPictureParameteres.Click += new System.EventHandler(this.btn_ApplyPictureParameteres_Click);
      // 
      // cBox_DrawLimit
      // 
      this.cBox_DrawLimit.AutoSize = true;
      this.cBox_DrawLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.cBox_DrawLimit.Location = new System.Drawing.Point(12, 96);
      this.cBox_DrawLimit.Name = "cBox_DrawLimit";
      this.cBox_DrawLimit.Size = new System.Drawing.Size(92, 22);
      this.cBox_DrawLimit.TabIndex = 8;
      this.cBox_DrawLimit.Text = "Draw limit";
      this.cBox_DrawLimit.UseVisualStyleBackColor = true;
      // 
      // cBox_DrawFilling
      // 
      this.cBox_DrawFilling.AutoSize = true;
      this.cBox_DrawFilling.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.cBox_DrawFilling.Location = new System.Drawing.Point(12, 124);
      this.cBox_DrawFilling.Name = "cBox_DrawFilling";
      this.cBox_DrawFilling.Size = new System.Drawing.Size(98, 22);
      this.cBox_DrawFilling.TabIndex = 9;
      this.cBox_DrawFilling.Text = "Draw filling";
      this.cBox_DrawFilling.UseVisualStyleBackColor = true;
      // 
      // FormPictureParameters
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(327, 193);
      this.Controls.Add(this.cBox_DrawFilling);
      this.Controls.Add(this.cBox_DrawLimit);
      this.Controls.Add(this.btn_ApplyPictureParameteres);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tBox_NumOfGridLines);
      this.Controls.Add(this.tBox_GridLinesThickness);
      this.Controls.Add(this.cBox_AddYAxis);
      this.Controls.Add(this.cBox_AddXAxis);
      this.Controls.Add(this.cBox_AddGrid);
      this.Name = "FormPictureParameters";
      this.Text = "FormPictureParameters";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox cBox_AddGrid;
    private System.Windows.Forms.CheckBox cBox_AddXAxis;
    private System.Windows.Forms.CheckBox cBox_AddYAxis;
    private System.Windows.Forms.TextBox tBox_GridLinesThickness;
    private System.Windows.Forms.TextBox tBox_NumOfGridLines;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.Button btn_ApplyPictureParameteres;
    private System.Windows.Forms.CheckBox cBox_DrawLimit;
    private System.Windows.Forms.CheckBox cBox_DrawFilling;
  }
}