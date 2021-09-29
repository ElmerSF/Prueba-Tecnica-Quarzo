/*Esta clase es la que controla la página para modificar una Categoría, desde acá se realiza la invocación de las funciones
 * que modifican, agregan o eliminan un registro
 * 
 **/

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

        //Esta función invoca la función de modificar una Categoría o Agregar una nueva
        [HttpGet]
        public ActionResult Get_Modificar(Modelo_tabla_Categorias categoria)
        {
            try
            {
                Operaciones_con_la_BD operacion = new Operaciones_con_la_BD();
                Modelo_tabla_Categorias modelo = new Modelo_tabla_Categorias();
                modelo.Codigo_Categoria = categoria.Codigo_Categoria;
                modelo.Nombre = categoria.Nombre;
                modelo.Activo = categoria.Activo;
                List<Modelo_tabla_Categorias> list = new List<Modelo_tabla_Categorias>();

                //Se envian los parámetros a la función Modificar_Categoría del archivo de Operaciones_con_la_BD
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

                    //los resultados se presentan en la pantalla

                    ViewBag.codigo = codigo;
                    ViewBag.nombre = nombre;
                    ViewBag.activo = activo;
                    ViewBag.mensaje = "Registro Modificado";

                }

               

                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        //Esta Función permite la eliminación de una Categoría 

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

                string resultado = "";

                //Se envian los parámetros a la función Eliminar_Categoría del archivo de Operaciones_con_la_BD
                resultado = operacion.Eliminar_Categoria(modelo);

                //se muestra el resultado de la operación en pantalla
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
