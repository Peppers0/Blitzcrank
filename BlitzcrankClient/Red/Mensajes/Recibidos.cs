using BlitzcrankClient.Cliente;
using BlitzcrankClient.Comun;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankClient.Red.Mensajes
{
    public static class Recibidos
    {
        public static void Interpretar(string mensajeRecibido, StreamReader lectorStream)
        {
            if (mensajeRecibido != "nada()")
            {
                if (!mensajeRecibido.Contains("bienvenido()"))
                    Consola.Escribir($"\t( Recibido ) # {mensajeRecibido}", ConsoleColor.DarkCyan);
            }

            switch (mensajeRecibido)
            {
                case string bienvenido when bienvenido.Contains("bienvenido()"):
                    Consola.Escribir($"\tCuenta otorgada por el servidor: {mensajeRecibido.Split('|')[1]}", ConsoleColor.Green);
                    Cuenta.Nombre = mensajeRecibido.Split('|')[1];
                    Cuenta.Contraseña = mensajeRecibido.Split('|')[2];
                    lectorStream.BaseStream.Flush();
                    break;
                case string sinCuentas when sinCuentas.Contains("sinCuentasDisponibles()"):
                    Consola.Escribir($"\tEl servidor no te ha podido otorgar cuenta por que no quedan cuentas disponibles", ConsoleColor.Red);
                    lectorStream.BaseStream.Flush();
                    break;
                case string pong when pong.Contains("pong()"):
                    Consola.Escribir($"\tPing: {mensajeRecibido.Split('|')[1]} ms", ConsoleColor.Green);
                    lectorStream.BaseStream.Flush();
                    break;
                default:
                    lectorStream.BaseStream.Flush();
                    break;
            }

        }
    }
}
