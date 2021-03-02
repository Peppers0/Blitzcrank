using BlitzcrankServer.Comun;
using BlitzcrankServer.Datos;
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
                    case string formarGrupo when formarGrupo.Contains("formarGrupo()"):
                        List<string> grupoCuentas = new List<string>();
                        foreach(Cuenta Cuenta in Program.Cuentas.Lista)
                        {
                            if(Cuenta.Conectada && !Cuenta.EnGrupo && grupoCuentas.Count<4)
                            grupoCuentas.Add(Cuenta.Apodo);
                        }
                        if(grupoCuentas.Count>=1)
                        Enviados.Nuevo($"grupoFormado()|{string.Join(",", grupoCuentas.ToArray())}", escritorStream, BotSocket);
                        break;
                    case string iniciarPartidas when iniciarPartidas.Contains("iniciarPartidas()"):
                        //Enviados.Nuevo($"()", escritorStream, BotSocket);
                        break;
                    default:
                        Enviados.Nuevo($"nada()", escritorStream, BotSocket);
                        break;
                }
            }
        }
    }
}
