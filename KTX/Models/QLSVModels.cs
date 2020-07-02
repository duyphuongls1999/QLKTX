using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KTX.Models
{
    public class QLSVModels
    {
        [Required(ErrorMessage = "Vui lòng nhập mã sinh viên")]
        [Display(Name = "Mã sinh viên: ")]
        public String MaSV { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên sinh viên")]
        [Display(Name = "Họ và tên: ")]
        public String HoTen { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [Display(Name = "Ngày sinh: ")]
        public DateTime NgaySinh { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập giới tính")]
        [Display(Name = "Giới tính: ")]
        public String GioiTinh { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập CMND")]
        [Display(Name = "CMND: ")]
        public int CMND { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập quê quán")]
        [Display(Name = "Quê quán: ")]
        public String QueQuan { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập lớp")]
        [Display(Name = "Lớp: ")]
        public String Lop { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập khoa")]
        [Display(Name = "Khoa: ")]
        public String Khoa { set; get; }
    }
    class QLSVList
    {
        DBConnection db;
        public QLSVList()
        {
            db = new DBConnection();
        }
        public List<QLSVModels> getQLSV(string MaSV)
        {
            string sql;
            if (string.IsNullOrEmpty(MaSV))
                sql = "SELECT * FROM SINHVIEN";
            else
                sql = "SELECT * FROM SINHVIEN WHERE MaSV = " + MaSV;
            List<QLSVModels> svList = new List<QLSVModels>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            QLSVModels tmpSV;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpSV = new QLSVModels();
                tmpSV.MaSV = dt.Rows[i]["MaSV"].ToString();
                tmpSV.HoTen = dt.Rows[i]["HoTen"].ToString();
                tmpSV.NgaySinh = Convert.ToDateTime(dt.Rows[i]["NgaySinh"].ToString());
                tmpSV.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                tmpSV.CMND = Convert.ToInt32(dt.Rows[i]["CMND"].ToString());
                tmpSV.QueQuan = dt.Rows[i]["QueQuan"].ToString();
                tmpSV.Lop = dt.Rows[i]["Lop"].ToString();
                tmpSV.Khoa = dt.Rows[i]["Khoa"].ToString();
                svList.Add(tmpSV);
            }
            return svList;
        }
        public void AddSV(QLSVModels sv)
        {
            string sql = "INSERT  INTO SINHVIEN(MaSV, HoTen, NgaySinh, GioiTinh, CMND, QueQuan, Lop, Khoa) VALUES(N'" + sv.MaSV +
                "', N'" + sv.HoTen + "', N'" + sv.NgaySinh + "', N'" + sv.GioiTinh + "', N'" + sv.CMND + "', N'" + sv.QueQuan + "', N'" + sv.Lop + "', N'" + sv.Khoa + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            try { cmd.ExecuteNonQuery(); }
            catch (Exception e)
            { Console.WriteLine("Mã sinh viên đã tồn tại vui lòng nhập lại!" + e.Message); }
            cmd.Dispose();
            con.Close();
        }
        public void UpdateSV(QLSVModels sv)
        {
            string sql = "UPDATE SINHVIEN SET HoTen = N'" + sv.HoTen + "', NgaySinh= '" + sv.NgaySinh +
                "', GioiTinh= '" + sv.GioiTinh + "', CMND= '" + sv.CMND + "', QueQuan= '" + sv.QueQuan +
                "', Lop= '" + sv.Lop + "', Khoa= '" + sv.Khoa + "' WHERE MaSV = '" + sv.MaSV + "' ";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void DeleteSV(QLSVModels sv)
        {
            String sql = "DELETE SINHVIEN WHERE MaSV=  " + sv.MaSV;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Xóa không thành công vui lòng kiểm tra lại!" + e.Message);
            }
            cmd.Dispose();
            con.Close();
        }
    }
}