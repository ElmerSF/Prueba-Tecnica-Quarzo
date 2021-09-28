using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_Quarzo.Models;

namespace Prueba_Quarzo.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            ViewBag.codigo = "";
            ViewBag.nombre = "";
            ViewBag.precio = "";
            ViewBag.categoria = "";
            return View();
        }

        // GET: Productos/Details/5
        public ActionResult Get_todo_Producto(Modelo_tabla_Categorias id)
        {
            try
            {
                Operaciones_con_la_BD operaciones = new Operaciones_con_la_BD();
                List<Modelo_tabla_Productos> list = new List<Modelo_tabla_Productos>();

                list = operaciones.Tabla_Productos(id.Codigo_Categoria);

                List<string> codigo = new List<string>();
                List<string> nombre = new List<string>();
                List<string> precio = new List<string>();
                List<string> categoria = new List<string>();

                if (list.Count > 0 || list != null)
                {
                    foreach (var item in list)
                    {
                        codigo.Add(item.Codigo_Producto + "");
                        nombre.Add(item.Nombre + "");
                        precio.Add(item.Precio + "");
                        categoria.Add(item.Categoria + "");

                    }

                    ViewBag.codigo = codigo;
                    ViewBag.nombre = nombre;
                    ViewBag.precio = precio;
                    ViewBag.categoria = categoria;
                }

                return View("Index");
            }
            catch (Exception)
            {

                return View();
            }
            
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
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

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
