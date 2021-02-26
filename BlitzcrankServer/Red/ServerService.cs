using BlitzcrankServer.Comun;
using BlitzcrankServer.Datos;
using BlitzcrankServer.Manager;
using BlitzcrankServer.Red.Mensajes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlitzcrankServer.Red
{
    public static class ServerService
    {
        public static Dictionary<Socket, string> clientesConectados = new Dictionary<Socket, string>();
        public static bool MantenerConexion = true;

        public static void BotListener()
        {
            Socket BotSocket = Program.tcpListener.AcceptSocket();
            
            if (BotSocket.Connected)
            {
                Acciones.alConectar(BotSocket);
                
                NetworkStream redStream = new NetworkStream(BotSocket);
                StreamWriter escritorStream = new StreamWriter(redStream);
                StreamReader lectorStream = new StreamReader(redStream);

                Acciones.Handshake(BotSocket, escritorStream);

                while (MantenerConexion)
                {
                    string mensajeRecibido = lectorStream.ReadLine();

                    Recibidos.Interpretar(mensajeRecibido, lectorStream, escritorStream, BotSocket);
                }

                lectorStream.Close();
                redStream.Close();
                escritorStream.Close();
            }

            Acciones.alDesconectar(BotSocket);
            Consola.LeerInput();
        }
    }
}
