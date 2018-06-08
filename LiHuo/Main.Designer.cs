namespace LiHuo
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.labTitle = new System.Windows.Forms.Label();
            this.btnUserManager = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnScanFast = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labTitle.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(12, 9);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(631, 54);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "欢迎 XXXX公司 用户登录";
            // 
            // btnUserManager
            // 
            this.btnUserManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUserManager.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserManager.Location = new System.Drawing.Point(21, 77);
            this.btnUserManager.Name = "btnUserManager";
            this.btnUserManager.Size = new System.Drawing.Size(242, 53);
            this.btnUserManager.TabIndex = 1;
            this.btnUserManager.Text = "系统管理";
            this.btnUserManager.UseVisualStyleBackColor = false;
            this.btnUserManager.Click += new System.EventHandler(this.btnUserManager_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnImport.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImport.Location = new System.Drawing.Point(21, 150);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(242, 53);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "理货对照表录入";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnReport.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReport.Location = new System.Drawing.Point(21, 375);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(242, 53);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "查询统计";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnScan.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScan.Location = new System.Drawing.Point(21, 224);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(242, 53);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "扫描货品(慢速)";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnScanFast
            // 
            this.btnScanFast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnScanFast.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanFast.Location = new System.Drawing.Point(21, 298);
            this.btnScanFast.Name = "btnScanFast";
            this.btnScanFast.Size = new System.Drawing.Size(242, 53);
            this.btnScanFast.TabIndex = 6;
            this.btnScanFast.Text = "扫描货品(快速)";
            this.btnScanFast.UseVisualStyleBackColor = false;
            this.btnScanFast.Click += new System.EventHandler(this.btnScanFast_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 585);
            this.Controls.Add(this.btnScanFast);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnUserManager);
            this.Controls.Add(this.labTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "杭州电商快件理货系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Button btnUserManager;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnScanFast;
    }
}

