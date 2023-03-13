using MXHvaQLKOL.Context.supportClass;
using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MXHvaQLKOL.Controllers
{
    public class AdminController : Controller
    {
        QuanLiKOLEntities db = new QuanLiKOLEntities();
        ByteBaseImage bbi = new ByteBaseImage();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GoTo404()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            //try
            //{
                BaiDangAdmin bd = new BaiDangAdmin();
                String noidung = frm["noidung"].ToString();
                String tieude = frm["tieude"].ToString();
                String anhsrc = frm["anhsrc"].ToString();
           
                String nguoidang = Session["id"].ToString();
                bd.TieuDe = tieude;
                bd.NoiDung = noidung;
                bd.NguoiDang = nguoidang;
                if (anhsrc.Equals("https://i.imgur.com/bRJdUtb.jpg") == false)
                {
                    anhsrc = anhsrc.Remove(0,23);
                    bd.Anh = bbi.ImageToByteArray(bbi.GetImageFromString(anhsrc));
                }
                db.BaiDangAdmins.Add(bd);
                db.SaveChanges();
                return View();
            //}
            //catch(Exception ex)
            //{
              //  return View();
            //}
            
        }
        [HttpPost]
        public void TraLoiCauHoi(FormCollection frm)
        {

        }
        public ActionResult LoadAllKol()
        {
            return View(db.AccKOLs.ToList());
        }
        [HttpPost]
        public ActionResult LoadAllKol(FormCollection frm)
        {
            try
            {
                string dk = frm["dieukien"].ToString();
                List<AccKOL> kol = new List<AccKOL>();
                List<LVKOL> lv = db.LVKOLs.Where(x => x.MaLV == dk).ToList();

                if(dk != "AN" && dk != "AT" && dk != "MP" && dk != "TM" && dk != "TT" && dk != "TTr" )
                {
                    return View(kol);
                }
                else
                {
                    foreach (var item in lv)
                    {
                        AccKOL acc = db.AccKOLs.Where(x => x.AccName == item.AccName).FirstOrDefault();
                        kol.Add(acc);
                    }
                    return View(kol);
                }
            }
            catch(Exception ex)
            {
                return View(db.AccKOLs.ToList());
            }
        }
        public ActionResult LoadAllKolTieuBieu()
        {
            List<AccKOL> result = new List<AccKOL>();
            List<AccKOL> kol = db.AccKOLs.ToList();
            foreach (var item in kol)
            {
                
                if(item.HopDongs.Count > 3)
                    result.Add(item);
            }
            return View(result);
        }
        public ActionResult LoadKhach()
        {
         
            return View(db.AccCustomers.ToList());
        }
        public ActionResult LoadBieuDo()
        {
            return View(db.HopDongs.ToList());
        }


        public ActionResult RePort()
        {
            return View();
        }
        public ActionResult LoadHopDong(String cachload, String id)
        {
            List<HopDong> lhd = new List<HopDong>();
            if(cachload == "All")
            {
                lhd = db.HopDongs.ToList();
            }else if(cachload == "kol")
            {
                lhd = db.HopDongs.Where(x=>x.TrangThai == 1).ToList();
            }
            else if (cachload == "adm")
            {
                lhd = db.HopDongs.Where(x => x.TrangThai == 2).ToList();
            }
            else if (cachload == "ttp")
            {
                lhd = db.HopDongs.Where(x => x.TrangThai == 3).ToList();
            }
            else if (cachload == "dhl")
            {
                lhd = db.HopDongs.Where(x => x.TrangThai == 4).ToList();
            }
            else {
                lhd = db.HopDongs.Where(x => x.TrangThai == 5).ToList();
            }
            if(id != null)
            {
                lhd = db.HopDongs.Where(x=>x.MaHopDong == id).ToList();
            }
            return View(lhd);
        }
        public ActionResult LoadDSKOL(String idacc, String pp)
        {
            List<AccKOL> lkol = new List<AccKOL>();
            if(pp == "All")
            {
                lkol = db.AccKOLs.ToList();
            }
            if(pp == "TB")
            {
                lkol = db.AccKOLs.Where(x => x.HopDongs.Count > 5).ToList();
            }
            if(idacc != null)
            {
                lkol = db.AccKOLs.Where(x=>x.AccName == idacc).ToList();
            }
            return View(lkol);
        }
        public ActionResult LoadDSKhach(String idacc, String pp)
        {
            List<AccCustomer> lkol = new List<AccCustomer>();
            if (pp == "All")
            {
                lkol = db.AccCustomers.ToList();
            }
            if (pp == "TB")
            {
                lkol = db.AccCustomers.Where(x => x.HopDongs.Count > 5 || x.Follows.Count > 5).ToList();
            }
            if (idacc != null)
            {
                lkol = db.AccCustomers.Where(x => x.AccName == idacc).ToList();
            }
            return View(lkol);
        }
        [HttpPost]
        public ActionResult LoadDSKhach(FormCollection frm)
        {
            List<AccCustomer> lkol = new List<AccCustomer>();
            String id = frm["idkhach"].ToString();
            lkol = db.AccCustomers.Where(x=>x.AccName == id).ToList();

            return View(lkol);
        }
        public ActionResult DuyetRp(int id)
        {
            var rp = db.reports.Where(x => x.id == id).FirstOrDefault();
            rp.Trangthai = 1;
            db.SaveChanges();
            return RedirectToAction("RePort");
        }
        public ActionResult DuyetYc(int id)
        {
            var yc = db.RutTienKOLs.Where(x=>x.ma == id ).FirstOrDefault();
            var result = db.AccKOLs.Where(x => x.AccName == yc.AccName).FirstOrDefault();
            result.SoDu = result.SoDu - yc.SoTien;
            yc.TinhTrang = 1;
            db.SaveChanges();
            return RedirectToAction("RePort");
        }
        public ActionResult ThongKeThuChi()
        {
            return View();
        }
        public ActionResult BangXepHang(String linhvuc, String thoigian)
        {
            List<AccKOL> lkol = new List<AccKOL>();

            if (linhvuc == null)
            {
                lkol = db.AccKOLs.ToList();
            }
            else
            {
                if (linhvuc == "All")
                {
                    lkol = db.AccKOLs.OrderByDescending(x => x.Follows.Count).ToList();
                }
                else
                {
                    List<LVKOL> temp = db.LVKOLs.Where(x => x.MaLV == linhvuc).ToList();
                    if (temp.Count > 0)
                    {
                        foreach (var c in temp)
                        {
                            AccKOL acckol = db.AccKOLs.Where(x => x.AccName == c.AccName).FirstOrDefault();
                            lkol.Add(acckol);
                        }
                    }
                    lkol.OrderByDescending(x => x.Follows.Count);
                }
            }
            if (thoigian == "shd")
            {
                lkol = lkol.OrderByDescending(x => x.HopDongs.Count).ToList();
            }
            else
            {
                lkol = lkol.OrderByDescending(x => x.Follows.Count).ToList();
            }
            return View(lkol);
        }
        public ActionResult DuyetAdmin(String id)
        {
            var result = db.HopDongs.Where(x=>x.MaHopDong == id).FirstOrDefault();
            result.TrangThai = 3;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyetAdminHT(String id)
        {
            var result = db.HopDongs.Where(x => x.MaHopDong == id).FirstOrDefault();
            result.TrangThai = 5;

            db.SaveChanges();
            var kol = db.AccKOLs.Where(x => x.AccName == result.AccKOL.AccName).FirstOrDefault();
            kol.SoDu = (int)(kol.SoDu + (float)(result.TriGia * 0.9));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult XacNhanTaiKhoanKOL()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XacNhanTaiKhoanKOL(FormCollection frm )
        {
            String accname = frm["accname"].ToString();
            AccKOL kol = db.AccKOLs.Where(x=>x.AccName == accname).FirstOrDefault();
            kol.SoCM = frm["soCM"].ToString();
            db.SaveChanges();
            return View();
        }
        public ActionResult XacNhanTaiKhoanKH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XacNhanTaiKhoanKH(FormCollection frm)
        {
            String accname = frm["accname"].ToString();
            AccCustomer kol = db.AccCustomers.Where(x => x.AccName == accname).FirstOrDefault();
            kol.SoCM = frm["soCM"].ToString();
            db.SaveChanges();
            return View();
        }
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(FormCollection frm)
        {
            AccAdmin adm = new AccAdmin();
            
            String ngaybd = frm["birthday"].ToString();
            String[] arrListStr = ngaybd.Split(new char[] { '-' });
            adm.AccName = frm["accname"].ToString();
            adm.UserName = frm["usename"].ToString();
            adm.Name = frm["name"].ToString();
            adm.BirthDay = new DateTime(Convert.ToInt32(arrListStr[0].ToString()), Convert.ToInt32(arrListStr[1].ToString()), Convert.ToInt32(arrListStr[2].ToString()));
            adm.Address = frm["address"].ToString();
            adm.PhoneNumber = frm["phonenumber"].ToString() ;
            db.AccAdmins.Add(adm);
            db.SaveChanges();
            //
            TaiKhoan tk = new TaiKhoan();
            tk.AccName = frm["accname"].ToString();
            tk.Pass = EncodeMD5(frm["pass"].ToString());
            tk.PQ = "AD";
            db.TaiKhoans.Add(tk);
            db.SaveChanges();
            return View();
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