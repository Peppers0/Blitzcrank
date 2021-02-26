using BlitzcrankServer.Comun;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankServer.Red.Mensajes
{
    class Recibidos
    {
        internal static void Interpretar(string mensajeRecibido, StreamReader lectorStream, StreamWriter escritorStream, Socket BotSocket)
        {
            if (mensajeRecibido != null)
            {
                Consola.Escribir($"\t( Recibido ) # {BotSocket.RemoteEndPoint}: {mensajeRecibido}", ConsoleColor.DarkCyan);

                switch (mensajeRecibido)
                {
                    case "desconectar()":
                        ServerService.MantenerConexion = false;
                        
                        break;
                    case "ping()":
                        Ping pinger = new Ping();
                        PingReply reply = pinger.Send(Program.Configuracion.Ip);
                        Enviados.Nuevo($"pong()|{reply.RoundtripTime}", escritorStream, BotSocket);
                        break;
                    default:
                        Enviados.Nuevo($"nada()", escritorStream, BotSocket);
                        break;
                }
            }
        }
    }
}
