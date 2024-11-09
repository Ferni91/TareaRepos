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
            string opcion;
            do
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Actualizar el precio de un producto");
                Console.WriteLine("2. Eliminar un producto");
                Console.WriteLine("3. Contar y agrupar productos por precio");
                Console.WriteLine("4. Salir");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Actualizar el precio de productos
                        string actualizarOtro;
                        do
                        {
                            Console.WriteLine("Ingrese el nombre del producto que desea actualizar:");
                            string nombreProducto = Console.ReadLine();

                            decimal nuevoPrecio;
                            do
                            {
                                Console.WriteLine("Ingrese el nuevo precio:");
                                if (!decimal.TryParse(Console.ReadLine(), out nuevoPrecio) || nuevoPrecio <= 0)
                                {
                                    Console.WriteLine("Por favor, ingrese un precio válido (número positivo).");
                                }
                            } while (nuevoPrecio <= 0);

                            bool actualizado = inventario.ActualizarPrecioProductos(nombreProducto, nuevoPrecio);
                            if (actualizado)
                            {
                                Console.WriteLine("El precio del producto ha sido actualizado.");
                            }
                            else
                            {
                                Console.WriteLine("Producto no encontrado.");
                            }

                            Console.WriteLine("¿Desea actualizar otro producto? (s/n)");
                            actualizarOtro = Console.ReadLine();
                        } while (actualizarOtro.Equals("s", StringComparison.OrdinalIgnoreCase));
                        break;

                    case "2":
                        // Eliminar productos
                        string eliminarOtro;
                        do
                        {
                            Console.WriteLine("Ingrese el nombre del producto que desea eliminar:");
                            string nombreProducto = Console.ReadLine();

                            bool eliminado = inventario.EliminarProducto(nombreProducto);
                            if (eliminado)
                            {
                                Console.WriteLine("El producto ha sido eliminado.");
                            }
                            else
                            {
                                Console.WriteLine("Producto no encontrado.");
                            }

                            Console.WriteLine("¿Desea eliminar otro producto? (s/n)");
                            eliminarOtro = Console.ReadLine();
                        } while (eliminarOtro.Equals("s", StringComparison.OrdinalIgnoreCase));
                        break;

                    case "3":
                        // Contar y agrupar productos por precio
                        var grupos = inventario.ContarYAgruparProductosPorPrecio();
                        Console.WriteLine("\nConteo de productos por rango de precios:");
                        foreach (var grupo in grupos)
                        {
                            Console.WriteLine($"{grupo.Key}: {grupo.Value}");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Saliendo del sistema de gestión de inventario.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 4.");
                        break;
                }

            } while (opcion != "4");
        }
    }
}