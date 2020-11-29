using System.Collections.Generic;
using entidades;

namespace registros
{
    public class Registro_de_Clientes
    {
        private static Registro_de_Clientes instancia;
        public List<Cliente> clientes { get; set;}

        private Registro_de_Clientes()
        {
            clientes = new List<Cliente>();
        }

        public static Registro_de_Clientes GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Registro_de_Clientes();
            }
            return instancia;
        }
    }
}