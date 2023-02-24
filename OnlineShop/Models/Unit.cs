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
    public class Unit
    {
        public int Unitid { get; set; }
        [Required]
        public string UnitName { get; set; }
        [Required]

        public int Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public int Save(Unit obj)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type", obj.Unitid > 0 ? 2 : 1);
            prm[1] = new SqlParameter("@Unitid", obj.Unitid);
            prm[2] = new SqlParameter("@UnitName", obj.UnitName);
            prm[3] = new SqlParameter("@Status", obj.Status);
            return SQL_Helper.ExecuteQuery("sp_Unit", prm);
        }
        public List<Unit> GetUnit()
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@Unitid", Unitid);
            DataTable dt = SQL_Helper.GetData("sp_Unit", prm);
            List<Unit> obj = new List<Unit>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Unit U = new Unit();
                    U.Unitid = Convert.ToInt32(dt.Rows[i]["Unitid"]);
                    U.UnitName = Convert.ToString(dt.Rows[i]["UnitName"]);
                    U.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    U.CreationDate = Convert.ToDateTime(dt.Rows[i]["CreationDate"]);

                    obj.Add(U);
                }
            }
            return obj;

        }
        public Unit Edit(int UnitId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 5);
            prm[1] = new SqlParameter("@UnitId", UnitId);
            DataTable dt = SQL_Helper.GetData("sp_Unit", prm);
            if (dt.Rows.Count > 0)
            {
                Unit U = new Unit();
                U.Unitid = Convert.ToInt32(dt.Rows[0]["Unitid"]);
                U.UnitName = Convert.ToString(dt.Rows[0]["UnitName"]);
                U.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                return U;
            }
            return new Unit();
        }
        public int Delete(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@UnitId", Id);
            return SQL_Helper.ExecuteQuery("sp_Unit", prm);
        }

    }
}