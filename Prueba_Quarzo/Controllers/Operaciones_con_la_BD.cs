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

        #region modificar una categoría de producto o insertar una nueva
        public List<Modelo_tabla_Categorias> Modificar_Categoria(Modelo_tabla_Categorias nuevo_registro) //se modifica un Registro de Categoría o se inserta
        {
            
            List<Modelo_tabla_Categorias> list = new List<Modelo_tabla_Categorias>();
            try
            {
                //se envia el parametro a la base de datos
                String parametro = "exec Usp_Ins_Co_Categoria @Codigo_Categoria, @Nombre, @Activo, 0;" ;
                SqlConnection conectar;
                SqlCommand orden = new SqlCommand();
                conectar = new SqlConnection(Claveconexion);
                
                orden.CommandType = CommandType.Text;
                orden.CommandText = parametro;
                orden.Connection = conectar;
                conectar.Open();

                //parametrizacion de los datos hacia la base de datos
                orden.Parameters.AddWithValue("@Codigo_Categoria", nuevo_registro.Codigo_Categoria);
                orden.Parameters.AddWithValue("@Nombre", nuevo_registro.Nombre);
                orden.Parameters.AddWithValue("@Activo", nuevo_registro.Activo);
                SqlDataReader leerDatos; // variable para lectura
                leerDatos = orden.ExecuteReader(); // datos que devuelve la consulta en base datos

                    if (leerDatos.HasRows)
                    {
                        while (leerDatos.Read()) //mientras haya lectura
                        {
                            list.Add(new Modelo_tabla_Categorias //llena la tablaCategoría con la lectura
                            {
                                Codigo_Categoria = Convert.ToInt32(leerDatos.GetInt32(0)),
                                Nombre = leerDatos.GetString(1),
                                Activo = Convert.ToBoolean(leerDatos.GetBoolean(2)),
                                
                            }); ;
                        }
                    }

                    orden.Dispose();
                    conectar.Close();
                    
                

            }
            catch
            {

                
            }

            return list;
        }

        #endregion

        #region eliminar una categoría
        public string Eliminar_Categoria(Modelo_tabla_Categorias nuevo_registro) //se modifica un Registro de Categoría o se inserta
        {
            Boolean confirmacion;
            string cadena = "No se puedo eliminar registro";
            try
            {
                //se envia el parametro a la base de datos
                String parametro = "exec Usp_Ins_Co_Categoria @Codigo_Categoria, @Nombre, @Activo, 1;";
                SqlConnection conectar;
                SqlCommand orden = new SqlCommand();
                conectar = new SqlConnection(Claveconexion);
               // SqlDataReader leerDatos; // variable para lectura

                orden.CommandType = CommandType.Text;
                orden.CommandText = parametro;
                orden.Connection = conectar;
                conectar.Open();

                //parametrizacion de los datos hacia la base de datos
                orden.Parameters.AddWithValue("@Codigo_Categoria", nuevo_registro.Codigo_Categoria);
                orden.Parameters.AddWithValue("@Nombre", nuevo_registro.Nombre);
                orden.Parameters.AddWithValue("@Activo", nuevo_registro.Activo);



                confirmacion = orden.ExecuteNonQuery() > 0;
                if (confirmacion)
                {
                    cadena = "Se elimino el registro";

                    orden.Dispose();
                    conectar.Close();
                   
                }

            }
            catch (Exception e)
            {
                cadena = "Paso un error " + e;

            }

            return cadena;
        }
        #endregion


    }
}