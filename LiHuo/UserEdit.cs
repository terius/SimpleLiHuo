using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LiHuo
{
    public partial class UserEdit : Form
    {
        private int _userId;
        private readonly UserBLL userBLL = new UserBLL();
        private string title;
        public UserEdit(int id = 0)
        {
            InitializeComponent();
            this._userId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserEdit_Load(object sender, EventArgs e)
        {
            if (this._userId > 0)
            {
                this.title = "编辑";
                var info = userBLL.GetUserInfoById(_userId);
                if (info != null)
                {
                 
                    tbTradeName.Text = info.HY_NAME;
                    tbUserName.Text = info.UserName;
                    rb1.Checked = info.Lever == "1" ? true : false;
                }
            }
            else
            {
                this.title = "新增";
            }
            this.Text = this.title + "用户";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserInfo info = new UserInfo();
            info.id = _userId;
            info.HY_NAME = tbTradeName.Text.Trim();
            info.UserName = tbUserName.Text.Trim();
            info.UserPassword = tbPWD.Text.Trim();
            info.Lever = rb0.Checked ? "0" : "1";
            if (CheckInput(info))
            {
                if (userBLL.SaveUserInfo(info))
                {
                    MessageBox.Show(this.title + "用户成功");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this.title + "用户失败");
                }
            }
        }

        private bool CheckInput(UserInfo info)
        {
            if (string.IsNullOrEmpty(info.UserName))
            {
                MessageBox.Show("用户名不能为空");
                tbUserName.Focus();
                tbUserName.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(info.HY_NAME))
            {
                MessageBox.Show("公司名称不能为空");
                tbTradeName.Focus();
                tbTradeName.SelectAll();
                return false;
            }
           

            if (info.id <= 0 && string.IsNullOrEmpty(info.UserPassword))
            {
                MessageBox.Show("新增用户密码不能为空");
                tbPWD.Focus();
                tbPWD.SelectAll();
                return false;
            }

            if (userBLL.CheckUserNameExist(info.UserName,info.id))
            {
                MessageBox.Show("用户名不能重复");
                tbUserName.Focus();
                tbUserName.SelectAll();
                return false;
            }

         
            return true;
        }
    }
}
