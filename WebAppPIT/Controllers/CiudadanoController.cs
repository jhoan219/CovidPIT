using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPIT.ReferenciaPIT;

namespace WebAppPIT.Controllers
{
    public class CiudadanoController : Controller
    {

        ServicioPITClient proxy = new ServicioPITClient();

        // GET: Ciudadano

        public ActionResult Ciudadanos()
        {
            return View(proxy.Ciudadanos());
        }
        public ActionResult Create()
        {
         
            return View(new Ciudadano());
        }

        [HttpPost]
        public ActionResult Create(Ciudadano reg)
        {
            string msg = proxy.AgregarCiudadano(reg);
            ViewBag.msg = msg;
            return RedirectToAction("Ciudadanos");
            //return View(reg);
        }

        public ActionResult Edit(string id)
        {
            Ciudadano reg = proxy.DetalleCiudadano(id); 
            return View(reg);
        }

        [HttpPost]
        public ActionResult Edit(Ciudadano reg)
        {
            string msg = proxy.ActualizarCiudadano(reg);
            ViewBag.msg = msg;
            return RedirectToAction("Ciudadanos");
        }

        public ActionResult Delete(string id)
        {
            Ciudadano reg = proxy.DetalleCiudadano(id); 
            return View(reg);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmado(string id)
        {
            string msg = proxy.EliminarCiudadano(id);
            ViewBag.msg = msg;
            return RedirectToAction("Ciudadano");
        }
    }
}