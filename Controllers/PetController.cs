using MeHazVisto.Models;
using MeHazVisto.Models.Bussines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeHazVisto.Controllers
{
    public class PetController : Controller
    {
        //
        // GET: /Pet/
        
        public ActionResult Display()  //display recibe un identificador que corresponde a una mascota que queremos buscar
        {
            //var name = (String)RouteData.Values["id"];
            //var model = null;    // PetManagement.GetByName(name);
            object model = null;
            if (model == null)
            {
                //return RedirectToAction("NotFound");
                ViewBag.ErrorCode = "NFE0001";
                ViewBag.Description = "La mascota no se encuentra" + " en la base de datos";
            return View();
            }
            return View(model);
          
          //  return View();
        }
        public ActionResult NotFound()
        {
            //ViewBag.ErrorCode = "NFE0001";
            //ViewBag.Description = "La mascota no se encuentra" + " en la base de datos";
            return View();
        }

        public String Showid()
        {
            var id = (String)RouteData.Values["id"];
            return id;
        }
        /*public String Index()
        {
            var id = int.Parse ((String)RouteData.Values["id"]);
            id/= 2;
            var controlador = (String)RouteData.Values["controller"];
            var action = (string)RouteData.Values["action"];

            return (controlador + "-->" + action + "-->" + id);
            
            
        }*/
        public FileResult DownLoadPicture()
        {
            var name = (String)RouteData.Values["id"];
            var picture = "/Content/Uploads/" + name + ".jpg";
            var contentType = "image/jpg";
            var fileName = name + ".jpg";
            return File(picture, contentType);
        }

        public HttpStatusCodeResult UnauthorizedError()
        {
            return new HttpUnauthorizedResult("Error de acceso no autorizado");
        }

        public ActionResult NotFoundError()
        {
            ViewBag.ErrorCode = "NFE0001";
            ViewBag.Description = "La mascota no se encuentra" + " en la base de datos";
            return View();
        }
        public ActionResult PictureUpload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PictureUpload(PictureModel model)
        {
            if (model.PictureFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(model.PictureFile.FileName);
                var filePath = Server.MapPath("/Content/Uploads");
                string savedFileName = Path.Combine(filePath, fileName);
                model.PictureFile.SaveAs(savedFileName);
                PetManagement.CreateThumbnail(fileName, filePath, 100, 100, true);
            }
            return View(model);
        }
    }
    
}
