using MXHvaQLKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXHvaQLKOL.Context.supportClass
{
    public class XetMucHoanThanhHS
    {
        private int ht;
        public XetMucHoanThanhHS()
        {
            ht = 0;
        }
        public int getht()
        {
            return ht;
        }
        public XetMucHoanThanhHS(AccCustomer acccus)
        {
            if(acccus.AccName == null || acccus.UseName == null || acccus.Name == null
                || acccus.BirthDay == null || acccus.Address == null || acccus.PhoneNumber == null
                || acccus.Avatar == null)
            {
                ht = 0;
            }
            else
            {
                ht = 1;
            }
        }
        public XetMucHoanThanhHS(AccKOL acckol)
        {
            if (acckol.AccName == null || acckol.UserName == null || acckol.Name == null
                || acckol.BirthDay == null || acckol.Address == null || acckol.PhoneNumber == null
                || acckol.Avatar == null || acckol.GioiTinh == null || acckol.SoCM == null )
            {
                ht = 0;
            }
            else
            {
                ht = 1;
            }
        }
    }
}