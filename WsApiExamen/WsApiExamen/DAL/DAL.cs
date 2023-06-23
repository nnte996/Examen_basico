using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WsApiExamen.Models;
using System.Data.Entity;
using WsApiExamen.Controllers;

namespace WsApiExamen.DAL
{
    public class DAL
    {
        static BdiExamenEntities DbContext;
        static DAL()
        {
            DbContext = new BdiExamenEntities();
        }
        public static tblExamen ConsultarExamen(int idExamen)
        {
            return DbContext.tblExamen.Where(p => p.idExamen == idExamen).FirstOrDefault();
        }
        public static bool AgregarExamen(tblExamen ExamenItem)
        {
            bool status;
            try
            {
                DbContext.tblExamen.Add(ExamenItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool ActualizarExamen(tblExamen ExamenItem)
        {
            bool status;
            try
            {
                tblExamen examItem = DbContext.tblExamen.Where(p => p.idExamen == ExamenItem.idExamen).FirstOrDefault();
                if (examItem != null)
                {
                    examItem.Nombre = examItem.Nombre;
                    examItem.Descripcion = examItem.Descripcion;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool EliminarExamen(int idExamen)
        {
            bool status;
            try
            {
                tblExamen examItem = DbContext.tblExamen.Where(p => p.idExamen == idExamen).FirstOrDefault();
                if (examItem != null)
                {
                    DbContext.tblExamen.Remove(examItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        internal static object ActualizarExamen(MtblExamen examObj)
        {
            throw new NotImplementedException();
        }

        internal static List<tblExamen> ConsultarExamen()
        {
            throw new NotImplementedException();
        }
    }
}