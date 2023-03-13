using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MXHvaQLKOL.Models;
namespace MXHvaQLKOL.Context.supportClass
{
    public class BieuDoDuongSL
    {
        private int t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12;
        QuanLiKOLEntities db = new QuanLiKOLEntities();
        public BieuDoDuongSL()
        {
            this.t1 = 0;
            this.t2 = 0;
            this.t3 = 0;
            this.t4 = 0;
            this.t5 = 0;
            this.t6 = 0;
            this.t7 = 0;
            this.t8 = 0;
            this.t9 = 0;
            this.t10 = 0;
            this.t11 = 0;
            this.t12 = 0;
        }
        public BieuDoDuongSL(List<HopDong> lhd)
        {
            this.t1 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 1).Count();
            this.t2 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 2).Count();
            this.t3 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 3).Count();
            this.t4 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 4).Count();
            this.t5 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 5).Count();
            this.t6 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 6).Count();
            this.t7 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 7).Count();
            this.t8 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 8).Count();
            this.t9 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 9).Count();
            this.t10 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 10).Count();
            this.t11 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 11).Count();
            this.t12 = db.HopDongs.Where(x => x.NgayKi.Value.Month == 12).Count();
        }

        public int T1 { get => t1; set => t1 = value; }
        public int T2 { get => t2; set => t2 = value; }
        public int T3 { get => t3; set => t3 = value; }
        public int T4 { get => t4; set => t4 = value; }
        public int T5 { get => t5; set => t5 = value; }
        public int T6 { get => t6; set => t6 = value; }
        public int T7 { get => t7; set => t7 = value; }
        public int T8 { get => t8; set => t8 = value; }
        public int T9 { get => t9; set => t9 = value; }
        public int T10 { get => t10; set => t10 = value; }
        public int T11 { get => t11; set => t11 = value; }
        public int T12 { get => t12; set => t12 = value; }
    }
}