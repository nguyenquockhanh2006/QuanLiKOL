using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXHvaQLKOL.Context.supportClass
{
    public class tinhtien
    {
        int tien;
        
        public tinhtien(int tien)
        {
            this.tien = tien;
        }
        public tinhtien()
        {
            this.tien = 0;
        }
        public int Tien { get => tien; set => tien = value; }
        public tinhtien(AccKOL kol)
        {
            int fl = kol.Follows.Count;
            int min = 0;
            int max = 0;
            int lech = 0;
            if(fl < 5000)
            {
                lech = 5000;
                min = 400000;
                max = 800000;
            }
            if (fl >= 5000 && fl < 15000)
            {
                lech = 10000;
                min = 800000;
                max = 2000000;
            }
            if (fl >= 15000 && fl < 40000)
            {
                lech = 35000;
                min = 2000000;
                max = 5000000;
            }
            if (fl >= 40000 && fl < 100000)
            {
                min = 5000000;
                max = 10000000;
                lech = 60000;
            }
            if (fl >= 100000 && fl < 250000)
            {
                min = 10000000;
                max = 20000000;
                lech = 150000;
            }
            if (fl >= 250000 && fl < 500000)
            {
                min = 20000000;
                max = 30000000;
                lech = 250000;
            }
            if (fl >= 500000 && fl < 1000000)
            {
                min = 30000000;
                max = 50000000;
                lech = 500000;
            }
            if (fl >= 1000000 && fl < 2000000)
            {
                min = 50000000;
                max = 100000000;
                lech = 1000000;
            }
            if (fl >= 2000000 && fl < 3000000)
            {
                min = 100000000;
                max = 200000000;
                lech = 1000000;
            }
            if (fl >= 3000000)
            {
                tien = 200000000;
                return;
            }
            tien = min;
            int onefl = (max - min) / lech;
            int them = fl * onefl;
            this.tien = min+them;
        }
    }
}