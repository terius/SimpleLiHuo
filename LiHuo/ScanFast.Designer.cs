namespace LiHuo
{
    partial class ScanFast
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.superGrid1 = new FGTran.SuperGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1343, 102);
            this.panel1.TabIndex = 0;
            // 
            // tbNo
            // 
            this.tbNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbNo.Location = new System.Drawing.Point(128, 54);
            this.tbNo.MaxLength = 50;
            this.tbNo.Name = "tbNo";
            this.tbNo.Size = new System.Drawing.Size(439, 29);
            this.tbNo.TabIndex = 7;
            this.tbNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNo_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "扫描条码：";
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labTitle.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(12, 9);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(180, 33);
            this.labTitle.TabIndex = 4;
            this.labTitle.Text = "当前用户：";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.superGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1343, 447);
            this.panel2.TabIndex = 1;
            // 
            // superGrid1
            // 
            this.superGrid1.AllowUserToAddRows = false;
            this.superGrid1.AllowUserToDeleteRows = false;
            this.superGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.superGrid1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.superGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.superGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGrid1.Location = new System.Drawing.Point(0, 0);
            this.superGrid1.MultiSelect = false;
            this.superGrid1.Name = "superGrid1";
            this.superGrid1.PageSize = 15;
            this.superGrid1.ReadOnly = true;
            this.superGrid1.RowTemplate.Height = 35;
            this.superGrid1.Size = new System.Drawing.Size(1343, 447);
            this.superGrid1.TabIndex = 0;
            // 
            // ScanFast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 549);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ScanFast";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快速扫描";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FGTran.SuperGrid superGrid1;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.TextBox tbNo;
        private System.Windows.Forms.Label label3;
    }
}