using MXHvaQLKOL.Context.supportClass;
using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MXHvaQLKOL.Controllers
{
    public class KOLController : Controller
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
        public ActionResult Index()
        {
            var result = db.BaiDangKOLs.ToList().OrderByDescending(x=>x.ngaydang).ToArray();
            return View(result);
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {    
            String bv = frm["noidungbv"].ToString();
            BaiDangKOL bd = new BaiDangKOL();
            bd.AccName = Session["id"].ToString();
            bd.Noidung = bv;
            if(frm["anhdayne"].ToString() != "")
            {
                String srcanh = frm["anhdayne"].ToString();
                srcanh = srcanh.Remove(0, 23);
                bd.anh = bbi.ImageToByteArray(bbi.GetImageFromString(srcanh));
            }
            bd.ngaydang = DateTime.Now;
            db.BaiDangKOLs.Add(bd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HoSoKOL()
        {
            return View();
        }
        public ActionResult HoSoKOLtheoid(String idkol)
        {
            var result = db.AccKOLs.Where(x => x.AccName == idkol).FirstOrDefault();
            return View(result);
        }
        public ActionResult KOLxemHoSoKOL(String idkol)
        {
            var result = db.AccKOLs.Where(x => x.AccName == idkol).FirstOrDefault();
            return View(result);
        }
        public ActionResult Trello()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoadLopPhu(FormCollection frm)
        {
            String idcv = frm["macv"].ToString();
            String HD = frm["hanhdong"].ToString();
            Session["macvload"] = idcv;
            Session["loadlopphu"] = HD; 
            return RedirectToAction("Trello");
        }
        [HttpPost]
        public ActionResult Trello(FormCollection frm)
        {
            ThoiGianBieu tgb = new ThoiGianBieu();
            tgb.AccName = "nthien.truong.qk206@gmail.com";
            tgb.WorkName = frm["workname"].ToString();
            tgb.TrangThai = 0;
            tgb.ThoiGian = new DateTime(2001, 06, 20);
            db.ThoiGianBieux.Add(tgb);
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult Luu(FormCollection frm)
        {

            String AccName = Session["id"].ToString();
            AccKOL kol = db.AccKOLs.Where(x => x.AccName == AccName).FirstOrDefault();
            //TaiKhoan tk = db.TaiKhoans.Where(x => x.AccName == AccName).FirstOrDefault();
            //AccKOL kol = new AccKOL();
            kol.UserName = frm["ip_tentk"].ToString();
            kol.Name = frm["ip_hoten"].ToString();
            String strdate = frm["ip_ngaysinh"].ToString();
            String[] arrListStr = strdate.Split(new char[] { '-' });
            kol.BirthDay = new DateTime(Convert.ToInt32(arrListStr[0].ToString()), Convert.ToInt32(arrListStr[1].ToString()), Convert.ToInt32(arrListStr[2].ToString()));                                                          
            kol.GioiTinh = frm["ip_gioitinh"].ToString();
            kol.Address = frm["ip_diachi"].ToString();
            kol.PhoneNumber = frm["ip_sdt"].ToString();
            db.SaveChanges();
            return RedirectToAction("HoSoKOL");
        }
        [HttpPost]
        public ActionResult thaydoi(FormCollection frm)
        {
            return RedirectToAction("Index", "TaoXacThucFaceAPI");
        }
        [HttpPost]
        public ActionResult cailai(FormCollection frm)
        {

            return RedirectToAction("Index", "TaoXacThucFaceAPI");
        }
        [HttpPost]
        public ActionResult LuuAnh(FormCollection frm)
        {
            String data = frm["anhsrc"].ToString();
            ByteBaseImage bbi = new ByteBaseImage();
            data = data.Remove(0, 23);
            AnhDang anh = new AnhDang();
            anh.AccName = Session["id"].ToString();//"nthien.truong.qk206@gmail.com"; //
            anh.Anh = bbi.ImageToByteArray(bbi.GetImageFromString(data));
            db.AnhDangs.Add(anh);
            db.SaveChanges();
            return RedirectToAction("HoSoKOL");
        }
        [HttpPost]
        public ActionResult LuuAVT(FormCollection frm)
        {
            String data = frm["anhsrc"].ToString();
            ByteBaseImage bbi = new ByteBaseImage();
            String accname = Session["id"].ToString(); //"nthien.truong.qk206@gmail.com";//
            data = data.Remove(0, 23);
            AccKOL anh = db.AccKOLs.Where(x => x.AccName == accname).FirstOrDefault();
            anh.Avatar = bbi.ImageToByteArray(bbi.GetImageFromString(data));
            db.SaveChanges();
            return RedirectToAction("HoSoKOL");
        }
        [HttpPost]
        public ActionResult LuuGmail(FormCollection frm)
        {
            String data = frm["gmail"].ToString();
            ByteBaseImage bbi = new ByteBaseImage();
            String accname = Session["id"].ToString(); //"nthien.truong.qk206@gmail.com";//
            AccKOL anh = db.AccKOLs.Where(x => x.AccName == accname).FirstOrDefault();
            anh.Gmail = data;
            db.SaveChanges();
            return RedirectToAction("HoSoKOL");
        }
        [HttpPost]
        public ActionResult ptxacminh(FormCollection frm)
        {

            return RedirectToAction("HoSoKOL");
        }
        [HttpPost]
        public ActionResult cmndmt(FormCollection frm)
        {
            String data = frm["cmndmtsrd"].ToString();
            ByteBaseImage bbi = new ByteBaseImage();
            String accname = Session["id"].ToString();//"nthien.truong.qk206@gmail.com";//
            data = data.Remove(0, 23);
            AccKOL anh = db.AccKOLs.Where(x => x.AccName == accname).FirstOrDefault();
            TaiKhoan tk = db.TaiKhoans.Where(x => x.AccName == accname).FirstOrDefault();
            anh.CCCD = bbi.ImageToByteArray(bbi.GetImageFromString(data));
            db.SaveChanges();
            tk.TinhTrangHD = 0;
            db.SaveChanges();
            return RedirectToAction("HoSoKOL");
        }
        [HttpPost]
        public ActionResult cmndms(FormCollection frm)
        {
            String data = frm["cmndmssrd"].ToString();
            ByteBaseImage bbi = new ByteBaseImage();
            String accname = Session["id"].ToString();//"nthien.truong.qk206@gmail.com";//
            data = data.Remove(0, 23);
            AccKOL anh = db.AccKOLs.Where(x => x.AccName == accname).FirstOrDefault();
            TaiKhoan tk = db.TaiKhoans.Where(x => x.AccName == accname).FirstOrDefault();
            anh.CCCDback = bbi.ImageToByteArray(bbi.GetImageFromString(data));
            db.SaveChanges();
            tk.TinhTrangHD = 0;
            db.SaveChanges();
            return RedirectToAction("HoSoKOL");
        }
        public ActionResult LoadBXHkol(String linhvuc, String thoigian)
        {
            List<AccKOL> lkol = new List<AccKOL>();
            
            if (linhvuc == null)
            {
                lkol = db.AccKOLs.ToList();
            }
            else
            {
                if(linhvuc == "All")
                {
                    lkol = db.AccKOLs.OrderByDescending(x => x.Follows.Count).ToList();
                }    
                else
                {
                    List<LVKOL> temp = db.LVKOLs.Where(x=>x.MaLV == linhvuc).ToList();
                    if(temp.Count > 0)
                    {
                        foreach (var c in temp)
                        {
                            AccKOL acckol = db.AccKOLs.Where(x=>x.AccName == c.AccName).FirstOrDefault();
                            lkol.Add(acckol);
                        } 
                    }
                    lkol.OrderByDescending(x=>x.Follows.Count);
                }    
            }
            if(thoigian == "shd")
            {
                lkol = lkol.OrderByDescending(x => x.HopDongs.Count).ToList();
            }
            else
            {
                lkol = lkol.OrderByDescending(x => x.Follows.Count).ToList();
            }
            return View(lkol);
        }
        public ActionResult LoadHDKOL(String id)
        {
            String accname = Session["id"].ToString();
            List<HopDong> result = new List<HopDong>();
            if(id == null)
            {
                result = db.HopDongs.Where(x => x.BenA == accname).ToList();
            }
            else
            {
                int ma = Convert.ToInt32(id);
                result = db.HopDongs.Where(x => x.BenA == accname && x.TrangThai == ma).ToList();
            }
            
            return View(result);
        }
        [HttpPost]
        public ActionResult LoadHDKOL(FormCollection frm)
        {
            String loai = frm["loaihd"].ToString();
            return View();
        }
        public ActionResult Fowllow(String  idkol)
        {
            String accname = Session["id"].ToString();
            var result = db.Follows.Where(x => x.AccDuocFl == idkol && x.AccFl == accname).FirstOrDefault();
            if(result != null)
            {
                db.Follows.Remove(result);
                db.SaveChanges();
            }
            else
            {
                Follow fl = new Follow();
                fl.AccDuocFl = idkol;
                fl.AccFl = accname;
                db.Follows.Add(fl);
                db.SaveChanges();
            }
            return RedirectToAction("HoSoKOLtheoid", new { idkol = idkol });
        }

        public ActionResult Report(String idkol)
        {
            String accname = Session["id"].ToString();
            return RedirectToAction("HoSoKOLtheoid", new { id = idkol });
        }
        public ActionResult Thongke()
        {

            return View();
        }
        public ActionResult YeuCauRT()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeuCauRT(FormCollection frm)
        {
            RutTienKOL rut = new RutTienKOL();
            rut.AccName = Session["id"].ToString();
            rut.SoTK = frm["stk"].ToString();
            rut.TenChuThe = frm["tct"].ToString();
            rut.NganHang = frm["nh"].ToString();
            String st = frm["st"].ToString();
            rut.SoTien = Convert.ToInt32(st);
            rut.ThoiGian = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            rut.TinhTrang = 0;
            db.RutTienKOLs.Add(rut);
            db.SaveChanges();
            return View();
        }
        public ActionResult XoaYC(int id)
        {
            var rut = db.RutTienKOLs.Where(x => x.ma == id).FirstOrDefault();
            db.RutTienKOLs.Remove(rut);
            db.SaveChanges();
            return RedirectToAction("YeuCauRT");
        }
        public ActionResult XoaAnh(int id)
        {
            String accname = Session["id"].ToString();
            var result = db.AnhDangs.Where(x => x.AccName == accname && x.ma == id).FirstOrDefault();
            db.AnhDangs.Remove(result);
            db.SaveChanges();
            return RedirectToAction("HoSoKOL");
        }
        public ActionResult UngTuyen(int id)
        {
            String accname = Session["id"].ToString();
            UngTuyenBvCu cus = db.UngTuyenBvCus.Where(x => x.MaBaiDang == id && x.AccName == accname).FirstOrDefault();
            if (cus != null)
            {
                db.UngTuyenBvCus.Remove(cus);
                db.SaveChanges();
            }
            else
            {
                UngTuyenBvCu ut = new UngTuyenBvCu();
                ut.MaBaiDang = id;
                ut.AccName = accname;
                ut.ThoiGian = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                db.UngTuyenBvCus.Add(ut);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult LoadQLBV()
        {

            return View();
        }
        public ActionResult XoaBVKOL(int id)
        {
            String accname = Session["id"].ToString();
            AccKOL kol = db.AccKOLs.Where(x => x.AccName == accname).FirstOrDefault();
            BaiDangKOL bdkol = kol.BaiDangKOLs.Where(x => x.MaBaiDang == id).FirstOrDefault();
            db.BaiDangKOLs.Remove(bdkol);
            db.SaveChanges();
            return RedirectToAction("LoadQLBV");
        }
        [HttpPost]
        public ActionResult CungCapMC(FormCollection frm)
        {
            String id = frm["mahd"].ToString();
            String noidung = frm["minhchung"].ToString();
            HopDong result = db.HopDongs.Where(x => x.MaHopDong == id).FirstOrDefault();
            result.XacNhanHoanThanh = noidung;
            db.SaveChanges();
            return RedirectToAction("LoadHDKOL");
        }

    }
}