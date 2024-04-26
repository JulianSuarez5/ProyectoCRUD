using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRUD.ENTIDADES
{
    public class clsE_Productos
    {
        public int Id_Producto { get; set; }
        public string Descripcion_Producto { get; set; }
        public string Marca_Producto { get; set; }
        public int Id_Medidas { get; set; }
        public int Id_Categorias { get; set; }
        public decimal Stock_Actual {  get; set; }
    }
}
