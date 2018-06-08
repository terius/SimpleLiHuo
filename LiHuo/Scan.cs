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
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LiHuo
{
    public partial class Scan : Form
    {

        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string pszSound, int hmod, int fdwSound);
        public const int SND_FILENAME = 0x00020000;
        public const int SND_ASYNC = 0x0001;
        //调用下面的方法  

        private readonly COMMON comm = new COMMON();
        private V2BLL v2BLL;
        static AutoResetEvent waitResultEvent = new AutoResetEvent(false);
        public UserInfo userInfo { get; set; }

        public Scan()
        {
            InitializeComponent();
        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            if (userInfo.Lever != "1")
            {
                btnImportExcel.Visible = false;
            }
            v2BLL = new V2BLL(userInfo.HY_NAME);
            InitGridView();
            ReloadData();

        }

        private void ReloadData()
        {

            tbNo.Focus();
            labMessage.Text = "";
            labTitle.Text = "当前用户： " + userInfo.HY_NAME;
            labMaxNo.Text = v2BLL.GetMAXBLLNO();
            LoadV2data();
        }

        private DataTable gridTable;

        private void LoadV2data()
        {

            Hashtable ht = new Hashtable();
            ht["HY_NAME"] = userInfo.HY_NAME;
            gridTable = comm.Query("select SCAN_NO,BILL_NO,VOYAGE_NO,MAIN_G_NAME,I_E_FLAG,I_E_PORT,D_DATE, "
                //   + "(case R_FLAG when 1 then '1' else '' end) R_FLAG, "
                //  + "(case GJ_FLAG when 1 then '1' else '' end) GJ_FLAG,"
                + "(case RSK_FLAG when 1 then '1' when 0 then '0' else '' end) RSK_FLAG,"
                + "(case OP_TYPE when '04' then '1' else '' end) OP_TYPE "
                + " from LH_V2 where HY_NAME= @HY_NAME order by SCAN_NO desc", ht);
            this.superGrid1.DataSource = gridTable;
            labAllCount.Text = gridTable.Rows.Count.ToString();
            // int maxNum = StringHelper.SafeGetIntFromObj(gridTable.Rows[0][0], 0);
            ReflashGrid fc = new ReflashGrid(AppendGrid);
            fc.BeginInvoke(null, null);
            
        }

        object obDo1 = new object();
        private void AppendGrid()
        {
            lock (obDo1)
            {
                while (true)
                {
                    bool isChange = v2BLL.GetNewData(gridTable);
                    if (isChange)
                    {
                        SetLabelText(this.labAllCount, gridTable.Rows.Count.ToString());
                        if (this.superGrid1.InvokeRequired)
                        {
                            this.superGrid1.Invoke(new MethodInvoker(delegate
                            {
                                this.superGrid1.Refresh();
                                // this.superGrid1.Update();
                                //this.superGrid1.EndEdit();

                            }));
                        }
                        else
                        {
                            this.superGrid1.Refresh();
                            //  this.superGrid1.Update();
                            // this.superGrid1.EndEdit();
                        }
                    }

                    Thread.Sleep(2000);
                }
            }

        }

        private void InitGridView()
        {
            superGrid1.EnableHeadersVisualStyles = false;

           

            CommonHelper.AddColumn(this.superGrid1, "扫描计数", "SCAN_NO");
            CommonHelper.AddColumn(this.superGrid1, "分运单号", "BILL_NO");
            CommonHelper.AddColumn(this.superGrid1, "总运单号", "VOYAGE_NO");
            CommonHelper.AddColumn(this.superGrid1, "主要货物名称", "MAIN_G_NAME");
            CommonHelper.AddColumn(this.superGrid1, "进出口标识", "I_E_FLAG");
            CommonHelper.AddColumn(this.superGrid1, "进出口岸代码", "I_E_PORT");
            CommonHelper.AddColumn(this.superGrid1, "申报日期", "D_DATE");
            CommonHelper.AddColumn(this.superGrid1, "是否布控", "RSK_FLAG");
            CommonHelper.AddColumn(this.superGrid1, "无数据标识", "OP_TYPE");

            //DataGridViewTextBoxColumn column;
            //column = new DataGridViewTextBoxColumn();
            //column.Name = column.DataPropertyName = "SCAN_NO";
            //column.HeaderText = "扫描计数";
            //column.ReadOnly = true;
            //column.Width = 100;
            //this.superGrid1.Columns.Add(column);

            //column = new DataGridViewTextBoxColumn();
            //column.Name = column.DataPropertyName = "BILL_NO";
            //column.HeaderText = "分运单号";
            //column.ReadOnly = true;
            //column.Width = 100;
            //this.superGrid1.Columns.Add(column);

            //column = new DataGridViewTextBoxColumn();
            //column.Name = column.DataPropertyName = "VOYAGE_NO";
            //column.HeaderText = "总运单号";
            //column.ReadOnly = true;
            //column.Width = 100;
            //this.superGrid1.Columns.Add(column);

            //column = new DataGridViewTextBoxColumn();
            //column.Name = column.DataPropertyName = "MAIN_G_NAME";
            //column.HeaderText = "主要货物名称";
            //column.ReadOnly = true;
            //column.Width = 100;
            //this.superGrid1.Columns.Add(column);

            //column = new DataGridViewTextBoxColumn();
            //column.Name = column.DataPropertyName = "I_E_FLAG";
            //column.HeaderText = "进出口标识";
            //column.ReadOnly = true;
            //column.Width = 100;
            //this.superGrid1.Columns.Add(column);

            //column = new DataGridViewTextBoxColumn();
            //column.Name = column.DataPropertyName = "I_E_PORT";
            //column.HeaderText = "进出口岸代码";
            //column.ReadOnly = true;
            //column.Width = 100;
            //this.superGrid1.Columns.Add(column);

            //column = new DataGridViewTextBoxColumn();
            //column.Name = column.DataPropertyName = "D_DATE";
            //column.HeaderText = "申报日期";
            //column.ReadOnly = true;
            //column.Width = 100;
            //this.superGrid1.Columns.Add(column);

            ////column = new DataGridViewTextBoxColumn();
            ////column.Name = column.DataPropertyName = "R_FLAG";
            ////column.HeaderText = "放行标识";
            ////column.ReadOnly = true;
            ////column.Width = 100;
            ////this.superGrid1.Columns.Add(column);

            ////column = new DataGridViewTextBoxColumn();
            ////column.Name = column.DataPropertyName = "GJ_FLAG";
            ////column.HeaderText = "过机标识";
            ////column.ReadOnly = true;
            ////column.Width = 100;
            ////this.superGrid1.Columns.Add(column);

            //column = new DataGridViewTextBoxColumn();
            //column.Name = column.DataPropertyName = "RSK_FLAG";
            //column.HeaderText = "是否布控";
            //column.ReadOnly = true;
            //column.Width = 100;
            //this.superGrid1.Columns.Add(column);

            //column = new DataGridViewTextBoxColumn();
            //column.Name = column.DataPropertyName = "OP_TYPE";
            //column.HeaderText = "无数据标识";
            //column.ReadOnly = true;
            //column.Width = 100;
            //this.superGrid1.Columns.Add(column);


        }





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

            ImportHandle fc = new ImportHandle(RunImport);
            fc.BeginInvoke(dt, null, null);

        }

        private void RunImport(DataTable dt)
        {
            string sn = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sn = dr[0].ToString();
                    if (!string.IsNullOrEmpty(sn))
                    {
                        string lastSN = v2BLL.SaveToV2(sn);
                        SetLabelText(this.labMaxNo, lastSN);
                        //   labMaxNo.Text = lastSN;
                        Application.DoEvents();
                    }
                }
            }
        }

        private void tbNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sn = tbNo.Text.Trim();
                if (!string.IsNullOrEmpty(sn))
                {
                    ProcessData(sn);
                }
            }
        }

        private void ProcessData(string sn)
        {

            getStatusResult = false;
            labMessage.Text = "条码状态获取中...";
            labFangXing.BackColor = Color.Silver;
            labGuoJi.BackColor = Color.Silver;
            labWuShuJu.BackColor = Color.Silver;
            Application.DoEvents();
            string lastSN = v2BLL.SaveToV2(sn);
            labMaxNo.Text = lastSN;
            WaitForStatus(lastSN);

        }

        private void WaitForStatus(string lastSN)
        {
            FlushClient fc = new FlushClient(RunStatus);
            fc.BeginInvoke(lastSN, null, null);
            //  fc.BeginInvoke(lastSN, GetResult, null);
            //  Thread getStatusThread = new Thread(new ParameterizedThreadStart(RunStatus));
            //    getStatusThread.Start(lastSN);
            waitResultEvent.WaitOne();
            if (getStatusResult)
            {
                this.labMessage.Text = "状态获取成功";
            }
            else
            {
                ReloadData();
                this.labMessage.Text = "状态获取失败";
            }
            tbNo.Text = "";
            tbNo.Focus();
            Application.DoEvents();
        }

        //private void GetResult(IAsyncResult result)
        //{
        //    FlushClient caller = (FlushClient)((AsyncResult)result).AsyncDelegate;
        //    // 调用EndInvoke去等待异步调用完成并且获得返回值
        //    // 如果异步调用尚未完成，则 EndInvoke 会一直阻止调用线程，直到异步调用完成
        //    bool rs = caller.EndInvoke(result);
        //    if (rs)
        //    {
        //        SetLabelText(labMessage, "状态获取成功");
        //    }
        //    else
        //    {
        //        SetLabelText(labMessage, "状态获取失败");
        //    }

        //}

        private bool getStatusResult;
        private delegate void FlushClient(string lastSN);//代理
        private delegate void ReflashGrid();//代理
        private delegate void ImportHandle(DataTable dt);//代理
        private void RunStatus(string lastSN)
        {
            bool[] s = new bool[4];
            bool rs = v2BLL.GetStatus(lastSN, ref s);
            if (rs)
            {
                 labFangXing.BackColor = s[0] ? Color.Red : Color.Silver;
                labGuoJi.BackColor = s[1] ? Color.Red : Color.Silver;
                labChaYan.BackColor = s[2] ? Color.Red : Color.Silver;
                labWuShuJu.BackColor = s[3] ? Color.Red : Color.Silver;
                getStatusResult = true;
                if (s[2])
                {
                    PlaySound("bk.wav", 0, SND_ASYNC | SND_FILENAME);
                }
                //  SetLabelText(this.labMessage, "检验完成，可以扫描下一条码");
                // labMessage.Text = "检验完成，可以扫描下一条码";
            }
            else
            {
                MessageBox.Show("读取失败");
                getStatusResult = false;
            }
            waitResultEvent.Set();

        }


        private void SetLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new MethodInvoker(delegate
                {
                    label.Text = text;

                }));
            }
            else
            {
                label.Text = text;
            }
        }

        private void superGrid1_Scroll(object sender, ScrollEventArgs e)
        {
            //Rectangle rect;
            //DataGridView ctrl = (DataGridView)sender;

            //Point pt = PointToScreen(ctrl.Location);

            //if (pt.X < 0)
            //{
            //    int left = -pt.X;
            //    int top = ctrl.ColumnHeadersHeight;
            //    int width = e.OldValue - e.NewValue;
            //    int height = ctrl.ClientSize.Height;
            //    ctrl.Invalidate(new Rectangle(new Point(left, top), new Size(width, height)));
            //}

            //pt.X += ctrl.Width;
            //rect = Screen.GetBounds(pt);

            //if (pt.X > rect.Right)
            //{
            //    int left = ctrl.ClientSize.Width - (pt.X - rect.Right) - (e.NewValue - e.OldValue);
            //    int top = ctrl.ColumnHeadersHeight;
            //    int width = e.NewValue - e.OldValue;
            //    int height = ctrl.ClientSize.Height;
            //    ctrl.Invalidate(new Rectangle(new Point(left, top), new Size(width, height)));
            //}

            //pt.Y += ctrl.Height;
            //if (pt.Y > rect.Bottom)
            //{
            //    int left = 0;
            //    int top = ctrl.ColumnHeadersHeight;
            //    int width = ctrl.ClientSize.Width;
            //    int height = ctrl.ClientSize.Height - (pt.Y - rect.Bottom) - (e.NewValue - e.OldValue);
            //    ctrl.Invalidate(new Rectangle(new Point(left, top), new Size(width, height)));
            //}
        }

        private void btnFlash_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
    }
}
