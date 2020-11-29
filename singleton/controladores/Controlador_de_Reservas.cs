using entidades;
using registros;
using System;

namespace controladores
{
    public class Controlador_de_Reservas
    {
        private static Controlador_de_Reservas instancia;
        public Reserva rv;
        public Registro_de_Reservas rr;
        public Controlador_de_Acomodacoes ca;
        public Controlador_de_Clientes cc;

         private Controlador_de_Reservas(){
           
         }

        public static Controlador_de_Reservas GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Controlador_de_Reservas();
            }
            return instancia;
        }

        public void CriarReserva()
        {
            rv = new Reserva();

            ca = Controlador_de_Acomodacoes.GetInstancia();
            rv.acomodacao = ca.SelecionarTipoDeAcomodacao();
            ca.ListarAcomodacoesDisponiveis(rv.acomodacao.tipo);
            rv.acomodacao = ca.SelecionarAcomodacaoDisponivel(rv.acomodacao);
            if(rv.acomodacao != null)
            {
                 Controlador_de_Clientes cc = Controlador_de_Clientes.GetInstancia();
                rv.cliente = cc.GetDadosDeBusca();
                Controlador_de_Reservas cr = Controlador_de_Reservas.GetInstancia();
                
                Random numAleatorio = new Random();
                int valorInteiro = numAleatorio.Next(100,1001);
                rv.reservaID =  valorInteiro;
                Console.WriteLine("Código da reserva: " + valorInteiro);
                cr.RegistrarReserva(rv);
                ca.OcuparAcomodacao(rv.acomodacao);
            }
           
            
        }

        public void RegistrarReserva(Reserva rv)
        {
             Registro_de_Reservas rr = Registro_de_Reservas.GetInstancia();
             rr.reservas.Add(rv);
             Console.WriteLine("\nReserva Registrada com sucesso!!\n");
        }

        public Reserva BuscarReservaDoQuarto(int acomodacaoID)
        {
            Registro_de_Reservas rr = Registro_de_Reservas.GetInstancia();
            for (int i = 0; i < rr.reservas.Count; i++)
            {
                if(rr.reservas[i].acomodacao.acomodacaoID == acomodacaoID)
                {
                    return rr.reservas[i];
                }
            }

            return null;
            
        }
   
    }

}