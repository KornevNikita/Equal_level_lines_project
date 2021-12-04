
namespace Equal_level_lines_UI
{
  partial class FormLinesParameters
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.button1 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
      this.dataGridView1.Location = new System.Drawing.Point(12, 12);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersVisible = false;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
      this.dataGridView1.Size = new System.Drawing.Size(321, 62);
      this.dataGridView1.TabIndex = 19;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.HeaderText = "N";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.HeaderText = "M1";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      // 
      // dataGridViewTextBoxColumn3
      // 
      this.dataGridViewTextBoxColumn3.HeaderText = "M2";
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.HeaderText = "M3";
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      // 
      // button1
      // 
      this.button1.AutoSize = true;
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.button1.Location = new System.Drawing.Point(12, 80);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 28);
      this.button1.TabIndex = 20;
      this.button1.Text = "Apply";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // LinesParameters
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(345, 112);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.dataGridView1);
      this.Name = "LinesParameters";
      this.Text = "LinesParameters";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.Button button1;
  }
}