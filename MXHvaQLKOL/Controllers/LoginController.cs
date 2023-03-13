using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace MXHvaQLKOL.Controllers
{
    public class LoginController : Controller
    {
        QuanLiKOLEntities db = new QuanLiKOLEntities();
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
        // GET: Login
        public ActionResult Index(String s)
        {
            try
            {
                Session["ThongBao"] = s;
                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            try
            {
                String tk = frm["mail"].ToString();
                String mk = EncodeMD5(frm["pass"].ToString());
                TaiKhoan data = db.TaiKhoans.Where(x => x.AccName == tk).FirstOrDefault();
                
                if(data != null)
                {
                    if(data.TinhTrangXT == 0)
                    {
                        List<FaceId> l_face = db.FaceIds.Where(x=>x.AccName == data.AccName).ToList();
                        db.FaceIds.RemoveRange(l_face);
                        db.SaveChanges();
                    }
                    if(data.Pass != mk)
                    {
                        return Index("Sai mật khẩu!");
                    }
                    else
                    {
                        if(data.PQ == "KH")
                        {
                            if (data.TinhTrangXT == 0)
                            {
                                
                                Session["id"] = data.AccName;
                                Session["PQ"] = data.PQ;
                                Session["KhachXemKOL"] = "";
                                Session["hosoKOL"] = "";
                                Session["hanhdong"] = "dangnhap";
                                Session["idhoso"] = "";
                                return RedirectToAction("Index", "TaoXacThucFaceAPI");
                            }
                            else
                            {
                                Session["id"] = data.AccName;
                                Session["PQ"] = data.PQ;
                                Session["KhachXemKOL"] = "";
                                Session["hosoKOL"] = "";
                                Session["hanhdong"] = "dangnhap";
                                Session["idhoso"] = "";
                                return RedirectToAction("Index", "KhachHang");
                            }
                        }
                        else if(data.PQ == "KOL")
                        {
                            if(data.TinhTrangXT == 0)
                            {
                                Session["id"] = data.AccName;
                                Session["PQ"] = data.PQ;
                                Session["KhachXemKOL"] = "";
                                Session["hosoKOL"] = "";
                                Session["hanhdong"] = "dangnhap";
                                Session["idhoso"] = "";
                                return RedirectToAction("Index", "TaoXacThucFaceAPI");
                            }
                            else
                            {
                                Session["id"] = data.AccName;
                                Session["PQ"] = data.PQ;
                                Session["KhachXemKOL"] = "";
                                Session["hosoKOL"] = "";
                                Session["hanhdong"] = "dangnhap";
                                Session["idhoso"] = "";
                                return RedirectToAction("Index", "KOL", new { AccName = data.AccName });
                            }
                        }
                        else
                        {
                            if (data.TinhTrangXT == 0)
                            {
                                Session["id"] = data.AccName;
                                Session["PQ"] = data.PQ;
                                Session["KhachXemKOL"] = "";
                                Session["hosoKOL"] = "";
                                Session["hanhdong"] = "dangnhap";
                                Session["idhoso"] = "";
                                return RedirectToAction("Index", "TaoXacThucFaceAPI");
                            }
                            else
                            {
                                Session["id"] = data.AccName;
                                Session["PQ"] = data.PQ;
                                Session["KhachXemKOL"] = "";
                                Session["hosoKOL"] = "";
                                Session["hanhdong"] = "dangnhap";
                                Session["idhoso"] = "";
                                return RedirectToAction("Index", "Admin");
                            }
                        }
                    }
                }
                else
                {
                    return Index("Tài khoản không tồn tại!");
                }
                
            }
            catch
            {
                return Index("null");
            } 
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
