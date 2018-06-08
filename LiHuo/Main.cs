using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
namespace LiHuo
{
    public partial class Main : Form
    {
        private UserInfo userInfo;
        private readonly UserBLL userBLL = new UserBLL();
        public Main(int userId)
        {
            InitializeComponent();
            userInfo = userBLL.GetUserInfoById(userId);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            labTitle.Text = "欢迎 " + (userInfo == null ? "" : userInfo.HY_NAME) + " 用户登录";
            if (userInfo.UserName.Equals("admin", StringComparison.CurrentCultureIgnoreCase))
            {
                btnUserManager.Visible = true;
                btnImport.Visible = false;
                //   btnReport.Visible = false;
                btnScan.Visible = false;
                btnScanFast.Visible = false;

            }
            else
            {
                btnUserManager.Visible = false;
                btnImport.Visible = true;
                //    btnReport.Visible = true;
                btnScan.Visible = true;
                btnScanFast.Visible = true;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
            // Application.Exit();
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            UserManager frm = new UserManager();
            frm.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import frm = new Import();
            frm.userInfo = this.userInfo;
            frm.ShowDialog();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            Scan frm = new Scan();
            frm.userInfo = this.userInfo;
            frm.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Query frm = new Query();
            frm.userInfo = this.userInfo;
            frm.ShowDialog();
        }

        private void btnScanFast_Click(object sender, EventArgs e)
        {
            ScanFast frm = new ScanFast();
            frm.userInfo = this.userInfo;
            frm.ShowDialog();
        }
    }
}
