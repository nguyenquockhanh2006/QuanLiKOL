using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MXHvaQLKOL.Controllers
{
    public class XacThucFaceIdController : Controller
    {
        QuanLiKOLEntities db = new QuanLiKOLEntities();
        // GET: XacThucFaceId
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            Session["HopDongTT"] = frm["mahd"].ToString();
            return View();
        }
        [HttpPost]
        public ActionResult DieuHuong(FormCollection frm)
        {
            String AccName = frm["AccName"].ToString();
            String hanhdong = Session["hanhdong"].ToString();
            TaiKhoan tk = db.TaiKhoans.Where(x => x.AccName == AccName).FirstOrDefault();
            tk.TinhTrangXT = 1;
            db.SaveChanges();
            String phanquyen = tk.PQ;
            if(hanhdong.Equals("thanhtoan") == true)
            {
                return RedirectToAction("Index", "ThanhToan");
            }else if(hanhdong.Equals("xacthuchd") == true)
            {
                String mahd = Session["HopDongTT"].ToString();
                var result = db.HopDongs.Where(x => x.MaHopDong == mahd).FirstOrDefault();
                result.TrangThai = 2;
                db.SaveChanges();
                return RedirectToAction("LoadHDKOL","KOL");
            }
            else if (hanhdong.Equals("dangnhap") == true)
            {
                if (phanquyen.Equals("KOL") == true)
                {
                    return RedirectToAction("Index", "KOL");
                }
                else if (phanquyen.Equals("AD") == true)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "KhachHang");
                }
            }
            else
            {
                if (phanquyen.Equals("KOL") == true)
                {
                    return RedirectToAction("HoSoKOL", "KOL");
                }
                else if (phanquyen.Equals("AD") == true)
                {
                    return RedirectToAction("HoSoAd", "Admin");
                }
                else
                {
                    return RedirectToAction("HoSoKhach", "KhachHang");
                }
            }
        }




    }
}