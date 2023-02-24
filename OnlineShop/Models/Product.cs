using OnlineShop.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }

        public int Discount { get; set; }
        public int Status { get; set; }
        public string Image { get; set; }
        public HttpPostedFileBase FileImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IsNewArrival { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int HotDeal { get; set; }



        public int Save(Product P)
        {
            SqlParameter[] prm = new SqlParameter[14];
            prm[0] = new SqlParameter("@Type", P.ProductId > 0 ? 3 : 1);
            prm[1] = new SqlParameter("@ProductName", P.ProductName);
            prm[2] = new SqlParameter("@UnitId", P.UnitId);
            prm[3] = new SqlParameter("@ColorId", P.ColorId);
            prm[4] = new SqlParameter("@BrandId", P.BrandId);
            prm[5] = new SqlParameter("@CategoryId", P.CategoryId);
            prm[6] = new SqlParameter("@SubCategoryId", P.SubCategoryId);
            prm[7] = new SqlParameter("@Discount", P.Discount);
            prm[8] = new SqlParameter("@Status", P.Status);
            prm[9] = new SqlParameter("@Image", P.Image);
            prm[10] = new SqlParameter("@IsNewArrival", P.IsNewArrival);
            prm[11] = new SqlParameter("@Description", P.Description);
            prm[12] = new SqlParameter("@HotDeal", P.HotDeal);
            prm[13] = new SqlParameter("@ProductId", P.ProductId);
            return SQL_Helper.ExecuteQuery("sp_Product", prm);
        }

        public List<Product> GetProductAll()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", 2);
            DataTable dt = SQL_Helper.GetData("sp_Product", prm);
            List<Product> list = new List<Product>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Product p = new Product();
                    p.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                    p.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                    p.UnitName = Convert.ToString(dt.Rows[i]["UnitName"]);
                    p.ColorName = Convert.ToString(dt.Rows[i]["ColorName"]);
                    p.BrandName = Convert.ToString(dt.Rows[i]["BrandName"]);
                    p.CategoryName = Convert.ToString(dt.Rows[i]["CategoryName"]);
                    p.SubCategoryName = Convert.ToString(dt.Rows[i]["SubCategoryName"]);
                    p.Discount = Convert.ToInt32(dt.Rows[i]["Discount"]);
                    p.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    p.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    p.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CreatedDate"]);
                    p.IsNewArrival = Convert.ToInt32(dt.Rows[i]["IsNewArrival"]);
                    p.Description = Convert.ToString(dt.Rows[i]["Description"]);
                    p.HotDeal = Convert.ToInt32(dt.Rows[i]["HotDeal"]);
                    list.Add(p);

                }
            }
            return list;
        }

        public Product Edit(int? ProductId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@ProductId", ProductId);
            DataTable dt = SQL_Helper.GetData("sp_Product", prm);
            if (dt.Rows.Count > 0)
            {

                Product P = new Product();
                P.ProductId = Convert.ToInt32(dt.Rows[0]["ProductId"]);
                P.ProductName = Convert.ToString(dt.Rows[0]["ProductName"]);
                P.Discount = Convert.ToInt32(dt.Rows[0]["Discount"]);
                P.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                P.Image = Convert.ToString(dt.Rows[0]["Image"]);
                P.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                P.IsNewArrival = Convert.ToInt32(dt.Rows[0]["IsNewArrival"]);
                P.Description = Convert.ToString(dt.Rows[0]["Description"]);
                P.UnitId = Convert.ToInt32(dt.Rows[0]["UnitId"]);
                P.BrandId = Convert.ToInt32(dt.Rows[0]["BrandId"]);
                P.ColorId = Convert.ToInt32(dt.Rows[0]["ColorId"]);
                P.CategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"]);
                P.SubCategoryId = Convert.ToInt32(dt.Rows[0]["SubCategoryId"]);
                P.HotDeal = Convert.ToInt32(dt.Rows[0]["HotDeal"]);

                return P;



            }
            return new Product();
        }
        public int Delete(int ProductId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 5);
            prm[1] = new SqlParameter("@ProductId", ProductId);
            return SQL_Helper.ExecuteQuery("sp_Product", prm);
        }
    }
}