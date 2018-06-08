using BLL;
using DAL;
using Model;
using System;
using System.Collections;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace LiHuo
{
    public partial class ScanFast : Form
    {


        private readonly string fastLoopTimes = System.Configuration.ConfigurationManager.AppSettings["FastFlashTime"];
        private readonly COMMON comm = new COMMON();
        private V2BLL v2BLL;
        public UserInfo userInfo { get; set; }
        private delegate void ReflashGrid();//代理
        int scanCount = 0;

        public ScanFast()
        {
            InitializeComponent();
        }

        private void UserManager_Load(object sender, EventArgs e)
        {

            v2BLL = new V2BLL(userInfo.HY_NAME);
            InitGridView();
            tbNo.Focus();
            labTitle.Text = "当前用户： " + userInfo.HY_NAME;
            //  LoadV2data();

            // timer1.Enabled = true;
            // reFlashTime = 1000 * (Convert.ToInt32(fastLoopTimes));

            //  Thread th = new Thread(new ThreadStart(LoadV2data));
            // th.IsBackground = true;
            //  th.Start();
            //  ReflashGrid fc = new ReflashGrid(LoadV2data);
            //  fc.BeginInvoke(null, null);
        }



        private DataTable gridTable;
        private readonly object obLoad = new object();

        private void LoadV2data()
        {
            lock (obLoad)
            {
                while (true)
                {


                    Hashtable ht = new Hashtable();
                    ht["HY_NAME"] = userInfo.HY_NAME;
                    DataTable dt = comm.Query("select SCAN_NO,BILL_NO,BAG_NO,MAIN_G_NAME,I_E_FLAG,"
                        + "(case RSK_FLAG when 1 then '1' when 0 then '0' else '' end) RSK_FLAG,"
                        + "(case OP_TYPE when '04' then '1' else '' end) OP_TYPE,"
                        + "HY_NAME,TRADE_NAME,SCAN_TIME"
                        + " from LH_V2 where HY_NAME= @HY_NAME order by SCAN_NO desc", ht);
                    // this.superGrid1.DataSource = gridTable;
                    if (this.superGrid1.InvokeRequired)
                    {
                        this.superGrid1.Invoke(new MethodInvoker(delegate
                        {
                            //this.superGrid1.Refresh();
                            this.superGrid1.DataSource = dt;
                            //  this.superGrid1.Update();
                            // this.superGrid1.EndEdit();

                        }));
                    }
                    else
                    {
                        //  this.superGrid1.Refresh();
                        this.superGrid1.DataSource = dt;
                        // this.superGrid1.Update();
                        // this.superGrid1.EndEdit();
                    }
                    //  labAllCount.Text = gridTable.Rows.Count.ToString();
                    Thread.Sleep(10000);
                }
            }
        }



        private void InitGridView()
        {
            superGrid1.EnableHeadersVisualStyles = false;
            CommonHelper.AddColumn(this.superGrid1, "序号", "NO");
            CommonHelper.AddColumn(this.superGrid1, "扫描条码", "SCAN_NO");
            CommonHelper.AddColumn(this.superGrid1, "扫描时间", "SCAN_TIME");

            //CommonHelper.AddColumn(this.superGrid1, "扫描计数", "SCAN_NO");
            //CommonHelper.AddColumn(this.superGrid1, "分运单号", "BILL_NO");
            //CommonHelper.AddColumn(this.superGrid1, "包裹号", "BAG_NO");
            //CommonHelper.AddColumn(this.superGrid1, "货品名称", "MAIN_G_NAME");
            //CommonHelper.AddColumn(this.superGrid1, "进出口标识", "I_E_FLAG");
            //// CommonHelper.AddColumn(this.superGrid1, "进出口岸代码", "I_E_PORT");
            ////  CommonHelper.AddColumn(this.superGrid1, "申报日期", "D_DATE");
            //CommonHelper.AddColumn(this.superGrid1, "是否布控", "RSK_FLAG");
            //CommonHelper.AddColumn(this.superGrid1, "无数据标识", "OP_TYPE");
            //CommonHelper.AddColumn(this.superGrid1, "货运公司名称", "HY_NAME");
            //CommonHelper.AddColumn(this.superGrid1, "运营公司名称", "TRADE_NAME");
            //CommonHelper.AddColumn(this.superGrid1, "扫描时间", "SCAN_TIME");
            //gridTable = comm.Query("select SCAN_NO,BILL_NO,BAG_NO,MAIN_G_NAME,I_E_FLAG,"
            //          + "(case RSK_FLAG when 1 then '1' when 0 then '0' else '' end) RSK_FLAG,"
            //          + "(case OP_TYPE when '04' then '1' else '' end) OP_TYPE,"
            //          + "HY_NAME,TRADE_NAME,SCAN_TIME"
            //          + " from LH_V2 where 1=0 order by SCAN_NO desc");
            //this.superGrid1.DataSource = gridTable;
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
            string lastSN = v2BLL.SaveToV2(sn);
            scanCount++;
            this.superGrid1.Rows.Insert(0, new string[] { scanCount.ToString(), sn + "已录入", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
            this.superGrid1.Rows[0].Selected = true;
            tbNo.Text = "";
            tbNo.Focus();
        }




    }
}
