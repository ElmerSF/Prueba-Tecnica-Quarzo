/*Esta clase es un espejo de la base de datos de la tabla Categorías donde se usan las variables 
 * para intercambiar los datos
 * 
 * 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_Quarzo.Models
{
    public class Modelo_tabla_Categorias
    {
        public int Codigo_Categoria { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}