using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Office.ViewModels
{
    public class OtHoursViewModel
    {
        public string selectList { get; set; }
        public string Destination { get; set; }

        public DateTime DateTi { get; set; }
        public int  OtHours { get; set; }
    }
}