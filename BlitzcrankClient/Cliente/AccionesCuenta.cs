using BlitzcrankClient.Comun;
using BlitzcrankClient.Reconocimiento;
using BlitzcrankClient.Red.Mensajes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;

namespace BlitzcrankClient.Cliente
{
    public static class AccionesCuenta
    {
        private static bool ClienteEjecutado { get; set; } = false;

        public static void Conectar()
        {
            if (Cuenta.Nombre == string.Empty || Cuenta.Contraseña == string.Empty || InformacionCuenta.Conectada)
                return;

            while (!Interop.IsProcessOpen("RiotClientUx"))
            {
                if (!ClienteEjecutado)
                {
                    Process.Start(@Program.Configuracion.CarpetaLeague+ "LeagueClient.exe");
                    ClienteEjecutado = true;
                }

                BotHelper.Wait(5000);
            }

            Interop.BringWindowToFront("RiotClientUx");

            Consola.Debug($"\t[DEBUG] Atención: si no puedes conectar, debes editar 'client.json' y campiar los valores CampoCuenta y CampoContraseña por uno de los valores dados a continuación.", ConsoleColor.Red);
            Consola.Debug($"\t[DEBUG] Si no encuentras estos valores, debes editar en 'client.json' el valor, colorCampos por el color correspondiente (usar Color Viewer) debes convertir el color hex a color rgb (online).", ConsoleColor.Red);
            Consola.Debug($"\t[DEBUG] Los valores son X (izquierda) e Y (derecha), si el de la derecha es mayor entonces el campo es de contraseña, de lo contrario es el campo de la cuenta.", ConsoleColor.Red);
            Consola.Debug($"\t[DEBUG] --------------------------------------------------------------------------------- ", ConsoleColor.Red);

            try
            {
                while (!InformacionCuenta.listaParaConectar)
                {
                    foreach (Point CampoConexion in ImageHelper.getAllExistingColorPositions(Color.FromArgb(Convert.ToInt32(Program.Configuracion.ColorCampos.Split(',')[0]), Convert.ToInt32(Program.Configuracion.ColorCampos.Split(',')[1]), Convert.ToInt32(Program.Configuracion.ColorCampos.Split(',')[2]))))
                    {
                        if (CampoConexion.X == Convert.ToInt32(Program.Configuracion.CampoCuenta.Split(',')[0]) && CampoConexion.Y == Convert.ToInt32(Program.Configuracion.CampoCuenta.Split(',')[1]))
                        {
                            Consola.Escribir($"\tIntroduciendo nombre de la cuenta", ConsoleColor.Green);
                            InputHelper.LeftClick(Convert.ToInt32(Program.Configuracion.CampoCuenta.Split(',')[0])+80, Convert.ToInt32(Program.Configuracion.CampoCuenta.Split(',')[1]));
                            InputHelper.InputWords(Cuenta.Nombre, 200, 200);

                            BotHelper.Wait(1000);

                            InformacionCuenta.nombreCuentaEscrito = true;
                        }
                        if (CampoConexion.X == Convert.ToInt32(Program.Configuracion.CampoContraseña.Split(',')[0]) && CampoConexion.Y == Convert.ToInt32(Program.Configuracion.CampoContraseña.Split(',')[1]))
                        {
                            Consola.Escribir($"\tIntroduciendo contraseña de la cuenta", ConsoleColor.Green);
                            InputHelper.LeftClick(Convert.ToInt32(Program.Configuracion.CampoContraseña.Split(',')[0])+80, Convert.ToInt32(Program.Configuracion.CampoContraseña.Split(',')[1]));
                            InputHelper.InputWords(Cuenta.Contraseña, 200, 200);

                            BotHelper.Wait(1000);

                            InformacionCuenta.contraseñaCuentaEscrita = true;
                        }
                        
                        
                        Consola.Debug($"\t[DEBUG] Campos credenciales encontrados en: {CampoConexion.X},{CampoConexion.Y}", ConsoleColor.Red);

                        if (InformacionCuenta.nombreCuentaEscrito && InformacionCuenta.contraseñaCuentaEscrita) {
                            InformacionCuenta.listaParaConectar = true;

                            break;
                        }
                    }
                }

                Consola.Debug($"\t[DEBUG] --------------------------------------------------------------------------------- ", ConsoleColor.Red);

                InputHelper.PressKey("Enter");

                InformacionCuenta.Conectada = true;

                Consola.Escribir($"\tCuenta conectada; esperando confirmación", ConsoleColor.Green);
            }
            catch(Exception e)
            {
                Consola.Escribir($"\tError: {e.Message}", ConsoleColor.Red);
            }
        }
        public static void Desconectar(StreamWriter escritorStream, bool otraCuenta = false)
        {
            if (!InformacionCuenta.Conectada)
                return;

            Cuenta.Nombre = string.Empty;
            Cuenta.Contraseña = string.Empty;

            InformacionCuenta.nombreCuentaEscrito = false;
            InformacionCuenta.contraseñaCuentaEscrita = false;
            InformacionCuenta.listaParaConectar = false;
            InformacionCuenta.Conectada = false;

            if (otraCuenta)
            {
                foreach (Process Proc in Process.GetProcesses())
                    if (Proc.ProcessName.Equals("RiotClientUx"))
                        Proc.Kill();

                ClienteEjecutado = false;

                Enviados.Nuevo("pedirOtraCuenta()", escritorStream);
            }
        }
    }
}
