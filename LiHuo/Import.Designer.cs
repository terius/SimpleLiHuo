namespace LiHuo
{
    partial class Import
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
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.superGrid1 = new FGTran.SuperGrid();
            this.labMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labMessage);
            this.panel1.Controls.Add(this.btnImportExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 73);
            this.panel1.TabIndex = 0;
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnImportExcel.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImportExcel.Location = new System.Drawing.Point(685, 12);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(181, 48);
            this.btnImportExcel.TabIndex = 2;
            this.btnImportExcel.Text = "Excel导入";
            this.btnImportExcel.UseVisualStyleBackColor = false;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.superGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(891, 430);
            this.panel2.TabIndex = 1;
            // 
            // superGrid1
            // 
            this.superGrid1.AllowUserToAddRows = false;
            this.superGrid1.AllowUserToDeleteRows = false;
            this.superGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.superGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.superGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGrid1.Location = new System.Drawing.Point(0, 0);
            this.superGrid1.Name = "superGrid1";
            this.superGrid1.PageSize = 15;
            this.superGrid1.ReadOnly = true;
            this.superGrid1.RowTemplate.Height = 35;
            this.superGrid1.Size = new System.Drawing.Size(891, 430);
            this.superGrid1.TabIndex = 0;
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMessage.ForeColor = System.Drawing.Color.Red;
            this.labMessage.Location = new System.Drawing.Point(412, 27);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(75, 20);
            this.labMessage.TabIndex = 3;
            this.labMessage.Text = "label1";
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 503);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Import";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "理货对照表录入";
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
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Label labMessage;
    }
}