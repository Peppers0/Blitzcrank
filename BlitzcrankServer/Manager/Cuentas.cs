using BlitzcrankServer.Comun;
using BlitzcrankServer.Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankServer.Manager
{
    public class Cuentas
    {
        public List<Cuenta> Lista { get; set; }

        public void Inicializar()
        {
            Lista = new List<Cuenta>();
            Lista = Json.Deserialize<List<Cuenta>>(File.ReadAllText("datos/cuentas.json"));

            Consola.Escribir($"\tHay un total de {Lista.Count} cuentas disponibles", ConsoleColor.Cyan);
        }

        public Cuenta ConectarCuenta()
        {
            Cuenta Cuenta = ObtenerCuentaSinConectar();

            if(Cuenta != null) {
                Cuenta.Conectada = true;
                return Cuenta;
            }

            return null;
        }

        public void DesconectarCuenta(string nombre)
        {
            Cuenta Cuenta = BuscarPorNombre(nombre);

            if(Cuenta != null)
            {
                Cuenta.Conectada = false;
            }
        }

        public Cuenta ObtenerCuentaSinConectar()
        {
            foreach(Cuenta Cuenta in Lista)
            {
                if (!Cuenta.Conectada)
                {
                    return Cuenta;
                }
            }
            return null;
        }

        public Cuenta BuscarPorNombre(string Nombre)
        {
            foreach(Cuenta Cuenta in Lista)
            {
                if(Cuenta.Nombre == Nombre)
                {
                    return Cuenta;
                }
            }
            return null;
        }
    }
}
