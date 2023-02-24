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
    public class Color
    {

        public int ColorId { get; set; }
        [Required]

        public string ColorName { get; set; }
        [Required]

        public int Status { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public int Save(Color obj)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type", obj.ColorId > 0 ? 2 : 1);
            prm[1] = new SqlParameter("@ColorId", obj.ColorId);
            prm[2] = new SqlParameter("@ColorName", obj.ColorName);
            prm[3] = new SqlParameter("@Status", obj.Status);
            return SQL_Helper.ExecuteQuery("sp_Color", prm);
        }
        public List<Color> GetColor()
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@ColorId", ColorId);
            DataTable dt = SQL_Helper.GetData("sp_Color", prm);
            List<Color> obj = new List<Color>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Color C = new Color();
                    C.ColorId = Convert.ToInt32(dt.Rows[i]["ColorId"]);
                    C.ColorName = Convert.ToString(dt.Rows[i]["ColorName"]);
                    C.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"]);
                    C.Status = Convert.ToInt32(dt.Rows[i]["Status"]);

                    obj.Add(C);
                }
            }
            return obj;

        }
        public Color Edit(int ColorId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 5);
            prm[1] = new SqlParameter("@ColorId", ColorId);
            DataTable dt = SQL_Helper.GetData("sp_Color", prm);
            if (dt.Rows.Count > 0)
            {
                Color C = new Color();
                C.ColorId = Convert.ToInt32(dt.Rows[0]["ColorId"]);
                C.ColorName = Convert.ToString(dt.Rows[0]["ColorName"]);
                C.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                return C;
            }
            return new Color();
        }
        public int Delete(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@ColorId", Id);
            return SQL_Helper.ExecuteQuery("sp_Color", prm);
        }

    }
}