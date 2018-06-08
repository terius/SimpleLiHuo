using DAL;
using Helpers;
using Model;
using System.Collections;
using System.Data;

namespace BLL
{
    public class UserBLL
    {
        private readonly COMMON comm = new COMMON();
        public UserInfo GetUserInfoById(int userId)
        {
            Hashtable ht = new Hashtable();
            ht["id"] = userId;
            DataRow dr = comm.GetOneRow("select * from users where id=@id", ht);
            if (dr != null)
            {
                UserInfo info = new UserInfo();
                info.id = userId;
                info.HY_NAME = dr["HY_NAME"].ToString();
                info.UserName = dr["User_name"].ToString();
                info.Lever = dr["Lever"].ToString();
                return info;
            }
            return null;
        }

        public bool SaveUserInfo(UserInfo info)
        {
            Hashtable ht = new Hashtable();
            if (info.id  > 0)
            {
                ht["id"] = info.id;
            }
           
            if (!string.IsNullOrEmpty(info.UserPassword))
            {
                ht["User_Pass"] = StringHelper.Sha256(info.UserPassword);
            }

            ht["HY_NAME"] = info.HY_NAME;
            ht["User_name"] = info.UserName;
            ht["Lever"] = info.Lever;
            if (info.id > 0)
            {
                return comm.UpdateTable(ht, "users") > 0 ? true : false;
            }
            else
            {
                return comm.InsertTable(ht, "users") > 0 ? true : false;
            }
           
        }

        public bool CheckUserNameExist(string newName,int id =0)
        {
            if (id > 0)
            {
                string sql = "select count(1) from users where User_name = @User_name  and id != @id";
                Hashtable ht = new Hashtable();
                ht["User_name"] = newName;
                ht["id"] = id;
                return comm.Exists(sql, ht);
            }
            else
            {
                string sql = "select count(1) from users where User_name = @User_name";
                Hashtable ht = new Hashtable();
                ht["User_name"] = newName;
                return comm.Exists(sql, ht);
            }
          
        }

        public bool DeleteUser(int id)
        {
            string sql = "delete from users where id=@id";
            Hashtable ht = new Hashtable();
            ht["id"] = id;
            return comm.UID(sql, ht) > 0 ? true : false;
        }

        public bool CheckUserCodeExist(string newCode, int id = 0)
        {
            if (id > 0)
            {
                string sql = "select count(1) from users where HY_NAME = @HY_NAME  and id != @id";
                Hashtable ht = new Hashtable();
                ht["HY_NAME"] = newCode;
                ht["id"] = id;
                return comm.Exists(sql, ht);
            }
            else
            {
                string sql = "select count(1) from users where HY_NAME = @HY_NAME";
                Hashtable ht = new Hashtable();
                ht["HY_NAME"] = newCode;
                return comm.Exists(sql, ht);
            }

        }
    }
}
