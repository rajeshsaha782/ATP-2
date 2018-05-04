using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserDashboardViewModel
{
    public class myReportViewModel:MemberInfo
    {
        public IEnumerable<Report> Reports { get; set; }
    }
}