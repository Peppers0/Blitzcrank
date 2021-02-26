using BlitzcrankServer.Comun;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankServer.Manager
{
    public class Campeones
    {
        public List<Campeon> Lista { get; set; }

        public void Inicializar()
        {
            Lista = new List<Campeon>();
            Lista = Json.Deserialize<List<Campeon>>(File.ReadAllText("datos/campeones.json"));
            
            Consola.Escribir($"\tHay un total de {Lista.Count} campeones disponibles", ConsoleColor.Cyan);
        }

        public string obtenerRol(string Nombre)
        {
            foreach(Campeon Campeon in Lista)
            {
                if(Campeon.Nombre == Nombre)
                {
                    return Campeon.Rol;
                }
            }

            return String.Empty;
        }

        public string ObtenerObjetosCampeon(string Nombre)
        {
            string Rol = obtenerRol(Nombre);

            switch (Rol)
            {
                case "ap":
                    return "";
                case "ad":
                    return "";
                case "adc":
                    return "";
            }

            return String.Empty;
        }
    }
}
