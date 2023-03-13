using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace MXHvaQLKOL.Context.supportClass
{
    public class BieuDoTronSL
    {
        private int soAN;
        private int soAT;
        private int soMP;
        private int soTM;
        private int soTT;
        private int soTTr;
        public BieuDoTronSL() {
            SoAN = 0;
            SoAT = 0;  
            SoMP = 0;
            SoTM = 0;
            SoTT = 0;
            SoTTr = 0;
        }
        public BieuDoTronSL(List<HopDong> hopdong)
        {
            SoAN = hopdong.Where(x=>x.MaLV == "AN").Count();
            SoAT = hopdong.Where(x => x.MaLV == "AT").Count();
            SoMP = hopdong.Where(x => x.MaLV == "MP").Count();
            SoTM = hopdong.Where(x => x.MaLV == "TM").Count();
            SoTT = hopdong.Where(x => x.MaLV == "TT").Count();
            SoTTr = hopdong.Where(x => x.MaLV == "TTr").Count();
        }

        public int SoAN { get => soAN; set => soAN = value; }
        public int SoAT { get => soAT; set => soAT = value; }
        public int SoMP { get => soMP; set => soMP = value; }
        public int SoTM { get => soTM; set => soTM = value; }
        public int SoTT { get => soTT; set => soTT = value; }
        public int SoTTr { get => soTTr; set => soTTr = value; }
    }
}