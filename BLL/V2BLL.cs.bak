using DAL;
using Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;

namespace BLL
{
    public class V2BLL
    {
        private readonly COMMON comm = new COMMON();
        private string _HYNAME;
        private readonly string loopTimes = System.Configuration.ConfigurationManager.AppSettings["looptimes"];
        public V2BLL(string HYNAME)
        {
            _HYNAME = HYNAME;
        }

        public string GetMAXBLLNO()
        {
            string sql = "select BILL_NO from LH_V2 where  SCAN_NO=(select max(SCAN_NO) from LH_V2 where HY_NAME=@HY_NAME)";
            Hashtable ht = new Hashtable();
            ht["HY_NAME"] = _HYNAME;
            return comm.GetStringData(sql, ht);
        }

        public string SaveToV2(string sn)
        {
            string lastSN = "";
            Hashtable ht = new Hashtable();
            ht["bag_no"] = sn;
            ht["HY_NAME"] = _HYNAME;
            string sql = "select * from LH_V1 where bag_no =@bag_no and HY_NAME =@HY_NAME";
            DataTable billNoList = comm.Query(sql, ht);
            int rs = 0;
            if (billNoList != null && billNoList.Rows.Count > 0)
            {
                string insertSql = "update LH_V1 set scan_flag=1 where id = @id;"
                    + "delete from LH_V2 where bill_no =@bill_no and HY_NAME = @HY_NAME;"
                    + "insert into LH_V2(bill_no,HY_NAME,bag_no,i_e_flag,scan_no,scan_time,read_flag,send_flag) "
                    + "values(@bill_no,@HY_NAME,@bag_no,@i_e_flag,(select isnull(max(scan_no),0) from LH_V2 where HY_NAME = @HY_NAME) + 1,getdate(),0,2);";
                foreach (DataRow dr in billNoList.Rows)
                {
                    ht.Clear();
                    ht["id"] = Convert.ToInt32(dr["id"]);
                    ht["bill_no"] = dr["bill_no"].ToString();
                    ht["HY_NAME"] = dr["HY_NAME"].ToString();
                    ht["bag_no"] = dr["bag_no"].ToString();
                    ht["i_e_flag"] = dr["i_e_flag"].ToString();
                    lastSN = dr["bill_no"].ToString();
                    rs += comm.UID(insertSql, ht);

                }

            }
            else
            {
                string insertSql2 = "delete from LH_V2 where bill_no =@bill_no and HY_NAME = @HY_NAME;"
                    + "insert into LH_V2(bill_no,HY_NAME,scan_no,scan_time,read_flag,send_flag) "
                    + "values(@bill_no,@HY_NAME,(select isnull(max(scan_no),0) from LH_V2 where HY_NAME = @HY_NAME) + 1,getdate(),0,2);";

                ht.Clear();
                ht["bill_no"] = sn;
                ht["HY_NAME"] = _HYNAME;
                //ht["bag_no"] = dr["bag_no"].ToString();
                //  ht["i_e_flag"] = dr["i_e_flag"].ToString();
                lastSN = sn;
                rs += comm.UID(insertSql2, ht);

            }

            return lastSN;
        }

        public bool GetStatus(string billNo, ref bool[] s)
        {
            bool rs = false;
            string sql = "select top 1 RSK_FLAG,OP_TYPE,READ_FLAG from LH_V2 where BILL_NO =@BILL_NO and HY_NAME = @HY_NAME";
            string sql2 = "update LH_V2 set send_flag =3 where BILL_NO =@BILL_NO and HY_NAME = @HY_NAME";
            Hashtable ht = new Hashtable();
            ht["BILL_NO"] = billNo;
            ht["HY_NAME"] = _HYNAME;
            int i = 0;
            int loop = Convert.ToInt32(loopTimes);
            while (true)
            {
                if (i == loop)
                {
                    comm.UID(sql2, ht);
                    return false;
                }
                DataRow dr = comm.GetOneRow(sql, ht);
                if (dr != null && dr[2].ToString() == "1")
                {
                    s[0] = dr[0].ToString() == "True" ? true : false;
                    s[1] = dr[0].ToString() == "False" ? true : false;
                    s[2] = dr[1].ToString() == "04" ? true : false;
                    rs = true;
                    break;
                }
                i++;
                Thread.Sleep(1000);
            }
            return rs;
        }

        public bool GetNewData(DataTable gridTable)
        {
            bool dataIsChange = false;
            int maxNum = Convert.ToInt32(gridTable.Rows.Count > 0 ? gridTable.Rows[0][0] : 0);
            string sql = "select SCAN_NO,BILL_NO,VOYAGE_NO,MAIN_G_NAME,I_E_FLAG,I_E_PORT,D_DATE,RSK_FLAG,OP_TYPE "
                + " from LH_V2 where HY_NAME= @HY_NAME and SCAN_NO > @SCAN_NO order by SCAN_NO ";
            Hashtable ht = new Hashtable();
            ht["HY_NAME"] = _HYNAME;
            ht["SCAN_NO"] = maxNum;
            DataTable newTable = comm.Query(sql, ht);
            if (newTable != null && newTable.Rows.Count > 0)
            {
                dataIsChange = true;
                int rowLength = gridTable.Rows.Count;
                foreach (DataRow dr in newTable.Rows)
                {
                    for (int i = gridTable.Rows.Count - 1; i >= 0; i--)
                    {
                        if (gridTable.Rows[i][1].ToString().Equals(dr[1].ToString()))
                        {
                            gridTable.Rows[i].Delete();
                            gridTable.AcceptChanges();
                            break;
                        }
                    }
                }

                foreach (DataRow dr in newTable.Rows)
                {
                    DataRow newRow = gridTable.NewRow();
                    for (int i = 0; i < newTable.Columns.Count; i++)
                    {
                        newRow[i] = dr[i];
                    }
                    gridTable.Rows.InsertAt(newRow, 0);
                }
            }
            return dataIsChange;
        }
    }
}
