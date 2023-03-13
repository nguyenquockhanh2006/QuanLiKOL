using MXHvaQLKOL.Context.supportClass;
using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MXHvaQLKOL.Controllers
{
    public class TaoXacThucFaceAPIController : Controller
    {
        QuanLiKOLEntities db = new QuanLiKOLEntities();
        ByteBaseImage bbi = new ByteBaseImage();
        // GET: TaoXacThucFaceAPI
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            String src = frm["srcanh"].ToString();
            src = src.Remove(0, 22);
            FaceId img = new FaceId();
            String ma = Session["id"].ToString();

            img.AccName = ma;
            img.Anh = bbi.ImageToByteArray(bbi.GetImageFromString(src));

            db.FaceIds.Add(img);
            db.SaveChanges();

            List<FaceId> listface = db.FaceIds.Where(x=>x.AccName == ma).ToList();
            if(listface.Count > 3)
            {
                Session["ThongBaoFace"] = "Error4";
                return View();
            }
            return View();
        }
        [HttpPost]
        public ActionResult GoxacThuc(FormCollection frm)
        {
            //String src = frm["AccName"].ToString();

            return RedirectToAction("Index", "XacThucFaceId");
        }
       
    }


}