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
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        [Required]
        public HttpPostedFileBase FileImage { get; set; }
        [Required]
        public int Status { get; set; }

        public bool IsDeleted { get; set; }
        public int Save(SubCategory obj)
        {
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@Type", obj.SubCategoryId > 0 ? 2 : 1);
            prm[1] = new SqlParameter("@SubCategoryId", obj.SubCategoryId);
            prm[2] = new SqlParameter("@CategoryId", obj.CategoryId);
            prm[3] = new SqlParameter("@SubCategoryName", obj.SubCategoryName);
            prm[4] = new SqlParameter("@Status", obj.Status);
            prm[5] = new SqlParameter("@Image", obj.Image);
            return SQL_Helper.ExecuteQuery("sp_SubCategory", prm);
        }
        public List<SubCategory> GetSubCategories(int? CategoryId = null)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@SubCategoryId", CategoryId);
            DataTable dt = SQL_Helper.GetData("sp_SubCategory", prm);
            List<SubCategory> obj = new List<SubCategory>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SubCategory C = new SubCategory();
                    C.SubCategoryId = Convert.ToInt32(dt.Rows[i]["SubCategoryId"]);
                    C.CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                    C.CategoryName = Convert.ToString(dt.Rows[i]["CategoryName"]);
                    C.SubCategoryName = Convert.ToString(dt.Rows[i]["SubCategoryName"]);
                    C.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    C.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    obj.Add(C);
                }
            }
            return obj;

        }
        public SubCategory Edit(int SubCategoryId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 5);
            prm[1] = new SqlParameter("@SubCategoryId", SubCategoryId);
            DataTable dt = SQL_Helper.GetData("sp_SubCategory", prm);
            if (dt.Rows.Count > 0)
            {
                SubCategory C = new SubCategory();
                C.SubCategoryId = Convert.ToInt32(dt.Rows[0]["SubCategoryId"]);
                C.CategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"]);
                C.SubCategoryName = Convert.ToString(dt.Rows[0]["SubCategoryName"]);
                C.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                C.Image = Convert.ToString(dt.Rows[0]["Image"]);
                return C;
            }
            return new SubCategory();
        }
        public int Delete(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@SubCategoryId", Id);
            return SQL_Helper.ExecuteQuery("sp_SubCategory", prm);
        }
    }
}