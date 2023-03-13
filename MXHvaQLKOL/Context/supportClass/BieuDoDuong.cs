using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXHvaQLKOL.Context.supportClass
{
    public class BieuDoDuong
    {
        QuanLiKOLEntities db = new QuanLiKOLEntities();
        // dât list la list tim dc theo datetime.now.yaer
        private int[] thu, chi, thuthucte;
        public int[] getThu()
        {
            return thu;
        }
        public int[] getChi()
        {
            return chi;
        }
        public int[] getThuThucTe()
        {
            return thuthucte;
        }
        public BieuDoDuong()
        {
            thu = null;
            chi = null;
            thuthucte = null;
        }
        public BieuDoDuong(int nam)
        {
            thu = new int[12];
            chi = new int[12];
            thuthucte = new int[12];
            for(int i = 0; i < 12; i++)
            {
                thu[i] = new int();
                chi[i] = new int();
                thuthucte[i] = new int();
                int thang = i + 1;
                var result = db.HopDongs.Where(x => x.NgayKi.Value.Month == thang && x.NgayKi.Value.Year == nam && x.TrangThai == 4).ToList();
                if(result.Count > 0)
                {
                    int ketqua = 0;
                    foreach(var c in result)
                    {
                        ketqua += c.TriGia.Value;
                    }
                    thu[i] = ketqua;
                    thuthucte[i] = ketqua / 10; ;
                }
                else
                {
                    thu[i] = 0;
                    thuthucte[i] = 0;
                }
                var result2 = db.RutTienKOLs.Where(x => x.ThoiGian.Value.Month == thang && x.ThoiGian.Value.Year == nam && x.TinhTrang == 1).ToList();
                if(result2.Count > 0)
                {
                    int rut = 0;
                    foreach(var c in result2)
                    {
                        rut += c.SoTien.Value;
                    }
                    chi[i] = rut;
                }
                else
                {
                    chi[i] = 0;
                }
            }

        }

        public BieuDoDuong(int[] thu, int[] chi, int[] thuthucte)
        {
            this.thu = thu;
            this.chi = chi;
            this.thuthucte = thuthucte;
        }
    }
}