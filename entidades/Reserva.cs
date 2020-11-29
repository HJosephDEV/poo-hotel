using System;
using factory;

namespace entidades
{
    public class Reserva
    {
        public int reservaID { get; set;}
        public Cliente cliente { get; set; }
        public IAcomodacao acomodacao { get; set; }
        public DateTime diaEntrada { get; set; }
        public DateTime diaSaida { get; set; }
  
    }
}