using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebVista01.ServiceReference1;

namespace WebVista01.Controllers
{
    public class NegociosController : Controller
    {

        Service1Client servicio = new Service1Client();
       
        public ActionResult Inicio(int idCiudad=1)
        {
            IEnumerable<Ciudad> listaCiudades = servicio.listadoCiudad();
            ViewBag.ciudades = listaCiudades;
            return View(servicio.listado_Horarios(idCiudad));
        }
        public ActionResult Respuesta()
        {
            ViewBag.mensaje = "Pasaje agregado";
            return View();
        }

        public ActionResult Create(int idHorario=1,int nasiento=0)
        {
                Horario horario = servicio.horario_Esp(idHorario);//buscar al servicio
                ViewBag.idHorario = horario.idHorario; 
                ViewBag.costo= horario.costo;//sacamos el costo 
                 ViewBag.asiento = nasiento;
                return View(new Pasaje());
        }


               [HttpPost]
               public ActionResult Create(Pasaje reg)
               {
                   //ejecutar
                 ViewBag.resp =servicio.agregar_asiento(reg);
                    //enviar a la vista
                 //      return View(reg);
                return RedirectToAction("Respuesta");
               }

    }
}