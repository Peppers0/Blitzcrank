using BlitzcrankClient.Comun;
using BlitzcrankClient.Red;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankClient
{
    public class Program
    {
        public static TcpClient tcpListener;
        public static Configuracion Configuracion { get; set; }

        static void Main(string[] args)
        {
            Consola.Inicializar();

            Configuracion = Json.Deserialize<Configuracion>(File.ReadAllText("client.json"));
            Consola.Escribir($"\tSe ha cargado la configuración", ConsoleColor.Green);

            try
            {
                tcpListener = new TcpClient(Configuracion.Ip, Configuracion.Puerto);
                Consola.Escribir($"\tIp: {Configuracion.Ip}, Puerto: {Configuracion.Puerto}", ConsoleColor.Cyan);

                ClientService.BotClientListener(tcpListener);
            }
            catch
            {
                Consola.Escribir($"\tHa fallado la conexión con el servidor", ConsoleColor.Red);
                return;
            }
        }
    }
}
