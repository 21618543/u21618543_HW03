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
        public ActionResult Index(HttpPostedFileBase files) //INSIDE HOME
        {
            // Verify that the user selected a file
            // Not null and has a length

            if (files != null && files.ContentLength > 0)
            {
                // extract only the filename

                var fileName = Path.GetFileName(files.FileName);

                // store the file inside ~/App_Data/uploads folder

                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);

                // The chosen default path for saving

                files.SaveAs(path);
            }
            // redirect back to the index action to show the form once again

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