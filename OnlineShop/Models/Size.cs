using OnlineShop.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Size
    {
        public int SizeId { get; set; }
        [Required]
        public string SizeName { get; set; }
        [Required]
        public int Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public int Save(Size obj)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type", obj.SizeId > 0 ? 2 : 1);
            prm[1] = new SqlParameter("@SizeId", obj.SizeId);
            prm[2] = new SqlParameter("@SizeName", obj.SizeName);
            prm[3] = new SqlParameter("@Status", obj.Status);
            return SQL_Helper.ExecuteQuery("sp_Size", prm);
        }
        public List<Size> GetSize()
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@SizeId", SizeId);
            DataTable dt = SQL_Helper.GetData("sp_Size", prm);
            List<Size> obj = new List<Size>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Size S = new Size();
                    S.SizeId = Convert.ToInt32(dt.Rows[i]["SizeId"]);
                    S.SizeName = Convert.ToString(dt.Rows[i]["SizeName"]);
                    S.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    S.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"]);

                    obj.Add(S);
                }
            }
            return obj;

        }
        public Size Edit(int SizeId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 5);
            prm[1] = new SqlParameter("@SizeId", SizeId);
            DataTable dt = SQL_Helper.GetData("sp_Size", prm);
            if (dt.Rows.Count > 0)
            {
                Size S = new Size();
                S.SizeId = Convert.ToInt32(dt.Rows[0]["SizeId"]);
                S.SizeName = Convert.ToString(dt.Rows[0]["SizeName"]);
                S.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                return S;
            }
            return new Size();
        }
        public int Delete(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@SizeId", Id);
            return SQL_Helper.ExecuteQuery("sp_Size", prm);
        }
    }
}