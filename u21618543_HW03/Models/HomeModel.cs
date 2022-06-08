using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21618543_HW03.Models
{
    public class HomeModel
    {
        public String Option { get; set; }

        public HttpPostedFileBase[] Files { get; set; }
    }
}