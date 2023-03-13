using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MXHvaQLKOL.Controllers
{
    public class RegisterController : Controller
    {
        QuanLiKOLEntities db = new QuanLiKOLEntities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            String pq = frm["ip_PQ"].ToString();
            if(pq == "KOL")
            {
                AccKOL kol = new AccKOL();
                kol.AccName = frm["ip_tentk"].ToString();
                kol.Name = frm["ip_hoten"].ToString();
                kol.Gmail = frm["ip_mail"].ToString();
                kol.Address = frm["ip_dc"].ToString();
                kol.PhoneNumber = frm["ip_sdt"].ToString();
                kol.UserName = frm["ip_hoten"].ToString();
                db.AccKOLs.Add(kol);
                db.SaveChanges();
            }
            if(pq == "KH")
            {
                AccCustomer kh = new AccCustomer();
                kh.AccName = frm["ip_tentk"].ToString();
                kh.Name = frm["ip_hoten"].ToString();
                kh.Gmail = frm["ip_mail"].ToString();
                kh.Address = frm["ip_dc"].ToString();
                kh.PhoneNumber = frm["ip_sdt"].ToString();
                kh.UseName = frm["ip_hoten"].ToString();
                db.AccCustomers.Add(kh);
                db.SaveChanges();
            }

            TaiKhoan taikhoan = new TaiKhoan();
            taikhoan.AccName = frm["ip_tentk"].ToString();
            taikhoan.Pass = EncodeMD5(frm["ip_mk"].ToString());
            taikhoan.PQ = frm["ip_PQ"].ToString();
            taikhoan.TinhTrangHD = 1;
            taikhoan.TinhTrangXT = 0;
            taikhoan.XacThuc2YT = 1;
            db.TaiKhoans.Add(taikhoan);
            db.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
        private string EncodeMD5(string pass)

        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);

            bs = md5.ComputeHash(bs);

            System.Text.StringBuilder s = new System.Text.StringBuilder();

            foreach (byte b in bs)

            {

                s.Append(b.ToString("x1").ToLower());

            }

            pass = s.ToString();

            return pass;

        }
    }
}