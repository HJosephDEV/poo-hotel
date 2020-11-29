using System.Collections.Generic;
using entidades;

namespace registros
{
    public class Registro_de_Servicos
    {
        private static Registro_de_Servicos instancia;
        public List<Servico> servicos { get; set;}

        private Registro_de_Servicos()
        {
            servicos = new List<Servico>();
        }

        public static Registro_de_Servicos GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Registro_de_Servicos();
            }
            return instancia;
        }
    }
}