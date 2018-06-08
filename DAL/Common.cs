using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
namespace DAL
{
    public class COMMON
    {

        public int GetMaxID()
        {
            string sql = "select seq_id.nextval from dual";
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }

        public int UID(string Sql)
        {

            return DbHelperSQL.ExecuteSql(Sql);
        }


        public int UID(string sql, Hashtable pararm = null)
        {
            //   SqlParameter[] parameters = BuildSqlParameters(pararm);
            return DbHelperSQL.ExecuteSql(sql, pararm);
        }

        //public int UIDTran(Dictionary<string,IList<SqlParameter>> SQLStringList)
        //{
        //    Dictionary<string, SqlParameter[]> tranSQLStringList = new Dictionary<string, SqlParameter[]>();
        //    foreach (KeyValuePair<string, IList<SqlParameter>> myDE in SQLStringList)
        //    {
        //        IList<SqlParameter> htParams = (IList<SqlParameter>)myDE.Value;
        //        SqlParameter[] parameters = htParams.ToArray<SqlParameter>();
        //        tranSQLStringList.Add(myDE.Key, parameters);
        //    }

        //    return DbHelperSQL.ExecuteSqlTran(tranSQLStringList);
        //}



        public object GetSingle(string sql, Hashtable pararm = null)
        {
            // SqlParameter[] parameters = BuildSqlParameters(pararm);
            return DbHelperSQL.GetSingle(sql, pararm);
        }





        public string GetStringData(string sql, Hashtable pararm = null)
        {
            string strobj = string.Empty;
            //     SqlParameter[] parameters = BuildSqlParameters(pararm);
            object ob = DbHelperSQL.GetSingle(sql, pararm);
            try
            {
                if (ob != null)
                {
                    strobj = ob.ToString();
                }
            }
            catch
            {

            }

            return strobj;
        }

        public int GetIntData(string sql, Hashtable pararm = null)
        {
            int intValue = 0;
            //     SqlParameter[] parameters = BuildSqlParameters(pararm);
            object ob = DbHelperSQL.GetSingle(sql, pararm);
            try
            {
                if (ob != null)
                {
                    if (int.TryParse(ob.ToString(), out intValue))
                    {
                        return intValue;
                    }
                    return 0;

                }
            }
            catch
            {

            }

            return intValue;
        }




        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string sql)
        {

            return DbHelperSQL.Exists(sql);
        }


        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string sql, Hashtable paramlist = null)
        {
            // SqlParameter[] cmdParms = BuildSqlParameters(paramlist);
            return DbHelperSQL.Exists(sql, paramlist);
        }




        public DataRow GetOneRow(string sql, Hashtable paramlist = null)
        {
            DataTable dt = Query(sql, paramlist);
            DataRow row = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                row = dt.Rows[0];
            }

            return row;
        }





        public DataTable Query(string sqlStr, Hashtable paramlist = null)
        {
            DataTable dt = null;

            //  SqlParameter[] cmdParms = BuildSqlParameters(paramlist);
            dt = DbHelperSQL.QueryReturnDataTable(sqlStr, paramlist);

            return dt;
        }

        //private SqlParameter[] BuildSqlParameters(Hashtable HTParamList)
        //{
        //    if (HTParamList == null || HTParamList.Count < 1)
        //    {
        //        return null;
        //    }
        //    SqlParameter[] oracleParams = null;
        //    IList<SqlParameter> oracleParamList = new List<SqlParameter>();
        //    if (HTParamList != null && HTParamList.Count > 0)
        //    {
        //        IDictionaryEnumerator enumerator = HTParamList.GetEnumerator();
        //        string keyStr = "";
        //        while (enumerator.MoveNext())
        //        {
        //            keyStr = enumerator.Key.ToString().Trim();
        //            if (keyStr.IndexOf("@") != 0)
        //            {
        //                keyStr = "@" + keyStr;
        //            }
        //            oracleParamList.Add(new SqlParameter(keyStr, enumerator.Value));
        //        }
        //        oracleParams = oracleParamList.ToArray<SqlParameter>();
        //    }

        //    return oracleParams;
        //}


        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="PageSize">ÿҳ��ʾ��</param>
        /// <param name="PageIndex">ҳ��������1��ʼ��</param>
        /// <param name="sqlColumns">��ʾ���ֶ�</param>
        /// <param name="sqlTable">����</param>
        /// <param name="sqlWhere">where����(��and��ʼ)</param>
        /// <param name="sqlOrder">����</param>
        /// <param name="totalCount">��ѯ����</param>
        /// <param name="ht">��ѯ����</param>
        /// <returns></returns>
        public DataTable PageQuery(int PageSize, int PageIndex, string sqlColumns,
            string sqlTable, string sqlWhere, string sqlOrder, ref int totalCount, Hashtable ht = null)
        {

            StringBuilder sb = new StringBuilder();
            if (PageIndex <= 1)
            {
                PageIndex = 1;
            }
            if (PageIndex == 1)
            {
                sb.AppendFormat("select top {0} {1} from {2} where 1=1 {3} {4}", PageSize,
                    string.IsNullOrEmpty(sqlColumns) ? "*" : sqlColumns, sqlTable, sqlWhere, sqlOrder);
            }
            else
            {
                sb.AppendFormat("select top {0} {1} from {2} where 1=1 {3}  and id not in (select top {5} id from {2} where 1=1 {3} {4}) {4}", PageSize,
                    string.IsNullOrEmpty(sqlColumns) ? "*" : sqlColumns, sqlTable, sqlWhere, sqlOrder, (PageIndex - 1) * PageSize);
            }

            string sqlCount = string.Format("select count(1) from {0}  where 1=1 {1}", sqlTable, sqlWhere);
            totalCount = Convert.ToInt32(GetSingle(sqlCount, ht));
            DataTable dt = Query(sb.ToString(), ht);
            return dt;
        }


        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="PageCount">��ҳ��</param>
        /// <param name="DataSize">��������</param>
        /// <param name="table">����</param>
        /// <param name="key">�����ֶ�</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="order">���򣨼ǵü� asc ���� desc��</param>
        /// <param name="beginNUM">��ʼλ�ã�һ��Ϊ0��</param>
        /// <param name="PageIndex">��ǰҳ��������1��ʼ��</param>
        /// <param name="PageSize">һҳ��ʾ����������</param>
        /// <param name="htParam">����</param>
        /// <returns></returns>
        public DataSet PageQueryWithParams(ref int PageCount, ref int DataSize, string table,
            string key, string strField, string strWhere, string order, int beginNUM, int PageIndex, int PageSize)
        {
            SqlParameter PCount = new SqlParameter("@PCount", SqlDbType.Int);
            PCount.Direction = ParameterDirection.Output;

            SqlParameter RCount = new SqlParameter("@RCount", SqlDbType.Int);
            RCount.Direction = ParameterDirection.Output;


            SqlParameter[] parameters = {
                    PCount,RCount,
                    new SqlParameter("@sys_Table",SqlDbType.NVarChar),
                    new SqlParameter("@sys_Key", SqlDbType.VarChar),
                    new SqlParameter("@sys_Fields", SqlDbType.NVarChar),
                    new SqlParameter("@sys_Where", SqlDbType.NVarChar),
                    new SqlParameter("@sys_Order", SqlDbType.NVarChar),
                    new SqlParameter("@sys_Begin", SqlDbType.Int),
                    new SqlParameter("@sys_PageIndex", SqlDbType.Int),
                    new SqlParameter("@sys_PageSize", SqlDbType.Int)

                    };
            parameters[2].Value = table;
            parameters[3].Value = key;
            parameters[4].Value = strField;
            parameters[5].Value = strWhere;
            parameters[6].Value = order;
            parameters[7].Value = beginNUM;
            parameters[8].Value = PageIndex;
            parameters[9].Value = PageSize;
            DataSet ds = DbHelperSQL.RunProcedure("sys_Page_v2", parameters, "ds");
            PageCount = Convert.ToInt32(PCount.Value);
            DataSize = Convert.ToInt32(RCount.Value);
            return ds;
        }


        public DateTime GetDBDate()
        {
            string sql = "select getdate()";
            object ob = DbHelperSQL.GetSingle(sql);
            DateTime dt = Convert.ToDateTime(ob);
            return dt;
        }


        public int InsertByHashtable(string tableName, Hashtable paramlist)
        {
            StringBuilder sb = new StringBuilder("insert into {0}({1}) values({2})");
            StringBuilder sbColumns = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            foreach (DictionaryEntry item in paramlist)
            {
                if (sbColumns.Length == 0)
                {
                    sbColumns.Append(item.Key);
                }
                else
                {
                    sbColumns.Append("," + item.Key);
                }
                if (sbValues.Length == 0)
                {
                    sbValues.Append("@" + item.Key);
                }
                else
                {
                    sbValues.Append(",@" + item.Key);
                }
            }
            string sql = string.Format("insert into {0}({1}) values({2})", tableName, sbColumns.ToString(), sbValues.ToString());
            return DbHelperSQL.ExecuteSql(sql, paramlist);

        }


        public int InsertReturnID(string sql, Hashtable paramlist = null)
        {
            //  SqlParameter[] cmdParms = BuildSqlParameters(paramlist);
            sql += ";select @@IDENTITY as id";
            int rs = 0;
            using (IDataReader dr = DbHelperSQL.ExecuteReader(sql, paramlist))
            {
                if (dr.Read())
                {
                    rs = Convert.ToInt32(dr["id"]);
                }
                dr.Close();
            }
            return rs;
        }

        public int InsertTable(Hashtable ht, string tableName)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbVal = new StringBuilder();
            foreach (DictionaryEntry item in ht)
            {
                sb.AppendFormat("{0},", item.Key);
                sbVal.AppendFormat("@{0},", item.Key);
            }
            string InsertSql = string.Format("insert into {0}({1}) values({2})", tableName, sb.ToString().Trim(','), sbVal.ToString().Trim(','));
            return DbHelperSQL.ExecuteSql(InsertSql, ht);
        }

        public int UpdateTable(Hashtable ht, string tableName, string idName = "id")
        {

            StringBuilder sb = new StringBuilder();
            foreach (DictionaryEntry item in ht)
            {
                if (!item.Key.ToString().Equals(idName, StringComparison.CurrentCultureIgnoreCase))
                {
                    sb.AppendFormat(" {0} = @{0},", item.Key);
                }
            }
            string UpdateSql = string.Format("update {0} set {1} where {2}=@{2}", tableName, sb.ToString().Trim(','), idName);
            return DbHelperSQL.ExecuteSql(UpdateSql, ht);
        }




    }
}
