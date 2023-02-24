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
    public class Brands
    {
        
       public int BrandId { get; set; }
        [Required]

        public string BrandName { get; set; }
        [Required]

        public int Status { get; set; }
        public string Image { get; set; }
        [Required]

        public HttpPostedFileBase FileImage { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }

        public int Save(Brands obj)
        {
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@Type", obj.BrandId > 0 ? 2 : 1);
            prm[1] = new SqlParameter("@BrandId", obj.BrandId);
            prm[2] = new SqlParameter("@BrandName", obj.BrandName);
            prm[3] = new SqlParameter("@Status", obj.Status);
            prm[4] = new SqlParameter("@Image", obj.Image);
            return SQL_Helper.ExecuteQuery("sp_Brand", prm);
        }
        public List<Brands> GetBrand()
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@BrandId", BrandId);
            DataTable dt = SQL_Helper.GetData("sp_Brand", prm);
            List<Brands> obj = new List<Brands>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Brands B = new Brands();
                    B.BrandId = Convert.ToInt32(dt.Rows[i]["BrandId"]);
                    B.BrandName = Convert.ToString(dt.Rows[i]["BrandName"]);
                    B.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    B.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    B.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"]);

                    obj.Add(B);
                }
            }
            return obj;

        }
        public Brands Edit(int BrandId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 5);
            prm[1] = new SqlParameter("@BrandId", BrandId);
            DataTable dt = SQL_Helper.GetData("sp_Brand", prm);
            if (dt.Rows.Count > 0)
            {
                Brands B = new Brands();
                B.BrandId = Convert.ToInt32(dt.Rows[0]["BrandId"]);
                B.BrandName = Convert.ToString(dt.Rows[0]["BrandName"]);
                B.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                B.Image = Convert.ToString(dt.Rows[0]["Image"]);
                return B;
            }
            return new Brands();
        }
        public int Delete(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@BrandId", Id);
            return SQL_Helper.ExecuteQuery("sp_Brand", prm);
        }
    }
}