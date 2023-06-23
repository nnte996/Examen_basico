using AutoMapper;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using WsApiExamen.Models;
using AutoMapper.Collection;
using AutoMapper.Extensions;

namespace WsApiExamen.Controllers
{
    public class MuestraExamenEntities : HomeController
    {
        // GET: Showroom  
        [HttpGet]
        public JsonResult<List<Models.tblExamen>> ConsultarTodosExamen()
        {
            EntityMapper<WsApiExamen.Models.tblExamen, Models.tblExamen> mapObj = new EntityMapper<WsApiExamen.Models.tblExamen, Models.tblExamen>();
            List<WsApiExamen.tblExamen> examList = DAL.DAL.ConsultarExamen();
            List<Models.tblExamen> exam = new List<Models.tblExamen>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<tblExamen, Models.tblExamen>());
            var mapper = new Mapper(config);
            foreach (var item in examList)
            {
                tblExamen.Add(mapper.Map<Models.tblExamen>(item));
            }
            return Json<List<Models.tblExamen>>(exam);
        }

        private JsonResult<T> Json<T>(T exam)
        {
            throw new NotImplementedException();
        }

        private JsonResult<T> Json<T>(Models.tblExamen tblExamen)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public JsonResult<Models.tblExamen> ConsultarExamen(int idExamen)
        {
            EntityMapper<tblExamen, tblExamen> mapObj = new EntityMapper<tblExamen, tblExamen>();
            tblExamen dalExamen = DAL.DAL.ConsultarExamen(idExamen);
            Models.tblExamen examen = new Models.tblExamen();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<tblExamen, Models.tblExamen>());
            var mapper = new Mapper(config);
            examen = mapper.Map<Models.tblExamen>(dalExamen);
            return JsonResult<Models.tblExamen>(examen);
        }

        private JsonResult<T> JsonResult<T>(T examen)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public bool AgregarExamen(Models.tblExamen examen)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.tblExamen, Models.tblExamen> mapObj = new EntityMapper<Models.tblExamen, WsApiExamen.Models.tblExamen>();
                Models.tblExamen examObj = new Models.tblExamen();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.tblExamen, tblExamen>());
                var mapper = new Mapper(config);
                examObj = mapper.Map<Models.tblExamen>(examen);
                status = DAL.DAL.AgregarExamen(examObj);
            }
            return status;
        }

        [HttpPut]
        public bool ActualizarExamen(Models.tblExamen examen)
        {
            EntityMapper<Models.tblExamen, WsApiExamen.Models.tblExamen> mapObj = new EntityMapper<Models.tblExamen, WsApiExamen.Models.tblExamen>();
            MtblExamen examObj = new Models.tblExamen();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.tblExamen, tblExamen>());
            var mapper = new Mapper(config);
            examObj = mapper.Map<Models.tblExamen>(examen);
            var status = DAL.DAL.ActualizarExamen(examObj);
            return (bool)status;
        }

        [HttpDelete]
        public bool EliminarExamen(int idExamen)
        {
            var status = DAL.DAL.EliminarExamen(idExamen);
            return status;
        }
    }
}