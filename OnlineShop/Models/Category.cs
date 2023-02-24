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
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]

        public int Status { get; set; }
        [Required]

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public string CategoryImage { get; set; }
        [Required]
        public HttpPostedFileBase FileImage { get; set; }

        public int Save(Category obj)
        {
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@Type", obj.CategoryId > 0 ? 2 : 1);
            prm[1] = new SqlParameter("@CategoryId", obj.CategoryId);
            prm[2] = new SqlParameter("@CategoryName", obj.CategoryName);
            prm[3] = new SqlParameter("@Status", obj.Status);
            prm[4] = new SqlParameter("@Description", obj.Description);
            prm[5] = new SqlParameter("@CategoryImage", obj.CategoryImage);
            return SQL_Helper.ExecuteQuery("sp_Category", prm);
        }
        public List<Category> GetCategories()
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@CategoryId", CategoryId);
            DataTable dt = SQL_Helper.GetData("sp_Category", prm);
            List<Category> obj = new List<Category>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Category C = new Category();
                    C.CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                    C.CategoryName = Convert.ToString(dt.Rows[i]["CategoryName"]);
                    C.Description = Convert.ToString(dt.Rows[i]["Description"]);
                    C.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    C.CategoryImage = Convert.ToString(dt.Rows[i]["CategoryImage"]);
                    C.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"]);
                    obj.Add(C);
                }
            }
            return obj;

        }
        public Category Edit(int CategoryId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 5);
            prm[1] = new SqlParameter("@CategoryId", CategoryId);
            DataTable dt = SQL_Helper.GetData("sp_Category", prm);
            if (dt.Rows.Count > 0)
            {
                Category C = new Category();
                C.CategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"]);
                C.CategoryName = Convert.ToString(dt.Rows[0]["CategoryName"]);
                C.Description = Convert.ToString(dt.Rows[0]["Description"]);
                C.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                C.CategoryImage = Convert.ToString(dt.Rows[0]["CategoryImage"]);
                return C;
            }
            return new Category();
        }
        public int Delete(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@CategoryId", Id);
            return SQL_Helper.ExecuteQuery("sp_Category", prm);
        }

        public Category ShowDescription(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 6);
            prm[1] = new SqlParameter("@CategoryId", Id);
            DataTable dt = SQL_Helper.GetData("sp_Category", prm);
            if (dt.Rows.Count > 0)
            {
                Category x = new Category();
                x.Description = Convert.ToString(dt.Rows[0]["Description"]);
                return x;
            }
            return new Category();
        }
    }
}