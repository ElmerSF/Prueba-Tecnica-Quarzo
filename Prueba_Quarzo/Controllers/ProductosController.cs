/*Esta clase es la que controla la página de mostrar todos los productos de una categoría
 * */
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

        // Con esta función se invoca la operación para obtener todos los productos de un categoría
        public ActionResult Get_todo_Producto(Modelo_tabla_Categorias id)
        {
            try
            {
                Operaciones_con_la_BD operaciones = new Operaciones_con_la_BD();
                List<Modelo_tabla_Productos> list = new List<Modelo_tabla_Productos>();

                //Se envian los parámetros a la función Tabla_Productos del archivo de Operaciones_con_la_BD
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
                    //los resultados se presentan en la pantalla
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


    }
}
