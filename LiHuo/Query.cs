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
using System.Threading;
using System.Windows.Forms;

namespace LiHuo
{
    public partial class Query : Form
    {
        private readonly COMMON comm = new COMMON();

        public UserInfo userInfo { get; set; }
        readonly string DLGS = System.Configuration.ConfigurationManager.AppSettings["DLGS"];
        public Query()
        {
            InitializeComponent();
        }
        private void InitGridView()
        {

            superGrid1.EnableHeadersVisualStyles = false;

            CommonHelper.AddColumn(this.superGrid1, "包裹号", "BAG_NO");
            CommonHelper.AddColumn(this.superGrid1, "分运单号", "BILL_NO");
            CommonHelper.AddColumn(this.superGrid1, "主要货物名称", "MAIN_G_NAME");
            CommonHelper.AddColumn(this.superGrid1, "进出口标识", "I_E_FLAG");
            CommonHelper.AddColumn(this.superGrid1, "货运公司名称", "HY_NAME");
            CommonHelper.AddColumn(this.superGrid1, "运营公司名称", "TRADE_NAME");
            CommonHelper.AddColumn(this.superGrid1, "申报日期", "D_DATE");
            CommonHelper.AddColumn(this.superGrid1, "过机标识", "GJ_FLAG");
            CommonHelper.AddColumn(this.superGrid1, "查验标识", "RSK_FLAG");
            CommonHelper.AddColumn(this.superGrid1, "无数据标识", "OP_TYPE");
            CommonHelper.AddColumn(this.superGrid1, "扫描时间", "SCAN_TIME");




        }

        #region V1表查询
        private void InitGridView2()
        {
            superGrid2.EnableHeadersVisualStyles = false;
            CommonHelper.AddColumn(this.superGrid2, "分运单号", "BILL_NO");
            CommonHelper.AddColumn(this.superGrid2, "包裹号", "BAG_NO");
            CommonHelper.AddColumn(this.superGrid2, "扫描标记", "SCAN_FLAG");
            CommonHelper.AddColumn(this.superGrid2, "公司名称", "HY_NAME");



        }




        private void LoadV1Data()
        {
            string sql = "";
            Hashtable ht = new Hashtable();
            if (this.userInfo.UserName.ToLower() != "admin")
            {
                sql = "select BILL_NO,BAG_NO,SCAN_FLAG,HY_NAME from LH_V1 "
                + "where HY_NAME=@HY_NAME and addtime >= @stime and addtime <= @etime order by BAG_NO,BILL_NO";
                ht["HY_NAME"] = userInfo.HY_NAME;
            }
            else
            {
                sql = "select BILL_NO,BAG_NO,SCAN_FLAG,HY_NAME from LH_V1 "
               + "where addtime >= @stime and addtime <= @etime order by HY_NAME, BAG_NO,BILL_NO";
            }
            DateTime dtNow = DateTime.Now.Date;
            ht["stime"] = dtNow;
            ht["etime"] = dtNow.AddDays(1);
            DataTable dt = comm.Query(sql, ht);
            this.superGrid2.DataSource = dt;
        }

        #endregion

        private void Query_Load(object sender, EventArgs e)
        {
            tabPage3.Parent = null;
            this.superGrid1.RowTemplate.MinimumHeight = 20;
            this.superGrid1.RowTemplate.Height = 30;

            labTotal.Text = "";
            labFBK.Text = "";
            labGJ.Text = "";
            labBK.Text = "";
            labWSJ.Text = "";
            //    labConnFail.Text = "";
            stime.Value = DateTime.Now.Date;
            etime.Value = DateTime.Now.Date.AddDays(1);
            //  stime3.Value = DateTime.Now.Date;
            //   etime3.Value = DateTime.Now.Date.AddDays(1);
            InitGridView();
            BindUser();
            BindDLGS();

            #region V1表查询
            InitGridView2();
            LoadV1Data();
            #endregion


            //#region 机检结果查询

            //InitGridViewJJJG();
            //// LoadV1Data();
            //#endregion

        }

        private void BindDLGS()
        {
            string[] dlgs = DLGS.Split(',');
            cbDLGS.Items.Add("--请选择代理公司--");
            foreach (string s in dlgs)
            {
                cbDLGS.Items.Add(s);
            }
            cbDLGS.SelectedIndex = 0;
        }
        #region 机检结果查询
        private void InitGridViewJJJG()
        {
            superGrid3.EnableHeadersVisualStyles = false;
            CommonHelper.AddColumn(this.superGrid3, "分运单号", "BILL_NO");
            CommonHelper.AddColumn(this.superGrid3, "总运单号", "VOYAGE_NO");
            CommonHelper.AddColumn(this.superGrid3, "包裹号", "BAG_NO");
            CommonHelper.AddColumn(this.superGrid3, "申报日期", "D_DATE");
            CommonHelper.AddColumn(this.superGrid3, "过机标识", "GJ_FLAG");
            CommonHelper.AddColumn(this.superGrid3, "查验标识", "RSK_FLAG");
            CommonHelper.AddColumn(this.superGrid3, "OP_TYPE", "OP_TYPE");
            CommonHelper.AddColumn(this.superGrid3, "过机时间", "GJTIME");
        }

        private void btnQuery3_Click(object sender, EventArgs e)
        {
            QueryJJJG();
        }

        private void QueryJJJG()
        {
            string table = rbToday3.Checked ? "LH_V2" : "LH_V3";
            StringBuilder sb = new StringBuilder();
            Hashtable ht = new Hashtable();
            if (ccbUser3.SelectedIndex > 0)
            {
                sb.Append(" and HY_NAME = @HY_NAME");
                ht["HY_NAME"] = ddlUser.SelectedValue.ToString();
            }

            if (!string.IsNullOrEmpty(tbBillNo3.Text.Trim()))
            {
                sb.Append(" and bill_no like @bill_no");
                ht["bill_no"] = "%" + tbBillNo.Text.Trim() + "%";
            }
            string timeColumn = "";
            if (rbFangXing.Checked)
            {
                timeColumn = "OP_TIME";
                sb.Append(" and Op_type='01' and GJ_FLAG =1");
                labTimeDue.Text = "时间段(OP_TIME)：";
            }
            else if (rbChaYan.Checked)
            {
                timeColumn = "OP_TIME";
                sb.Append(" and (Op_type='02' or Op_type ='03')");
                labTimeDue.Text = "时间段(OP_TIME)：";
            }
            else if (rbWeiJiJian.Checked)
            {
                timeColumn = "SCAN_TIME";
                sb.Append(" and Op_type is null and ( GJ_FLAG = 1 or RSK_FLAG = 1)");
                labTimeDue.Text = "时间段(SCAN_TIME)：";
            }

            sb.Append(" and " + timeColumn + " >= @stime");
            ht["stime"] = stime3.Value;
            sb.Append(" and " + timeColumn + " <= @etime");
            ht["etime"] = etime3.Value;

            string sql = "select BILL_NO,VOYAGE_NO,BAG_NO,D_DATE,"
                 + "(case GJ_FLAG when 1 then '1' else '' end) GJ_FLAG,"
                + "(case RSK_FLAG when 1 then '1' else '' end) RSK_FLAG,"
                + "(case OP_TYPE when '01' then '机检放行' when '02' then '机检查验' when '03' then '机检查验' when null then '未机检'  else OP_TYPE end) OP_TYPE,"
                + timeColumn + " as GJTIME from " + table + " where 1=1 " + sb.ToString();

            DataTable dt = comm.Query(sql, ht);
            this.superGrid3.DataSource = dt;

        }
        #endregion
        private void BindUser()
        {
            string sql = "select HY_NAME from users";
            DataTable dt = comm.Query(sql);
            DataRow dr = dt.NewRow();
            dr[0] = "--请选择公司--";
            dt.Rows.InsertAt(dr, 0);
            ddlUser.DataSource = dt.DefaultView;
            ddlUser.DisplayMember = "HY_NAME";
            ddlUser.ValueMember = "HY_NAME";

            // ccbUser3.DataSource = dt.DefaultView;
            //  ccbUser3.DisplayMember = "trade_name";
            //   ccbUser3.ValueMember = "HY_NAME";
            if (this.userInfo.UserName.ToLower() != "admin")
            {
                ddlUser.SelectedValue = this.userInfo.HY_NAME;
                ddlUser.Enabled = false;

                //  ccbUser3.SelectedValue = this.userInfo.HY_NAME;
                //  ccbUser3.Enabled = false;
            }
        }

        //   private DataTable V2Table;
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string tableName = rbToday.Checked ? "LH_V2" : "LH_V3";
            StringBuilder sb = new StringBuilder();
            Hashtable ht = new Hashtable();
            if (ddlUser.SelectedIndex > 0)
            {
                sb.Append(" and HY_NAME = @HY_NAME");
                ht["HY_NAME"] = ddlUser.SelectedValue.ToString();
            }

            if (cbDLGS.SelectedIndex > 0)
            {
                sb.Append(" and TRADE_NAME = @TRADE_NAME");
                ht["TRADE_NAME"] = cbDLGS.Text;
            }

            //if (stime.Checked)
            //{
            sb.Append(" and scan_time >= @stime");
            ht["stime"] = stime.Value;
            // }

            // if (etime.Checked)
            // {
            sb.Append(" and scan_time <= @etime");
            ht["etime"] = etime.Value;
            //}

            if (!string.IsNullOrEmpty(tbBillNo.Text.Trim()))
            {
                sb.Append(" and bill_no like @bill_no");
                ht["bill_no"] = "%" + tbBillNo.Text.Trim() + "%";
            }

            if (!string.IsNullOrEmpty(txtBAGNO.Text.Trim()))
            {
                sb.Append(" and BAG_NO like @BAG_NO");
                ht["BAG_NO"] = "%" + txtBAGNO.Text.Trim() + "%";
            }

            if (cbFangXing.Checked || cbGuoJi.Checked || cbChaYan.Checked || cbWuShuJu.Checked)
            {
                sb.Append(" and (");
                StringBuilder sb2 = new StringBuilder();



                if (cbFangXing.Checked)
                {
                    sb2.Append("  (RSK_FLAG = 0 and  GJ_FLAG = 0) or ");
                }

                if (cbGuoJi.Checked)
                {
                    sb2.Append("  (RSK_FLAG = 0 and GJ_FLAG = 1)  or ");
                }

                if (cbChaYan.Checked)
                {
                    sb2.Append("  RSK_FLAG = 1  or ");
                }

                if (cbWuShuJu.Checked)
                {
                    sb2.Append("  OP_TYPE = '04' or ");
                }

                if (sb2.Length > 0)
                {
                    sb2.Remove(sb2.Length - 4, 4);
                }
                sb.Append(sb2.ToString() + " )");
            }
            else
            {
                sb.Append(" and 1=0");
            }
            string sql = "select BAG_NO,BILL_NO,MAIN_G_NAME,I_E_FLAG,HY_NAME,TRADE_NAME,D_DATE,"
                //  + "(case R_FLAG when 1 then '1' else '' end) R_FLAG,"
                + "(case GJ_FLAG when 1 then '1' else '' end) GJ_FLAG,"
                + "(case RSK_FLAG when 1 then '1' when 0 then '0' else '' end) RSK_FLAG,"
                + "(case OP_TYPE when '04' then '1' else '' end) OP_TYPE,"
                //   + "(case SEND_FLAG when 3 then '1' else '' end) ISCONNERROR"
                + "SCAN_TIME from " + tableName + " where 1=1 " + sb.ToString();
            DataTable dt = comm.Query(sql, ht);
            this.superGrid1.DataSource = dt;
            labTotal.Text = dt.Rows.Count.ToString();
            labGJ.Text = dt.Select("GJ_FLAG= '1'").Length.ToString();
            labBK.Text = dt.Select("RSK_FLAG= '1'").Length.ToString();
            labFBK.Text = dt.Select("RSK_FLAG= '0'").Length.ToString();
            labWSJ.Text = dt.Select("OP_TYPE= '1'").Length.ToString();
            //  labConnFail.Text = dt.Select("ISCONNERROR= '1'").Length.ToString();
        }



        private void btnQuery2_Click(object sender, EventArgs e)
        {
            LoadV1Data();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.superGrid1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "导出Excel (*.xls)|*.xls";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;
                //   saveFileDialog.CreatePrompt = true;
                saveFileDialog.Title = "导出文件保存路径";
                saveFileDialog.FileName = "扫描查询_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    if (filePath.Length != 0)
                    {
                        labMessage.Text = "正在导出Excel";
                        DataTable dt = (DataTable)this.superGrid1.DataSource; // Se convierte el DataSource 
                        Hashtable ht = CommonHelper.GetDataGridViewColumns(this.superGrid1);
                        ExcelHelper.Export(dt, filePath, ht);
                        labMessage.Text = "";
                        MessageBox.Show("导出成功");
                    }
                }
            }
        }

        private void rbFangXing_CheckedChanged(object sender, EventArgs e)
        {
            labTimeDue.Text = "时间段(OP_TIME)：";
        }

        private void rbChaYan_CheckedChanged(object sender, EventArgs e)
        {
            labTimeDue.Text = "时间段(OP_TIME)：";
        }

        private void rbWeiJiJian_CheckedChanged(object sender, EventArgs e)
        {
            labTimeDue.Text = "时间段(SCAN_TIME)：";
        }

        private void btnExport3_Click(object sender, EventArgs e)
        {
            if (this.superGrid3.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "导出Excel (*.xls)|*.xls";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;
                //   saveFileDialog.CreatePrompt = true;
                saveFileDialog.Title = "导出文件保存路径";
                saveFileDialog.FileName = "机检结果查询_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    if (filePath.Length != 0)
                    {
                        labMessage3.Text = "正在导出Excel";
                        DataTable dt = (DataTable)this.superGrid3.DataSource; // Se convierte el DataSource 
                        Hashtable ht = CommonHelper.GetDataGridViewColumns(this.superGrid3);
                        ExcelHelper.Export(dt, filePath, ht);
                        labMessage3.Text = "";
                        MessageBox.Show("导出成功");
                    }
                }
            }
        }
    }
}
