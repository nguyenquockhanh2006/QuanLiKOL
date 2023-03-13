using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXHvaQLKOL.Context.supportClass
{
    public class RutTien
    {
        private int thang1, thang2, thang3, thang4, thang5, thang6, thang7, thang8, thang9, thang10, thang11, thang12, thangmax;

        public RutTien()
        {
            this.thang1 = 0;
            this.thang2 = 0;
            this.thang3 = 0;
            this.thang4 = 0;
            this.thang5 = 0;
            this.thang6 = 0;
            this.thang7 = 0;
            this.thang8 = 0;
            this.thang9 = 0;
            this.thang10 = 0;
            this.thang11 = 0;
            this.thang12 = 0;
            this.thangmax = 0;
        }
        public RutTien(List<RutTienKOL> ruttien)
        {
            thang1 = ruttien.Where(x => x.ThoiGian.Value.Month == 1).Sum(y => y.SoTien).Value;
            thang2 = ruttien.Where(x => x.ThoiGian.Value.Month == 2).Sum(y => y.SoTien).Value;
            thang3 = ruttien.Where(x => x.ThoiGian.Value.Month == 3).Sum(y => y.SoTien).Value;
            thang4 = ruttien.Where(x => x.ThoiGian.Value.Month == 4).Sum(y => y.SoTien).Value;
            thang5 = ruttien.Where(x => x.ThoiGian.Value.Month == 5).Sum(y => y.SoTien).Value;
            thang6 = ruttien.Where(x => x.ThoiGian.Value.Month == 6).Sum(y => y.SoTien).Value;
            thang7 = ruttien.Where(x => x.ThoiGian.Value.Month == 7).Sum(y => y.SoTien).Value;
            thang8 = ruttien.Where(x => x.ThoiGian.Value.Month == 8).Sum(y => y.SoTien).Value;
            thang9 = ruttien.Where(x => x.ThoiGian.Value.Month == 9).Sum(y => y.SoTien).Value;
            thang10 = ruttien.Where(x => x.ThoiGian.Value.Month == 10).Sum(y => y.SoTien).Value;
            thang11 = ruttien.Where(x => x.ThoiGian.Value.Month == 11).Sum(y => y.SoTien).Value;
            thang12 = ruttien.Where(x => x.ThoiGian.Value.Month == 12).Sum(y => y.SoTien).Value;
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
        public int sosanh(int a, int b)
        {
            if (a > b)
                return a;
            return b;
        }
        public int TimMax()
        {
            return sosanh(thang1, sosanh(thang2, sosanh(thang3, sosanh(thang4, sosanh(thang5, sosanh(thang6,
                sosanh(thang7, sosanh(thang8, sosanh(thang9, sosanh(thang10, sosanh(thang11, thang12)))))
                ))))));
        }
    }
}