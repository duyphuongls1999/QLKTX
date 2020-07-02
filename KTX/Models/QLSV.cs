using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KTX.Models
{
    public class QLSV
    {
        [Required(ErrorMessage="Mời nhập mã sinh viên")]
        [Display(Name = "Mã sinh viên")]
        public string MaSV { set; get; }

        [Required(ErrorMessage = "Mời nhập tên sinh viên")]
        [Display(Name = "Tên sinh viên")]
        public string HoTen { set; get; }

        [Required(ErrorMessage = "Mời nhập ngày sinh")]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { set; get; }

        [Required(ErrorMessage="Mời nhập giới tính")]
        [Display(Name = "Giới tính")]
        public string GioiTinh { set; get;}

        [Required(ErrorMessage="Mời nhập CMND")]
        [Display(Name = "CMND")]
        public int CMND {set; get;}

        [Required(ErrorMessage="Mời nhập quê quán")]
        [Display(Name = "Quê quán")]
        public string QueQuan {set; get;}

        [Required(ErrorMessage="Mời nhập lớp")]
        [Display(Name = "Lớp")]
        public string Lop {set; get;}

        [Required(ErrorMessage = "Mời nhập khóa")]
        [Display(Name = "Khóa")]
        public string Khoa { set; get; }
    }
    class QLSVList
    {
        DBConnection db;
        public QLSVList()
        {
            db = new DBConnection();
        }
        public List<QLSV> getQLSV(string MaSV)
        {
            string sql;
            if (string.IsNullOrEmpty(MaSV))
                sql = "SELECT * FROM SINHVIEN ";
            else
                sql = "SELECT * FROM SINHVIEN WHERE MaSV = " + MaSV;
            List<QLSV> SVList = new List<QLSV>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            try
            {
                da.Fill(dt);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine("Error: " + e.Message); 
            }
            //da.Fill(dt);
            da.Dispose();
            con.Close();
            QLSV tmpSV;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpSV = new QLSV();
                tmpSV.MaSV = dt.Rows[i]["MaSV"].ToString();
                tmpSV.HoTen = dt.Rows[i]["HoTen"].ToString();
                tmpSV.NgaySinh = Convert.ToDateTime(dt.Rows[i]["NgaySinh"].ToString());
                tmpSV.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                tmpSV.CMND = Convert.ToInt32(dt.Rows[i]["CMND"].ToString());
                tmpSV.QueQuan = dt.Rows[i]["QueQuan"].ToString();
                tmpSV.Lop = dt.Rows[i]["Lop"].ToString();
                tmpSV.Khoa = dt.Rows[i]["Khoa"].ToString();
                SVList.Add(tmpSV);
            }
            return SVList;
        }
        public void AddSV(QLSV sv)
        {
            string sql = "INSERT INTO SINHVIEN(MaSV, HoTen, NgaySinh, GioiTinh, CMND, QueQuan, Lop, Khoa) VALUES('" + sv.MaSV + "', N'" + sv.HoTen + "',N'" + sv.NgaySinh + "',N'" + sv.GioiTinh + "','" + sv.CMND + "',N'" + sv.QueQuan + "','" + sv.Lop + "',N'" + sv.Khoa + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}