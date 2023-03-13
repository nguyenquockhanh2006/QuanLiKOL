using MXHvaQLKOL.Context.supportClass;
using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;

namespace MXHvaQLKOL.Controllers
{
    public class KhachHangController : Controller
    {
        QuanLiKOLEntities db = new QuanLiKOLEntities();
        ByteBaseImage bbi = new ByteBaseImage();
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
        // GET: KhachHang
        public ActionResult Index(String cachload)
        {
            if (cachload == null)
                Session["load"] = "mot";
            else
                Session["load"] = "hai";
            return View();
        }
        public ActionResult TaiHopDong()
        {
            Session["HopDongTT"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult GuiHD(FormCollection frm)
        {
            HopDong hd = new HopDong();
            
            Random rnd = new Random();
            int a = rnd.Next(100000, 9999999); 
            hd.MaHopDong = a.ToString();
            hd.BenA = frm["benB"].ToString();
            hd.BenB = frm["benA"].ToString();
            hd.MaLV = frm["LinhVuc"].ToString();
            hd.TenHopDong = frm["TenHD"].ToString();
            hd.NoiDung = frm["htmlsorcedoc"].ToString();
            String ngaybd = frm["NgayKi"].ToString();
            String[] arrListStr = ngaybd.Split(new char[] { '-' });
            hd.NgayKi = new DateTime(Convert.ToInt32(arrListStr[0].ToString()), Convert.ToInt32(arrListStr[1].ToString()), Convert.ToInt32(arrListStr[2].ToString()));
            String ngaykt = frm["NgayKT"].ToString();
            arrListStr = ngaykt.Split(new char[] { '-' });
            hd.NgayKT = new DateTime(Convert.ToInt32(arrListStr[0].ToString()), Convert.ToInt32(arrListStr[1].ToString()), Convert.ToInt32(arrListStr[2].ToString()));
            hd.TriGia = Convert.ToInt32(frm["TriGia"].ToString());
            hd.TrangThai = 1;
            db.HopDongs.Add(hd);
            db.SaveChanges();
            return RedirectToAction("TaiHopDong");
        }
        [HttpPost]
        public ActionResult TimKiemKOL(FormCollection frm)
        {
            String dk = frm["dieukien"].ToString();
            String sotientu = frm["sotienfrom"].ToString();
            String sotienden = frm["sotiento"].ToString();
            
            var kol = db.AccKOLs.ToList();
            List<AccKOL> result = new List<AccKOL>();
            foreach (var c in kol)
            {
                if (c.AccName.Contains(dk) || c.Name.Contains(dk) || c.UserName.Contains(dk))
                {
                    if(sotientu.Trim() == "" || sotienden.Trim() == "")
                    {
                        result.Add(c);
                    }
                    else
                    {
                        tinhtien titi = new tinhtien(c);
                        if(titi.Tien >= Convert.ToInt32(sotientu) && titi.Tien <= Convert.ToInt32(sotienden))
                            result.Add(c);
                    }
                }
            }
            return View(result);
        }
        public ActionResult TimKiemKOL()
        {
            return View(db.AccKOLs.ToList());
        }
        public ActionResult TrangCaNhanK()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThayDoiLV(FormCollection frm)
        {
            String acname = Session["id"].ToString();
            List<LVKH> kh = db.LVKHs.Where(x => x.accname == acname).ToList();
            db.LVKHs.RemoveRange(kh);
            db.SaveChanges();
            String lv = frm["ketqualv"].ToString();
            String[] alv = lv.Split(new char[] { '/' });
            foreach (String v in alv)
            {
                if(v.Trim() != "")
                {
                    LVKH item = new LVKH();
                    item.accname = acname;
                    item.malv = v;
                    db.LVKHs.Add(item);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("TrangCaNhanK");
        }
        [HttpPost]
        public ActionResult DangAnh(FormCollection frm)
        {
            String srcAnh = frm["srcanhthem"].ToString();
            srcAnh = srcAnh.Remove(0, 23);
            AnhKhach ak = new AnhKhach();
            ak.AccName = Session["id"].ToString();
            ak.Anh = bbi.ImageToByteArray(bbi.GetImageFromString(srcAnh));
            db.AnhKhaches.Add(ak);
            db.SaveChanges();
            return RedirectToAction("TrangCaNhanK");
        }
        [HttpPost]
        public ActionResult LuuThayDoi(FormCollection frm)
        {
            String tennguoidung = frm["tennguoidung"].ToString();
            String ten = frm["ten"].ToString();
            String ngaysinh = frm["ngaysinh"].ToString();
            String diachi = frm["diachi"].ToString();
            String sdt = frm["sdt"].ToString();
            String accname = Session["id"].ToString();
            AccCustomer accus = db.AccCustomers.Where(x => x.AccName == accname).FirstOrDefault();
            accus.UseName = tennguoidung;
            accus.Name = ten;
            String[] arrListStr = ngaysinh.Split(new char[] { '-' });
            accus.BirthDay = new DateTime(Convert.ToInt32(arrListStr[0].ToString()), Convert.ToInt32(arrListStr[1].ToString()), Convert.ToInt32(arrListStr[2].ToString()));
            accus.Address = diachi;
            accus.PhoneNumber = sdt;
            db.SaveChanges();
            return RedirectToAction("TrangCaNhanK");
        }
        [HttpPost]
        public ActionResult LoadCMND(FormCollection frm)
        {
            String srcanh = frm["srcanhcmnd"].ToString();
            srcanh = srcanh.Remove(0, 23);
            String accname = Session["id"].ToString();
            AccCustomer cus = db.AccCustomers.Where(x => x.AccName == accname).FirstOrDefault();
            cus.CCCD = bbi.ImageToByteArray(bbi.GetImageFromString(srcanh));
            db.SaveChanges();
            return RedirectToAction("TrangCaNhanK");
        }
        [HttpPost]
        public ActionResult LoadCMNDms(FormCollection frm)
        {
            String srcanh = frm["srcanhcmnd"].ToString();
            srcanh = srcanh.Remove(0, 23);
            String accname = Session["id"].ToString();
            AccCustomer cus = db.AccCustomers.Where(x => x.AccName == accname).FirstOrDefault();
            cus.CCCDback = bbi.ImageToByteArray(bbi.GetImageFromString(srcanh));
            db.SaveChanges();
            return RedirectToAction("TrangCaNhanK");
        }
        [HttpPost]
        public ActionResult UpAvatarkh(FormCollection frm)
        {
            String srcanh = frm["srcanhavt"].ToString();
            srcanh = srcanh.Remove(0, 23);
            String accname = Session["id"].ToString();
            AccCustomer cus = db.AccCustomers.Where(x => x.AccName == accname).FirstOrDefault();
            cus.Avatar = bbi.ImageToByteArray(bbi.GetImageFromString(srcanh));
            db.SaveChanges();
            return RedirectToAction("TrangCaNhanK");
        }
        
        public ActionResult DeleteHopDong(String idhd)
        {
            var result = db.HopDongs.Where(x => x.MaHopDong == idhd).FirstOrDefault();
            db.HopDongs.Remove(result);
            db.SaveChanges();
            return RedirectToAction("TaiHopDong");
        }
        public ActionResult KhachXemKOL(String id)
        {
            var result = db.AccKOLs.Where(x => x.AccName == id).FirstOrDefault();
            return View(result);
        }
        public ActionResult FollowTim(String id, String trangload)
        {
            String accname = Session["id"].ToString();
            var result = db.Follows.Where(x => x.AccDuocFl == id && x.AccFl == accname).FirstOrDefault();
            if(result == null)
            {
                Follow fl = new Follow();
                fl.AccDuocFl = id;
                fl.AccFl = accname;
                db.Follows.Add(fl);
                db.SaveChanges();
            }
            else
            {
                db.Follows.Remove(result);
                db.SaveChanges();
            }
            if(trangload != null &&  trangload.Equals("Index") == true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("TimKiemKOL");
        }
        public ActionResult KhachXoaAnh(int idanh)
        {
            var result = db.AnhKhaches.Where(x => x.ma == idanh).FirstOrDefault();
            db.AnhKhaches.Remove(result);
            db.SaveChanges();
            return RedirectToAction("TrangCaNhanK");
        }
        [HttpPost]
        public ActionResult DoiPassKhach(FormCollection frm)
        {
            String pass = frm["xacnhanmkmoi"].ToString();
            String accname = Session["id"].ToString();
            var acccus = db.TaiKhoans.Where(x => x.AccName == accname).FirstOrDefault();
            acccus.Pass = EncodeMD5(pass);
            db.SaveChanges();
            return RedirectToAction("TrangCaNhanK");
        }
        public ActionResult Likebvkol(int id, String load)
        {
            String accname = Session["id"].ToString();
            var result = db.LuotThichBvKOLs.Where(x => x.MaBaiDang == id && x.AccLiked == accname).FirstOrDefault();
            if(result == null)
            {
                LuotThichBvKOL like = new LuotThichBvKOL();
                like.MaBaiDang = id;
                like.AccLiked = accname;
                db.LuotThichBvKOLs.Add(like);
                db.SaveChanges();
            }
            else
            {
                db.LuotThichBvKOLs.Remove(result);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DangBaiKhach(FormCollection frm)
        {
            BaiDangCu bdKhach = new BaiDangCu();
            String srcAnh = frm["srcanhbv"].ToString();
            srcAnh = srcAnh.Remove(0, 23);
            bdKhach.AccName = Session["id"].ToString();
            bdKhach.NgayDang = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            bdKhach.NoiDung = frm["noidung"].ToString();
            bdKhach.LinhVuc = frm["linhvuc"].ToString();
            bdKhach.anh = bbi.ImageToByteArray(bbi.GetImageFromString(srcAnh));
            db.BaiDangCus.Add(bdKhach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LoadHDkhichonkol(String id)
        {
            String accname = Session["id"].ToString();
            var result = db.Follows.Where(x => x.AccDuocFl == id && x.AccFl == accname).FirstOrDefault();
            if(result == null)
            {
                Follow fl = new Follow();
                fl.AccDuocFl = id;
                fl.AccFl = accname;
                db.Follows.Add(fl);
                db.SaveChanges();
            }    
            return RedirectToAction("TaiHopDong");
        }


    }
}