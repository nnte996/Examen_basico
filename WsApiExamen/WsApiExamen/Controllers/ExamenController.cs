using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WsApiExamen.Repository;
using System.Web.Mvc.Filters;
using WsApiExamen.DAL;
using WsApiExamen.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace WsApiExamen.Controllers
{
    public class ExamenController
    {
        // GET: Product  
        public ActionResult GetTodosExamenes()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("WsApiExamen/BdiExamen/GetTodosExamenes");
                response.EnsureSuccessStatusCode();
                List<Models.tblExamen> tblexamens = response.Content.ReadAsAsync<List<Models.tblExamen>>().Result;
                ViewBag.Title = "GetTodosExamenes";
                return View(tblexamens);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ActionResult View(List<Models.tblExamen> tblexamens)
        {
            throw new NotImplementedException();
        }

        //[HttpGet]  
        public ActionResult editarExamen(int idExamen)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("WpsApiExamen/BdiExamen/GetExamen?idExamen = " + idExamen.ToString());
            response.EnsureSuccessStatusCode();
            tblExamen examenes = response.Content.ReadAsAsync<Models.tblExamen>().Result;
            ViewBag.Title = "GetTodosExamenes";
            return View(examenes);
        }

        private ActionResult View(tblExamen examenes)
        {
            throw new NotImplementedException();
        }

        //[HttpPost]  
        public ActionResult ActualizarExamen(Models.tblExamen examen)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("WpsApiExamen/BdiExamen/ActualizarExamen", examen);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetTodosExamenes");
        }

        private ActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }

        public ActionResult ConsultarExamenes(int idExamen)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("WpsApiExamen/BdiExamen/GetExamen?idExamen = " + idExamen.ToString());
            response.EnsureSuccessStatusCode();
            Models.tblExamen examenes = response.Content.ReadAsAsync<Models.tblExamen>().Result;
            ViewBag.Title = "GetTodosExamenes";
            return View(examenes);
        }
        
        [HttpGet]
        public ActionResult AgregarExamen()
        {
            return View();
        }

        private ActionResult View()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult AgregarExamen(Models.tblExamen examen)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("WpsApiExamen/BdiExamen/AgregarExamen", examen);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetTodosExamenes");
        }
        
        public ActionResult EliminarExamen(int idExamen)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("WpsApiExamen/BdiExamen/EliminarExamen?idExamen = " + idExamen.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetTodosExamenes");
        }
    }
}