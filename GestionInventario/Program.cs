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
        }
    }
}