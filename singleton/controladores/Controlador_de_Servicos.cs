using registros;
using System;
using entidades;
namespace controladores
{
    public class Controlador_de_Servicos
    {
        private static Controlador_de_Servicos instancia;
        public Servico sv;
        public Registro_de_Servicos rs;
        public Controlador_de_Acomodacoes ca;
        
         private Controlador_de_Servicos(){
           
         }

        public static Controlador_de_Servicos GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Controlador_de_Servicos();
            }
            return instancia;
        }

        public void PedirServico()
        {
            Console.WriteLine("##### Solicitação de Servico #####");
            Console.WriteLine(" 1 - Fornecer Alimentacao ");
            Console.WriteLine(" 2 - Fornercer Telefone ");
            Console.Write("Selecione uma opção: ");
            int op = int.Parse(Console.ReadLine());
            Controlador_de_Servicos cs = Controlador_de_Servicos.GetInstancia();
            cs.SelecionarServico(op);

        }

        public void SelecionarServico(int op)
        {
             Controlador_de_Servicos cs = Controlador_de_Servicos.GetInstancia();
            switch(op)
            {
                case 1:
                    cs.FornecerAlimentacao();
                    break;
                case 2:
                    cs.FornercerTelefone();
                    break;
                default:
                    Console.WriteLine("\nOpção não encontrada!\n");
                    break;
            }
        }

        public void FornercerTelefone()
        {
            sv = new Servico();
            ca = Controlador_de_Acomodacoes.GetInstancia();
            ca.ListarAcomodacoesIndisponiveis();
            int acomodacaoID = ca.SelecionarAcomodacaoIndisponivel();
            if(acomodacaoID != -1)
            {
                 Controlador_de_Reservas cr = Controlador_de_Reservas.GetInstancia();
            Reserva rva = new Reserva();
            
            rva = cr.BuscarReservaDoQuarto(acomodacaoID);
            sv.reserva = rva;
            Controlador_de_Servicos cs = Controlador_de_Servicos.GetInstancia();
            DateTime dataServico = cs.DefinirDataDoServico();
            sv.dataServico = dataServico;
            bool houvePedidoDeServicoDiario = cs.VerificarSeHouveServicoDiario(rva.reservaID, dataServico);
            
            if(houvePedidoDeServicoDiario == false)
            {
                sv.pediuTelefone = true;
                cs.RegistrarServico(sv);
            }
            else
            {   
                cs.AlterarServicoTelefone(rva.reservaID, sv.dataServico);
                Console.WriteLine("oi");
            }
            }
            else
            {
                Console.WriteLine("ops...");
            }
        }

        public void FornecerAlimentacao()
        {
            sv = new Servico();
            ca = Controlador_de_Acomodacoes.GetInstancia();
            ca.ListarAcomodacoesIndisponiveis();
            int acomodacaoID = ca.SelecionarAcomodacaoIndisponivel();
            Controlador_de_Reservas cr = Controlador_de_Reservas.GetInstancia();
            Reserva rva = new Reserva();
            
            rva = cr.BuscarReservaDoQuarto(acomodacaoID);
            sv.reserva = rva;
            Controlador_de_Servicos cs = Controlador_de_Servicos.GetInstancia();
            DateTime dataServico = cs.DefinirDataDoServico();
            sv.dataServico = dataServico;
            bool houvePedidoDeServicoDiario = cs.VerificarSeHouveServicoDiario(rva.reservaID, dataServico);
            
            if(houvePedidoDeServicoDiario == false)
            {
                sv.pediuAlimentacao = true;
                cs.RegistrarServico(sv);
            }
            else
            {   
                cs.AlterarServicoAlimentacao(rva.reservaID, sv.dataServico);
                Console.WriteLine("oi");
            }
            
        }

        public void AlterarServicoAlimentacao(int reservaID, DateTime data)
        {
            Registro_de_Servicos rs = Registro_de_Servicos.GetInstancia();
            for (int i = 0; i < rs.servicos.Count; i++)
            {
                if(rs.servicos[i].reserva.reservaID == reservaID && rs.servicos[i].dataServico == data)
                {
                    rs.servicos[i].pediuAlimentacao = true;
                }
            }
        }

         public void AlterarServicoTelefone(int reservaID, DateTime data)
        {
            Registro_de_Servicos rs = Registro_de_Servicos.GetInstancia();
            for (int i = 0; i < rs.servicos.Count; i++)
            {
                if(rs.servicos[i].reserva.reservaID == reservaID && rs.servicos[i].dataServico == data)
                {
                    rs.servicos[i].pediuTelefone = true;
                }
            }
        }


        public DateTime DefinirDataDoServico()
        {
            Console.WriteLine("##### Data de Hoje #####");
            Console.Write("Dia: ");
            int diaServico = int.Parse(Console.ReadLine());
            Console.Write("Mês: ");
             int mesServico = int.Parse(Console.ReadLine());
            Console.Write("Dia: ");
             int anoServico = int.Parse(Console.ReadLine());
            DateTime dataServico = new DateTime(anoServico, mesServico, diaServico);

            return dataServico;
        }

        public void RegistrarServico(Servico sv)
        {
            rs = Registro_de_Servicos.GetInstancia();
            rs.servicos.Add(sv);
            Console.WriteLine("Servico solicitado com sucesso!");
        } 

        public bool VerificarSeHouveServicoDiario(int reservaID, DateTime dataServico)
        {
            rs = Registro_de_Servicos.GetInstancia();
            for (int i = 0; i < rs.servicos.Count; i++)
            {
                if(rs.servicos[i].reserva.reservaID == reservaID && rs.servicos[i].dataServico == dataServico)
                {
                    return true;
                }
            }

            return false;
        }
         
    }

}