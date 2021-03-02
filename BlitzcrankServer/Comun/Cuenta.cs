using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankServer.Datos
{
    public class Cuenta
    {
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Apodo { get; set; } = string.Empty;
        public int Nivel { get; set; } = 0;
        public bool Conectada { get; set; } = false;
        public bool EnGrupo { get; set; } = false;
    }
}
