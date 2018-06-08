using DAL;
using Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LiHuo
{
    public partial class Login : Form
    {
        private readonly COMMON common = new COMMON();
        public Login()
        {
            InitializeComponent();
            label4.Text = "V"+System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
            // Application.Exit();
        }

        private void login()
        {
          
            string userName = tbUser.Text.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            string pwd = tbPWD.Text.Trim();
            if (string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            Hashtable ht = new Hashtable();
            ht["user_name"] = userName;
            DataRow dr = common.GetOneRow("select top 1 id,user_pass from Users where user_name= @user_name", ht);
            if (dr != null)
            {
                string enPwd = dr["user_pass"].ToString();
                pwd = StringHelper.Sha256(pwd);
                if (pwd.Equals(enPwd))
                {
                    this.Hide();
                    int id = Convert.ToInt32(dr["id"]);
                    Main mainForm = new Main(id);
                    mainForm.Show();

                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            }
            else
            {
                MessageBox.Show("用户名错误");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();


        }

        private void tbPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
    }
}
