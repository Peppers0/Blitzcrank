using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankClient.Cliente
{
    public static class InformacionCuenta
    {
        public static string Apodo { get; set; } = string.Empty;
        public static int Nivel { get; set; } = 0;
        public static bool Conectada { get; set; } = false;

        //**//
        public static bool nombreCuentaEscrito { get; set; } = false;
        public static bool contraseñaCuentaEscrita { get; set; } = false;
        public static bool listaParaConectar { get; set; } = false;
    }
}
