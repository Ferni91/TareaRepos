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
        }
    }
}