using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenApplication.Models;

namespace ExamenApplication.Controllers
{
    public class areasController : Controller
    {
        private Examen db = new Examen();


        // Obtiene las áreas creadas y las agrega a una lista.
        public ActionResult Index()
        {
            return View(db.area.ToList());
        }

        //Obtiene los detalles de una area mediante su id.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            area area = db.area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // Muestra la Vista para Crear una nueva área.
        public ActionResult Create()
        {
            return View();
        }

        // Verifica que el formulario para crear una nueva área sea correcta.
        [HttpPost]
        public ActionResult Create([Bind(Include = "area_id,nom_area")] area area)
        {
            if (ModelState.IsValid)
            {
                db.area.Add(area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(area);
        }

        
        

        //Verifica que el área requerida exista.
        //Si el id se encuentra vacío marcará error.
        //Si no se encuantra la área especificada mostrará mensaje de error.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            area area = db.area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        //Verifica que el formulario editado sea válido
        [HttpPost]
        public ActionResult Edit([Bind(Include = "area_id,nom_area")] area area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(area);
        }

        //Verifica que el área requerida para eliminar exista.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            area area = db.area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // Elimina la área especificada de la BD.
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            area area = db.area.Find(id);
            db.area.Remove(area);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
