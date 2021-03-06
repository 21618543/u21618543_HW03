using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21618543_HW03.Models;





namespace u21618543_HW03.Controllers
{
    //TRYING TO SEE IF GITHUB WORKS
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()  //INSIDE FileUpload
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



                var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);


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
            //Fetch all files in the Folder (Directory).

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Uploads/"));

            //Copy File names to Model collection.

            //The return below returns to the list here.

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName) // Why fileName and not FileName????
                                                        // Because of using.
        {
            //Build the File Path.

            string path = Server.MapPath("~/App_Data/Uploads/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            //The OCTET-STREAM format is used for file attachments on the Web with an
            //unknown file type. These .octet-stream files are arbitrary binary data
            //files that may be in any multimedia format.

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            string path = Server.MapPath("~/App_Data/Uploads/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Files");
        }

    }
}