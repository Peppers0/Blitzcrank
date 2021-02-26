using BlitzcrankServer.Comun;
using BlitzcrankServer.Datos;
using BlitzcrankServer.Manager;
using BlitzcrankServer.Red;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlitzcrankServer
{
    public class Program
    {
        public static TcpListener tcpListener;
        public static Configuracion Configuracion { get; set; }
        public static Cuentas Cuentas { get; set; } = new Cuentas();
        public static Campeones Campeones { get; set; } = new Campeones();
        static void Main(string[] args)
        {
            Consola.Inicializar();

            Configuracion = Json.Deserialize<Configuracion>(File.ReadAllText("server.json"));
            Consola.Escribir($"\tSe ha cargado la configuración", ConsoleColor.Green);

            Cuentas.Inicializar();
            Campeones.Inicializar();

            tcpListener = new TcpListener(IPAddress.Parse(Configuracion.Ip), Configuracion.Puerto);

            tcpListener.Start();

            Consola.Escribir($"\tServidor iniciado con un límite de {Program.Configuracion.LimiteBots} bot(s)", ConsoleColor.Cyan);
            Consola.Escribir($"\tIp: {Configuracion.Ip}, Puerto: {Configuracion.Puerto}", ConsoleColor.Cyan);

            for (int i = 0; i < Configuracion.LimiteBots; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Thread newThread = new Thread(new ThreadStart(ServerService.BotListener));
                newThread.Start();
            }

            Consola.LeerInput();
        }
    }
}
