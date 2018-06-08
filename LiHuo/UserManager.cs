using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LiHuo
{
    public partial class UserManager : Form
    {
        private readonly COMMON comm = new COMMON();
        private readonly UserBLL userBLL = new UserBLL();
        public UserManager()
        {
            InitializeComponent();
        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            InitGridView();
            LoadUserData();
        }

        private void LoadUserData()
        {
            DataTable dt = comm.Query("select *,'' as edit,'' as deleted from users");
            this.superGrid1.DataSource = dt;
        }

        private void InitGridView()
        {
            superGrid1.EnableHeadersVisualStyles = false;
            // superGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 179, 113);

            //DataGridViewComboBoxColumn columnCbox;
            DataGridViewTextBoxColumn column;

            column = new DataGridViewTextBoxColumn();
            column.Name = column.DataPropertyName = "id";
            column.HeaderText = "id";
            column.ReadOnly = true;
            column.Width = 100;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            column.Visible = false;
            this.superGrid1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = column.DataPropertyName = "HY_NAME";
            column.HeaderText = "公司名称";
            column.ReadOnly = true;
            column.Width = 100;
            //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //  column.Visible = false;
            this.superGrid1.Columns.Add(column);

           

            column = new DataGridViewTextBoxColumn();
            column.Name = column.DataPropertyName = "User_name";
            column.HeaderText = "用户名";
            column.ReadOnly = true;
            //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            column.Width = 100;
            this.superGrid1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = column.DataPropertyName = "Lever";
            column.HeaderText = "公司权限";
            column.ReadOnly = true;
            column.Width = 100;
            this.superGrid1.Columns.Add(column);

            DataGridViewButtonColumn columnButton = new DataGridViewButtonColumn();
            columnButton.Name = columnButton.DataPropertyName = "edit";
            columnButton.FillWeight = 70F;
            columnButton.HeaderText = "修改";
            columnButton.Text = "修改";
            columnButton.UseColumnTextForButtonValue = true;
            this.superGrid1.Columns.Add(columnButton);

            DataGridViewButtonColumn columnButton2 = new DataGridViewButtonColumn();
            columnButton2.Name = columnButton.DataPropertyName = "deleted";
            columnButton2.FillWeight = 70F;
            columnButton2.HeaderText = "删除";
            columnButton2.Text = "删除";
            columnButton2.UseColumnTextForButtonValue = true;
            this.superGrid1.Columns.Add(columnButton2);


        }

        private void superGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // DataGridViewDisableButtonCell buttonCell =
                //(DataGridViewDisableButtonCell)senderGrid.
                //Rows[e.RowIndex].Cells["CONFIRM"];
                // if (buttonCell.Enabled)
                // {
                //string voyage_no = cbox_VoyageNo.SelectedValue == null ? "" : cbox_VoyageNo.SelectedValue.ToString();
                //if (string.IsNullOrEmpty(voyage_no))
                //{
                //    MessageBox.Show("请选择正确的总运单号！");
                //    return;
                //}
                DataGridViewRow dr = senderGrid.Rows[e.RowIndex];
                var id = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value);
                string name = senderGrid.Columns[e.ColumnIndex].Name;
                if (name == "edit")
                {
                    EditUser(id);
                }
                else if (name == "deleted")
                {
                    DeleteUser(id);
                }


                // }
            }
        }

        private void EditUser(int id)
        {
            UserEdit edit = new UserEdit(id);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                LoadUserData();
            }
        }

        private void DeleteUser(int id)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要删除吗?", "删除用户", messButton);
            if (dr == DialogResult.OK)
            {
                bool rs = userBLL.DeleteUser(id);
                if (rs)
                {
                    MessageBox.Show("删除成功");
                    LoadUserData();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserEdit edit = new UserEdit();
            if (edit.ShowDialog() == DialogResult.OK)
            {
                LoadUserData();
            }
        }

        private void btnDelV1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要删除吗?", "删除V1表过期数据", messButton);
            if (dr == DialogResult.OK)
            {
                string sql = "delete LH_V1 where addtime < getdate() -30";
                int rs = comm.UID(sql);
                MessageBox.Show("删除了" + rs + "笔数据");
             
            }

        }

        private void btnDelV2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要删除吗?", "删除V2表过期数据", messButton);
            if (dr == DialogResult.OK)
            {
                string sql = "delete LH_V2 where scan_time < getdate() -30 or scan_time is null";
                int rs = comm.UID(sql);
                MessageBox.Show("删除了" + rs + "笔数据");
            }
        }
    }
}
