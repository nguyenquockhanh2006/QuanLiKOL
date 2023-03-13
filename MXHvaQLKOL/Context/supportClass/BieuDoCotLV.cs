using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXHvaQLKOL.Context.supportClass
{
   
    public class BieuDoCotLV
    {
        private int lvAN;
        private int lvAT;
        private int lvMP;
        private int lvTM;
        private int lvTT;
        private int lvTTr, max;
        
        public BieuDoCotLV()
        {
            LvAN = 0;
            LvAT = 0;
            LvMP = 0;
            LvTM = 0;
            LvTT = 0;
            LvTTr = 0;
            max = 0;
        }
        public BieuDoCotLV(List<HopDong> hopdong)
        {
            LvAN = hopdong.Where(x => x.MaLV == "AN").Sum(y => y.TriGia).Value;
            LvAT = hopdong.Where(x => x.MaLV == "AT").Sum(y => y.TriGia).Value;
            LvMP = hopdong.Where(x => x.MaLV == "MP").Sum(y => y.TriGia).Value;
            LvTM = hopdong.Where(x => x.MaLV == "TM").Sum(y => y.TriGia).Value;
            LvTT = hopdong.Where(x => x.MaLV == "TT").Sum(y => y.TriGia).Value;
            LvTTr = hopdong.Where(x => x.MaLV == "TTr").Sum(y => y.TriGia).Value;
            max = TimMax();
        }

        public int LvAN { get => lvAN; set => lvAN = value; }
        public int LvAT { get => lvAT; set => lvAT = value; }
        public int LvMP { get => lvMP; set => lvMP = value; }
        public int LvTM { get => lvTM; set => lvTM = value; }
        public int LvTT { get => lvTT; set => lvTT = value; }
        public int LvTTr { get => lvTTr; set => lvTTr = value; }
        public int Max { get => max; set => max = value; }
        public int sosanh(int a, int b)
        {
            if (a > b)
                return a;
            return b;
        }
        public int TimMax()
        {
            return sosanh(lvAN, sosanh(lvAT, sosanh(lvMP, sosanh(lvTM, sosanh(lvTT, lvTTr)))));
        }
    }
}