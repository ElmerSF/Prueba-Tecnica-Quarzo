/*
En esta clase se establece los parámetros de conexión a la base datos, así como cada una de las consultas que se van realizar
En esta clase es donde se hace la "magia"
Esta agrupado por regiones para facilitar su lectura y comprensión
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Prueba_Quarzo.Models
{
    public class Operaciones_con_la_BD
    {
        //ruta de conexión a la base de datos 
        //NOTA IMPORTANTE *******esta clave de conexion se debe ajustar al servidor local de la base de datos donde sea probado
        private readonly string claveconexion = "Data Source=SILVER-365\\ELMERSERVER;Initial Catalog=BDCrudTest;Integrated Security = True;Current Language=Spanish; pooling=true;min pool size=5;max pool size=250;";

        public string Claveconexion { get => claveconexion; }

        #region consultar todos los productos de una categoría
        public List<Modelo_tabla_Productos> Tabla_Productos(int idCategoria) //se envia consulta para obtner todos los productos
        {
            List<Modelo_tabla_Productos> lst = new List<Modelo_tabla_Productos>();
            try
            {
                SqlConnection conectar;
                SqlCommand orden = new SqlCommand();
                conectar = new SqlConnection(Claveconexion); //le pasamos la ruta 
                SqlDataReader leerDatos; // variable para lectura
                                         //cadena coon el comnando para la base de datos
                String comando_baseDatos = "exec Usp_Sel_Co_Produtos "+idCategoria+";";

                //definir los parametros y ejecucion a la base datos
                orden.CommandType = CommandType.Text;
                orden.CommandText = comando_baseDatos;
                orden.Connection = conectar;
                conectar.Open();

                leerDatos = orden.ExecuteReader(); // datos que devuelve la consulta en base datos


                if (leerDatos.HasRows)
                {
                    while (leerDatos.Read()) //mientras haya lectura
                    {
                        lst.Add(new Modelo_tabla_Productos //llena la tablaCategoría con la lectura
                        {
                            Codigo_Producto = Convert.ToInt32(leerDatos.GetInt32(0)),
                            Nombre = leerDatos.GetString(1),
                            Precio = Convert.ToInt32(leerDatos.GetInt32(2)),
                            Categoria = leerDatos.GetString(3)
                        }); ;
                    }
                }
                orden.Dispose();
                conectar.Close();
                return lst;
            }
            catch (Exception)
            {

                return lst;
            }


        }


        #endregion


    }
}