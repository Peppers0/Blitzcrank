using BlitzcrankClient.Comun;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankClient.Red.Mensajes
{
    public static class Enviados
    {
        public static void Nuevo(string mensajeEnviado, StreamWriter escritorStream)
        {
            Consola.TabLinea(ConsoleColor.Yellow);
            mensajeEnviado = Console.ReadLine();

            escritorStream.WriteLine(mensajeEnviado);
            escritorStream.Flush();

            Consola.Escribir($"\t( Enviado ) # {mensajeEnviado}", ConsoleColor.Yellow);
        }

        public static void Interpretar(string mensajeEnviado, StreamWriter escritorStream)
        {
            switch (mensajeEnviado)
            {
                case "desconectar()":
                    ClientService.recibiendo = false;

                    escritorStream.WriteLine(mensajeEnviado);
                    escritorStream.Flush();
                    break;
            }
        }
    }
}
