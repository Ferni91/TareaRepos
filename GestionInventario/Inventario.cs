using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiónInventario
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public IEnumerable<Producto> FiltrarYOrdenarProductos(decimal precioMinimo)
        {
            //Filtrar y ordenar productos con LINQ y expresiones lambda
            return productos
             .Where(p => p.Precio > precioMinimo)//Filtra productos con precio mayor al minimo especificado
                 .OrderBy(p => p.Precio); //ordena los productos de menor a mayor precio
        }
    }
}
