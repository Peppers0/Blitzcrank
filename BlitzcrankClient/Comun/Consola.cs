using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankClient.Comun
{
    public class Consola
    {
        public static void Inicializar()
        {
            Console.Title = $"{System.Reflection.Assembly.GetExecutingAssembly()}";
            Fondo(ConsoleColor.Gray);
            NuevaLinea();
            Escribir($"\t{System.Reflection.Assembly.GetExecutingAssembly()}", ConsoleColor.DarkMagenta);
            Escribir($"\tZorbuk - https://github.com/zorbuk", ConsoleColor.DarkMagenta);
            NuevaLinea();
        }

        public static void Fondo(ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            Console.Clear();
        }

        public static void TabLinea(ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            Console.Write("\t");
        }

        public static void Escribir(String Mensaje, ConsoleColor Color = ConsoleColor.Black)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"{Mensaje}");
        }

        public static void Debug(String Mensaje, ConsoleColor Color = ConsoleColor.Black)
        {
            if (Program.Configuracion.Debug)
            {
                Console.ForegroundColor = Color;
                Console.WriteLine($"{Mensaje}");
            }
        }
        public static void NuevaLinea()
        {
            Console.WriteLine();
        }
        public static void LeerInput()
        {
            Console.ReadKey();
        }
    }
}
