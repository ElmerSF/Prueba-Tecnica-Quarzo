/*Esta clase es un espejo de la base de datos de la tabla Productos y se utiliza para intercambiar los datos
 * a través de las variables definidas
 *  
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_Quarzo.Models
{
    public class Modelo_tabla_Productos
    {
        public int Codigo_Producto { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Categoria { get; set; }

    }
}