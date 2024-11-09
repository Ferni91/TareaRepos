using System; 
namespace GestiónInventario
{
    class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("Bienvenido al sistema de gestión de inventario");

            // Ingreso de productos por el usuario.
            Console.WriteLine("¿Cuántos productos desea ingresar?");
            int cantidad;
            while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Por favor, ingrese un número entero positivo.");
            }

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1} ");

                string nombre;
                do
                {
                    Console.WriteLine("Nombre: ");
                    nombre = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("El nombre del producto no puede estar vacío.");
                    }
                } while (string.IsNullOrWhiteSpace(nombre));

                decimal precio;
                do
                {
                    Console.WriteLine("Precio: ");
                    if (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                    {
                        Console.WriteLine("Por favor, ingrese un precio válido (número positivo).");
                    }
                } while (precio <= 0);

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);
            }
            decimal precioMinimo;
            do
            {
                Console.WriteLine("\nIngrese el precio mínimo para filtrar los productos: ");
                if (!decimal.TryParse(Console.ReadLine(), out precioMinimo) || precioMinimo < 0)
                {
                    Console.WriteLine("Por favor, ingrese un precio mínimo válido (número no negativo).");
                }
            } while (precioMinimo < 0);

            // Filtrar y mostrar productos
            var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

            Console.WriteLine("\nProductos filtrados y ordenados: ");
            if (!productosFiltrados.Any())
            {
                Console.WriteLine("No hay productos que cumplan con el criterio de filtro.");
            }
            else
            {
                foreach (var producto in productosFiltrados)
                {
                    producto.MostrarDatos();
                }
            }
        }
    }
}