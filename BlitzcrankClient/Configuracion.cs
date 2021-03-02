using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankClient
{
    public class Configuracion
    {
        public bool Debug { get; set; } = true;
        public string CarpetaLeague { get; set; }
        public string Ip { get; set; }
        public int Puerto { get; set; }
        public string CampoCuenta { get; set; }
        public string CampoContraseña { get; set; }
        public string ColorCampos { get; set; }
    }
}
