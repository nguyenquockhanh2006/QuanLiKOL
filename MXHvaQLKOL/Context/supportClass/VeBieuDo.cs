using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXHvaQLKOL.Context.supportClass
{
    public class VeBieuDo
    {
        private BieuDoCotLV bdclv;
        private BieuDoCotThang bdct;
        private BieuDoTronSL bdt;
        public BieuDoCotLV GetBDCLv()
        {
            return bdclv;
        }
        public BieuDoCotThang GetBDCT()
        {
            return bdct;
        }
        public BieuDoTronSL GetBDT()
        {
            return bdt;
        }
        public VeBieuDo()
        {
            bdclv = new BieuDoCotLV();
            bdct = new BieuDoCotThang();
            bdt = new BieuDoTronSL();
        }
        public VeBieuDo(List<HopDong> hopdong)
        {
            bdclv = new BieuDoCotLV(hopdong);
            bdct = new BieuDoCotThang(hopdong);
            bdt = new BieuDoTronSL(hopdong);
        }
    }
}