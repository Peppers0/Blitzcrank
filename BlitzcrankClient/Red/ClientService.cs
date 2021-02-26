using BlitzcrankClient.Cliente;
using BlitzcrankClient.Comun;
using BlitzcrankClient.Red.Mensajes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankClient.Red
{
    public static class ClientService
    {
        public static bool recibiendo = true;

        public static void BotClientListener(TcpClient tcpListener)
        {
            NetworkStream redStream = tcpListener.GetStream();
            StreamReader lectorStream = new StreamReader(redStream);
            StreamWriter escritorStream = new StreamWriter(redStream);

            escritorStream.BaseStream.ReadTimeout = 200;
            lectorStream.BaseStream.ReadTimeout = 200;

            try
            {
                string mensajeRecibido = String.Empty;
                string mensajeEnviado = String.Empty;
                {

                    while (recibiendo)
                    {
                        mensajeRecibido = lectorStream.ReadLine();

                        Recibidos.Interpretar(mensajeRecibido, lectorStream);
                        Enviados.Nuevo(mensajeEnviado, escritorStream);
                    }

                    Enviados.Interpretar(mensajeEnviado, escritorStream);
                }
            }
            catch(Exception e)
            {
                Consola.Escribir($"\t( Error ) Excepción leyendo del servidor: {e.Message}", ConsoleColor.Red);
            }

            redStream.Close();
        }
    }
}
