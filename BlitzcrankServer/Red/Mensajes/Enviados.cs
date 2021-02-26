using BlitzcrankServer.Comun;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankServer.Red.Mensajes
{
    public static class Enviados
    {
        public static void Nuevo(string mensaje, StreamWriter escritorStream, Socket botSocket)
        {
            escritorStream.WriteLine(mensaje);
            if (!mensaje.Contains("bienvenido()"))
            {
                Consola.Escribir($"\t( Envíado ) # {botSocket.RemoteEndPoint}: {mensaje}", ConsoleColor.Yellow);
            }
            else
            {
                Consola.Escribir($"\t( Envíado ) # {botSocket.RemoteEndPoint}: bienvenido()", ConsoleColor.Yellow);
            }
            escritorStream.Flush();
        }
    }
}
