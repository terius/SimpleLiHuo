namespace LiHuo
{
    partial class UserManager
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
            this.btnAddUser = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDelV1 = new System.Windows.Forms.Button();
            this.btnDelV2 = new System.Windows.Forms.Button();
            this.superGrid1 = new FGTran.SuperGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 73);
            this.panel1.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddUser.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddUser.Location = new System.Drawing.Point(712, 12);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(154, 48);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "新增用户";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.superGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(877, 390);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(891, 503);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(883, 469);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "用户管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDelV2);
            this.tabPage2.Controls.Add(this.btnDelV1);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(883, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "记录删除";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDelV1
            // 
            this.btnDelV1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelV1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelV1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelV1.Location = new System.Drawing.Point(17, 17);
            this.btnDelV1.Name = "btnDelV1";
            this.btnDelV1.Size = new System.Drawing.Size(295, 81);
            this.btnDelV1.TabIndex = 3;
            this.btnDelV1.Text = "删除V1表过期数据";
            this.btnDelV1.UseVisualStyleBackColor = false;
            this.btnDelV1.Click += new System.EventHandler(this.btnDelV1_Click);
            // 
            // btnDelV2
            // 
            this.btnDelV2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelV2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelV2.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelV2.Location = new System.Drawing.Point(17, 173);
            this.btnDelV2.Name = "btnDelV2";
            this.btnDelV2.Size = new System.Drawing.Size(295, 87);
            this.btnDelV2.TabIndex = 4;
            this.btnDelV2.Text = "删除V2表过期数据";
            this.btnDelV2.UseVisualStyleBackColor = false;
            this.btnDelV2.Click += new System.EventHandler(this.btnDelV2_Click);
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
            this.superGrid1.Size = new System.Drawing.Size(877, 390);
            this.superGrid1.TabIndex = 0;
            this.superGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.superGrid1_CellClick);
            // 
            // UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 503);
            this.Controls.Add(this.tabControl1);
            this.Name = "UserManager";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统管理";
            this.Load += new System.EventHandler(this.UserManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FGTran.SuperGrid superGrid1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDelV2;
        private System.Windows.Forms.Button btnDelV1;
    }
}