using BlitzcrankServer.Comun;
using BlitzcrankServer.Datos;
using BlitzcrankServer.Red.Mensajes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlitzcrankServer.Red
{
    public static class Acciones
    {
        public static void alConectar(Socket botSocket)
        {
            Consola.Escribir($"\t( Conexión ) # {botSocket.RemoteEndPoint}", ConsoleColor.Green);
        }
        public static void alDesconectar(Socket botSocket)
        {
            Consola.Escribir($"\t( Desconexión ) # {botSocket.RemoteEndPoint}", ConsoleColor.Red);
            
            foreach(KeyValuePair<Socket, string> Client in ServerService.clientesConectados)
            {
                if (Client.Key.RemoteEndPoint.Equals(botSocket.RemoteEndPoint))
                {
                    Program.Cuentas.DesconectarCuenta(Client.Value);
                }
            }

            ServerService.clientesConectados.Remove(botSocket);

            botSocket.Close();
            ServerService.MantenerConexion = true;

            Thread newThread = new Thread(new ThreadStart(ServerService.BotListener));
            newThread.Start();
        }
        public static void alRecibir()
        {

        }
        public static void alEnviar()
        {

        }
        public static void Handshake(Socket BotSocket, StreamWriter escritorStream)
        {
            Cuenta Cuenta = Program.Cuentas.ConectarCuenta();

            if (Cuenta != null)
            {
                Enviados.Nuevo($"bienvenido()|{Cuenta.Nombre}|{Cuenta.Contraseña}", escritorStream, BotSocket);

                ServerService.clientesConectados.Add(BotSocket, Cuenta.Nombre);
            }
            else
            {
                Enviados.Nuevo($"sinCuentasDisponibles()", escritorStream, BotSocket);
            }
        }
    }
}
