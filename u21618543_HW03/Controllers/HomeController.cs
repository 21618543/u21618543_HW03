using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace u21618543_HW03.Controllers
{
    //TRYING TO SEE IF GITHUB WORKS
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Single File Upload
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {


            if (files != null && files.ContentLength > 0)
            {

                var fileName = Path.GetFileName(files.FileName);



                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);


                files.SaveAs(path);
            }


            return RedirectToAction("Index");
        }
        public ActionResult About()
        {


            return View();
        }


        public ActionResult Images()
        {


            return View();
        }

        public ActionResult Videos()
        {


            return View();
        }
        public ActionResult Files()
        {

            return View();
        }
    }
}