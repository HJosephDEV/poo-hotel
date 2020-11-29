using System;
using controladores;

namespace trab_poo
{
    class Program
    {
        static void Main(string[] args)
        {
            Controlador_de_Acomodacoes ca = Controlador_de_Acomodacoes.GetInstancia();
            Controlador_de_Reservas cr = Controlador_de_Reservas.GetInstancia();
            Controlador_de_Servicos cs = Controlador_de_Servicos.GetInstancia();
            Relatorio rl = new Relatorio();
            ca.AdicionandoAcomodacoesIniciais();

            bool control = true;

            while(control == true)
            {

                Console.Write("\n### MENU ###\n");
                Console.WriteLine("1 - Criar Reserva"); // 
                Console.WriteLine("2 - Fornecer Serviço de Hóspedes");//
                Console.WriteLine("3 - Gerar Relatório Diário"); //
                Console.WriteLine("4 - Sair");
                bool opcaoValida = false;
                while(opcaoValida == false)
                {
                    Console.Write("Opção: ");
                    int opcao = int.Parse(Console.ReadLine());
                    switch(opcao)
                    {
                        case 1:
                            opcaoValida = true;
                            cr.CriarReserva();
                            break;
                        case 2:
                            opcaoValida = true;
                            cs.PedirServico();
                            break;
                        case 3:
                            opcaoValida = true;
                            rl.GerarRealatorioDiario();
                            break;
                        case 4:
                            opcaoValida = true;
                            control = false;
                            break;
                        default:
                            Console.WriteLine("\n##### Opção não encontrada #####\n");
                            break;
                    }
                }       
            }
        }
    }
}
