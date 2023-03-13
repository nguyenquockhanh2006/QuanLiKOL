using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXHvaQLKOL.Context.supportClass
{
    
    public class BieuDoCotThang
    {
        private int thang1, thang2, thang3, thang4, thang5, thang6, thang7, thang8, thang9, thang10, thang11, thang12, thangmax;

        public BieuDoCotThang()
        {
            Thang1 = 0;
            Thang2 = 0;
            Thang3 = 0;
            Thang4 = 0;
            Thang5 = 0;
            Thang6 = 0;
            Thang7 = 0;
            Thang8 = 0;
            Thang9 = 0;
            Thang10 = 0;
            Thang11 = 0;
            Thang12 = 0;
            thangmax = 0;
        }
        public BieuDoCotThang(List<HopDong> hopdong)
        {
            Thang1 = hopdong.Where(x => x.NgayKi.Value.Month  == 1).Sum(y =>y.TriGia).Value;
            Thang2 = hopdong.Where(x => x.NgayKi.Value.Month  == 2).Sum(y => y.TriGia).Value;
            Thang3 = hopdong.Where(x => x.NgayKi.Value.Month  == 3).Sum(y => y.TriGia).Value;
            Thang4 = hopdong.Where(x => x.NgayKi.Value.Month  == 4).Sum(y => y.TriGia).Value;
            Thang5 = hopdong.Where(x => x.NgayKi.Value.Month  == 5).Sum(y => y.TriGia).Value;
            Thang6 = hopdong.Where(x => x.NgayKi.Value.Month  == 6).Sum(y => y.TriGia).Value;
            Thang7 = hopdong.Where(x => x.NgayKi.Value.Month  == 7).Sum(y => y.TriGia).Value;
            Thang8 = hopdong.Where(x => x.NgayKi.Value.Month  == 8).Sum(y => y.TriGia).Value;
            Thang9 = hopdong.Where(x => x.NgayKi.Value.Month  == 9).Sum(y => y.TriGia).Value;
            Thang10 = hopdong.Where(x => x.NgayKi.Value.Month == 10).Sum(y => y.TriGia).Value;
            Thang11 = hopdong.Where(x => x.NgayKi.Value.Month == 11).Sum(y => y.TriGia).Value;
            Thang12 = hopdong.Where(x => x.NgayKi.Value.Month == 12).Sum(y => y.TriGia).Value;
            thangmax = TimMax();
        }

        public int Thang1 { get => thang1; set => thang1 = value; }
        public int Thang2 { get => thang2; set => thang2 = value; }
        public int Thang3 { get => thang3; set => thang3 = value; }
        public int Thang4 { get => thang4; set => thang4 = value; }
        public int Thang5 { get => thang5; set => thang5 = value; }
        public int Thang6 { get => thang6; set => thang6 = value; }
        public int Thang7 { get => thang7; set => thang7 = value; }
        public int Thang8 { get => thang8; set => thang8 = value; }
        public int Thang9 { get => thang9; set => thang9 = value; }
        public int Thang10 { get => thang10; set => thang10 = value; }
        public int Thang11 { get => thang11; set => thang11 = value; }
        public int Thang12 { get => thang12; set => thang12 = value; }
        public int Thangmax { get => thangmax; set => thangmax = value; }
        public int sosanh(int a , int b)
        {
            if (a > b)
                return a;
            return b;
        }
        public int TimMax()
        {
            return sosanh(thang1,sosanh(thang2, sosanh(thang3, sosanh(thang4, sosanh(thang5, sosanh(thang6,
                sosanh(thang7, sosanh(thang8, sosanh(thang9, sosanh(thang10, sosanh(thang11, thang12)))))
                ))))));
        }
    }
}