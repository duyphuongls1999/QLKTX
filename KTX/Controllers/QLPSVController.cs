using KTX.Models;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KTX.Controllers
{
    public class QLPSVController : BaseController
    {
        // GET: QLPSV
        public ActionResult Index(string searchString)
        {   
            var sv = new QLPSVModel();
            if (searchString == "") {
                SetAlert("Vui lòng nhập nội dung tìm kiếm", "error");
            }
                var model = sv.ListWhereAll(searchString);
                @ViewBag.SearchString = searchString;
                return View(model);
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string maSV)
        {
            var sv = new QLPSVModel().getByMaSV(maSV);
            return View(sv);
        }


        [HttpPost]
        public ActionResult Create(PHONGSV sinhVien)
        {
            if (ModelState.IsValid)
            {
                var dao = new QLPSVModel();
                var dao1 = new QLSVsModel();
                if (dao.Find(sinhVien.MaPhongSV) != null)
                {
                    SetAlert("Mã phòng sinh viên đã tồn tại", "error");
                    return RedirectToAction("Create", "QLPSV");
                }
                if (dao.Find(sinhVien.MaSV) != null)
                {
                    SetAlert("Mã sinh viên này đã có phòng", "error");
                    return RedirectToAction("Create", "QLPSV");
                }
                if (dao1.Find(sinhVien.MaSV) == null && dao1.Find(sinhVien.MaPhong) == null)
                {
                    SetAlert("Sinh viên hoặc phòng không có trong CSDL", "error");
                    return RedirectToAction("Create", "QLPSV");
                }
                
                String result = dao.Insert(sinhVien);

                if (!String.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm sinh viên vào phòng thành công", "success");
                    return RedirectToAction("Index", "QLPSV");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sinh viên vào phòng không thành công");
                }
            }
            return View();
        }


        public ActionResult Edit(PHONGSV sinhVien)
        {
            if (ModelState.IsValid)
            {
                var dao = new QLPSVModel();

                var result = dao.Update(sinhVien);
                if (result)
                {
                    SetAlert("Chỉnh sửa thông tin sinh viên thành công", "success");
                    return RedirectToAction("Index", "QLPSV");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sinh viên không thành công");
                }
            }
            return View();
        }

        public ActionResult Delete(string MaSV)
        {
            new QLPSVModel().Delete(MaSV);
            SetAlert("Bạn đã xóa sinh viên ra khỏi phòng!", "success");
            return RedirectToAction("Index", "QLPSV");
        }
    }
}