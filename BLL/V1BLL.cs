using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class V1BLL
    {
        private readonly COMMON comm = new COMMON();
        private string _HYNAME;
        public V1BLL(string HYNAME)
        {
            _HYNAME = HYNAME;
        }
        public int ImportExcelData(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                string billNo = "";
                string updateSql = "update LH_V1 set BAG_NO=@BAG_NO,I_E_FLAG=@I_E_FLAG where BILL_NO=@BILL_NO and HY_NAME=@HY_NAME";
                string insertSql = "insert into LH_V1(BILL_NO,BAG_NO,I_E_FLAG,HY_NAME) values(@BILL_NO,@BAG_NO,@I_E_FLAG,@HY_NAME)";
                Hashtable ht = new Hashtable();
                int rs = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    ht.Clear();

                    billNo = dr[1].ToString();
                    ht["BILL_NO"] = billNo;
                    ht["BAG_NO"] = dr[0].ToString();
                    ht["I_E_FLAG"] = dr[2].ToString().ToUpper();
                    ht["HY_NAME"] = _HYNAME;
                    if (CheckBiLLNOExist(billNo))
                    {
                        rs += comm.UID(updateSql, ht);
                    }
                    else
                    {
                        rs += comm.UID(insertSql, ht);
                    }
                }
                return rs;
            }
            return 0;
        }

        public bool CheckBiLLNOExist(string billNo)
        {
            string sql = "select count(1) from LH_V1 where BILL_NO=@BILL_NO and  HY_NAME=@HY_NAME";
            Hashtable ht = new Hashtable();
            ht["BILL_NO"] = billNo;
            ht["HY_NAME"] = _HYNAME;
            return comm.Exists(sql, ht);
        }
    }
}
