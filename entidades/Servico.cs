using System;
using factory;

namespace entidades
{
    public class Servico
    {
        public Reserva reserva{get; set;}
        public bool pediuAlimentacao{ get; set;}
        public bool pediuTelefone { get; set; }
        public DateTime dataServico { get; set; }
    }
}