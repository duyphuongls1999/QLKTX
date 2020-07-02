using KTX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTX.Controllers
{
    public class QLSVController : Controller
    {
        // GET: QLSV
        public ActionResult Index(string strSeach)
        {
            QLSVList svList = new QLSVList();
            List<QLSVModels> obj = svList.getQLSV(string.Empty);
            if (!String.IsNullOrEmpty(strSeach))
            {
                obj = obj.Where(x => x.MaSV.ToString().Contains(strSeach) || x.HoTen.Contains(strSeach)).ToList();
            }
            return View(obj);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(QLSVModels sv)
        {
            if (ModelState.IsValid)
            {
                QLSVList svList = new QLSVList();
                svList.AddSV(sv);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string MaSV = "")
        {
            QLSVList svList = new QLSVList();
            List<QLSVModels> obj = svList.getQLSV(MaSV);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(QLSVModels sv)
        {
            QLSVList svList = new QLSVList();
            svList.UpdateSV(sv);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(string MaSV = "")
        {
            QLSVList svList = new QLSVList();
            List<QLSVModels> obj = svList.getQLSV(MaSV);
            return View(obj.FirstOrDefault());
        }
        [HttpGet]
        public ActionResult Delete(string MaSV = "")
        {
            QLSVList svList = new QLSVList();
            List<QLSVModels> obj = svList.getQLSV(MaSV);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(QLSVModels sv)
        {
            QLSVList svList = new QLSVList();
            svList.DeleteSV(sv);
            return RedirectToAction("Index");
        }
    }
}