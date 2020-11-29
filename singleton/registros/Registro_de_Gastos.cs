using System.Collections.Generic;
using entidades;

namespace registros
{
    public class Registro_de_Gastos
    {
        private static Registro_de_Gastos instancia;
        public List<Gastos> gastos { get; set;}

        private Registro_de_Gastos()
        {
            gastos = new List<Gastos>();
            
        }

        public static Registro_de_Gastos GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Registro_de_Gastos();
            }
            return instancia;
        }
    }
}