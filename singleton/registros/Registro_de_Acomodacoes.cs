using System.Collections.Generic;
using factory;

namespace registros
{
    public class Registro_de_Acomodacoes
    {
        private static Registro_de_Acomodacoes instancia;
        public List<IAcomodacao> acomodacoes { get; set;}

        private Registro_de_Acomodacoes()
        {
            acomodacoes = new List<IAcomodacao>();
            
        }

        public static Registro_de_Acomodacoes GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Registro_de_Acomodacoes();
            }
            return instancia;
        }
    }
}