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
    public class empleadosController : Controller
    {
        private Examen db = new Examen();

        // Muestra en la vista la lista de empleados y su área.
        public ActionResult Index()
        {
            var empleado = db.empleado.Include(e => e.area);
            return View(empleado.ToList());
        }

        //Verifica si el empleado requerido existe.
        //Si existe muestra la vista correspondiente.
        //Si no existe muestra error.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        //Muestra la Vista para crear empleado obteniendo las áreas existentes.
        public ActionResult Create()
        {
            ViewBag.area_id = new SelectList(db.area, "area_id", "nom_area");
            return View();
        }

        //Verifica que los datos del formulario para crear el empleado este correcto.
        [HttpPost]
        public ActionResult Create([Bind(Include = "emp_id,nom_empleado,ap_pat, ap_mat,email,area_id")] empleado empleado)
        {
            if (ModelState.IsValid)

            {
                db.empleado.Add(empleado);
                db.SaveChanges();
                RedirectToAction("Index");
            }
        
            ViewBag.area_id = new SelectList(db.area, "area_id", "nom_area", empleado.area_id);
            return View(empleado);
        }

        // Verifica mediante el id que el empleado seleccionado a editar exista.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.area_id = new SelectList(db.area, "area_id", "nom_area", empleado.area_id);
            return View(empleado);
        }

        // Verifica que los datos del formulario esten correctos.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "emp_id,nom_empleado,ap_pat, ap_mat,email,area_id")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.area_id = new SelectList(db.area, "area_id", "nom_area", empleado.area_id);
            return View(empleado);
        }

        // Verifica que el empleado seleccionado a eliminar exista mediante su id.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        //Elimina el empleado de la BD.
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            empleado empleado = db.empleado.Find(id);
            db.empleado.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
