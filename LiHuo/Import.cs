using BLL;
using DAL;
using Helpers;
using Model;
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
    public partial class Import : Form
    {
        private readonly COMMON comm = new COMMON();
        private  V1BLL v1BLL;
        public UserInfo userInfo { get; set; }

        public Import()
        {
            InitializeComponent();
        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            labMessage.Text = "";
            InitGridView();
            LoadV1data();
        }

        private void LoadV1data()
        {
            Hashtable ht = new Hashtable();
            ht["HY_NAME"] = userInfo.HY_NAME;
            DataTable dt = comm.Query("select *,'' as SCANSTATUS from LH_V1 where HY_NAME= @HY_NAME order by id desc", ht);
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
            column.Name = column.DataPropertyName = "BAG_NO";
            column.HeaderText = "包裹号";
            column.ReadOnly = true;
            column.Width = 100;
            //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //  column.Visible = false;
            this.superGrid1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = column.DataPropertyName = "BILL_NO";
            column.HeaderText = "分运单号";
            column.ReadOnly = true;
            //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            column.Width = 200;
            this.superGrid1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = column.DataPropertyName = "I_E_FLAG";
            column.HeaderText = "进出口标志";
            column.ReadOnly = true;
            column.Width = 100;
            this.superGrid1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = column.DataPropertyName = "HY_NAME";
            column.HeaderText = "运营单位";
            column.ReadOnly = true;
            column.Width = 100;
            this.superGrid1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = column.DataPropertyName = "SCANSTATUS";
            column.HeaderText = "扫描状态";
            column.ReadOnly = true;
            column.Width = 100;
            this.superGrid1.Columns.Add(column);


        }

        //private void superGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    var senderGrid = (DataGridView)sender;

        //    if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
        //    {
        //        // DataGridViewDisableButtonCell buttonCell =
        //        //(DataGridViewDisableButtonCell)senderGrid.
        //        //Rows[e.RowIndex].Cells["CONFIRM"];
        //        // if (buttonCell.Enabled)
        //        // {
        //        //string voyage_no = cbox_VoyageNo.SelectedValue == null ? "" : cbox_VoyageNo.SelectedValue.ToString();
        //        //if (string.IsNullOrEmpty(voyage_no))
        //        //{
        //        //    MessageBox.Show("请选择正确的总运单号！");
        //        //    return;
        //        //}
        //        DataGridViewRow dr = senderGrid.Rows[e.RowIndex];
        //        var id = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value);
        //       // EditUser(id);

        //        // }
        //    }
        //}

    

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择Excel文件";
            fileDialog.Filter = @"Excel文件 (*.xls,*.xlsx)|*.xls;*.xlsx;";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                labMessage.Text = "导入中，请稍后。。。";
                Application.DoEvents();
                string file = fileDialog.FileName;
                DataTable dt = ExcelHelper.GetData(file);
                ImportData(dt);
                labMessage.Text = "导入完成";
            }
        }

        private void ImportData(DataTable dt)
        {
            v1BLL = new V1BLL(userInfo.HY_NAME);
            int rs = v1BLL.ImportExcelData(dt);
            if (rs > 0)
            {
                MessageBox.Show("导入成功!成功导入"+ rs + "笔数据" );
                LoadV1data();
            }
            else
            {
                MessageBox.Show("导入失败");
            }
        }
    }
}
