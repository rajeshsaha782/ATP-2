using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models
{
    public class DeliveryManViewModel
    {
        public Invoice ProductDeliveryActivity { set; get; }
        public DeliveryMan DeliveryManDetails { set; get; }
        public Member MemberIndetify { set; get; }
    }
}