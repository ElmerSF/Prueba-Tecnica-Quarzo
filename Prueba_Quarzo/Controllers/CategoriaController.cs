using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_Quarzo.Models;

namespace Prueba_Quarzo.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            ViewBag.codigo = "";
            ViewBag.nombre = "";
            ViewBag.activo = "";
            ViewBag.mensaje = "";
            return View();
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult Get_Modificar( Modelo_tabla_Categorias categoria)
        {
            try
            {
                Operaciones_con_la_BD operacion = new Operaciones_con_la_BD();
                Modelo_tabla_Categorias modelo = new Modelo_tabla_Categorias();
                modelo.Codigo_Categoria = categoria.Codigo_Categoria;
                modelo.Nombre = categoria.Nombre;
                modelo.Activo = categoria.Activo;
                List<Modelo_tabla_Categorias> list = new List<Modelo_tabla_Categorias>();

                list = operacion.Modificar_Categoria(modelo);

                List<string> codigo = new List<string>();
                List<string> nombre = new List<string>();
                List<string> activo = new List<string>();
                

                if (list.Count > 0 || list != null)
                {
                    foreach (var item in list)
                    {
                        codigo.Add(item.Codigo_Categoria + "");
                        nombre.Add(item.Nombre + "");
                        activo.Add(item.Activo + "");
                        

                    }

                    ViewBag.codigo = codigo;
                    ViewBag.nombre = nombre;
                    ViewBag.activo = activo;
                    ViewBag.mensaje = "Registro Modificado";

                }

                // TODO: Add update logic here

                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(Modelo_tabla_Categorias categoria)
        {
            try
            {
                ViewBag.codigo = "";
                ViewBag.nombre = "";
                ViewBag.activo = "";

                Operaciones_con_la_BD operacion = new Operaciones_con_la_BD();
                Modelo_tabla_Categorias modelo = new Modelo_tabla_Categorias();
                modelo.Codigo_Categoria = categoria.Codigo_Categoria;
                modelo.Nombre = "Dato a borrar";
                modelo.Activo = false;

                string resultado ="";

                resultado = operacion.Eliminar_Categoria(modelo);
                ViewBag.mensaje = resultado;



                return View("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
