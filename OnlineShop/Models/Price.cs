using OnlineShop.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Price
    {
        public int PriceId { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal Prices { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public int Status { get; set; }

        public int Save(Price obj)
        {
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@Type", 1);
            prm[1] = new SqlParameter("@PriceId", obj.PriceId);
            prm[2] = new SqlParameter("@SizeId", obj.SizeId);
            prm[3] = new SqlParameter("@ProductId", obj.ProductId);
            prm[4] = new SqlParameter("@Prices", obj.Prices);
            prm[5] = new SqlParameter("@Status", obj.Status);
            return SQL_Helper.ExecuteQuery("sp_Prices", prm);
        }
        public List<Price> GetPriceAll()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", 2);

            DataTable dt = SQL_Helper.GetData("Sp_Prices", prm);
            List<Price> list = new List<Price>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Price p = new Price();
                    p.PriceId = Convert.ToInt32(dt.Rows[i]["Price_Id"]);
                    p.SizeName = Convert.ToString(dt.Rows[i]["SizeName"]);
                    p.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                    p.Prices = Convert.ToDecimal(dt.Rows[i]["Prices"]);

                    list.Add(p);

                }

            }
            return list;
        }


        public List<Price> GetPriceOne(int ProductId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@ProductId", ProductId);
            List<Price> prices = new List<Price>();
            DataTable dt = SQL_Helper.GetData("Sp_Prices", prm);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Price p = new Price();
                    p.SizeName = Convert.ToString(dt.Rows[i]["SizeName"]);
                    p.Prices = Convert.ToDecimal(dt.Rows[i]["Prices"]);
                    prices.Add(p);
                }
            }
            return prices;

        }
    }
}