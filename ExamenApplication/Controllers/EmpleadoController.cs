using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenApplication.Models;

namespace ExamenApplication.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        Examen entidad = new Examen();
        public ActionResult Index()
        {
            var lista_empleados = entidad.empleado;

            return View(lista_empleados.ToList());
        }

        public ActionResult ListadoEmpleados()
            ///Obtiene el listado con la información de los empleados
        {
            var modelo = from e in entidad.empleado
                         join a in entidad.area
                            on e.area_id equals a.area_id

                         select new empleado
                         {
                             emp_id = e.emp_id,
                             nom_empleado = e.nom_empleado,
                             area_id = a.area_id
                         };

            return View(modelo.ToList());
        }

        public ActionResult EmpleadosPorArea(string area)
            //Obtiene una lista de empleados de una área determinada
            //Utilizando una consulta LINQ
        {
            var modelo = from e in entidad.empleado where e.area.nom_area==area select e;

            return View(modelo.ToList());
        }

    }
}