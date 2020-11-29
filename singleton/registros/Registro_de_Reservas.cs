using System.Collections.Generic;
using entidades;

namespace registros
{
    public class Registro_de_Reservas
    {
        private static Registro_de_Reservas instancia;
        public List<Reserva> reservas { get; set;}

        private Registro_de_Reservas()
        {
            reservas = new List<Reserva>();
            
        }

        public static Registro_de_Reservas GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Registro_de_Reservas();
            }
            return instancia;
        }
    }
}