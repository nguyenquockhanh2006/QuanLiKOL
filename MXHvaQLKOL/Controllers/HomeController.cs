using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MXHvaQLKOL.Controllers
{
    public class HomeController : Controller
    {
        QuanLiKOLEntities db = new QuanLiKOLEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BangXepHang()
        {
            var result = db.AccKOLs.OrderByDescending(x => x.Follows.Count).ToList();
            return View(result);
        }
        [HttpPost]
        public ActionResult BangXepHang(FormCollection frm)
        {
            String dk = frm["maLV"].ToString();
            List<AccKOL> result = new List<AccKOL>();
            if (dk.Equals("All"))
            {
                result = db.AccKOLs.OrderByDescending(x => x.Follows.Count).ToList();
            }
            else
            {
                var listdk = db.LVKOLs.Where(x => x.MaLV == dk).ToList();
                foreach (var c in listdk)
                {
                    AccKOL temp = db.AccKOLs.Where(x => x.AccName == c.AccName).FirstOrDefault();
                    result.Add(temp);
                }
                result.OrderByDescending(x => x.Follows.Count).ToList();
                return View(result);
            }
            return View(result);
        }
    }
}