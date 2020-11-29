using registros;
using factory;
using System;

namespace controladores
{
    public class Controlador_de_Acomodacoes
    {
        private static Controlador_de_Acomodacoes instancia;
        public IAcomodacao ac;
        public Registro_de_Acomodacoes ra;
        
         private Controlador_de_Acomodacoes(){
           
         }

        public static Controlador_de_Acomodacoes GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Controlador_de_Acomodacoes();
            }
            return instancia;
        }

         public IAcomodacao SelecionarTipoDeAcomodacao()
        {
             ac = null;
            Controlador_de_Acomodacoes ca = Controlador_de_Acomodacoes.GetInstancia();

            Console.WriteLine("\n\n##### Tipos de Acomodações #####");
            Console.WriteLine("1 - Simples");
            Console.WriteLine("2 - Dupla");
            Console.WriteLine("3 - Tripla");
            int op = int.Parse(Console.ReadLine());
  
            ac = ca.InstanciarTipoDeAcomodacao(op, ac);

            return ac;
        }

        public IAcomodacao InstanciarTipoDeAcomodacao(int op, IAcomodacao ac)
        {
            switch(op)
            {
                case 1:
                    ac = new Acomodacao_Simples();
                    break;
                case 2:
                    ac = new Acomodacao_Dupla();
                    break;
                case 3:
                    ac = new Acomodacao_Tripla();
                    break;
            }

            return ac;
        }

        public void ListarAcomodacoesDisponiveis(string tipo)
        {
            Registro_de_Acomodacoes ra = Registro_de_Acomodacoes.GetInstancia();
            Console.WriteLine("\n\n#### Quartos Disponíveis ####");
            foreach(IAcomodacao element in ra.acomodacoes)
            {
                if(element.disponibilidade == true && element.tipo == tipo)
                {
                    Console.Write("Acomodação N°" + element.acomodacaoID);
                    Console.WriteLine(" Tipo: " + element.tipo);
                }
            }
        }

        public void ListarAcomodacoesIndisponiveis()
        {
            Registro_de_Acomodacoes ra = Registro_de_Acomodacoes.GetInstancia();
            Console.WriteLine("\n\n#### Acomodações ocupadas ####");
            foreach(IAcomodacao element in ra.acomodacoes)
            {
                if(element.disponibilidade == false)
                {
                    Console.Write("Acomodação N°" + element.acomodacaoID);
                    Console.WriteLine(" Tipo: " + element.tipo);
                }
            }
        }


        public IAcomodacao SelecionarAcomodacaoDisponivel(IAcomodacao ac)
        {
            Controlador_de_Acomodacoes ca = Controlador_de_Acomodacoes.GetInstancia();

            Console.Write("\nInsira o número da Acomodação: ");
            ac.acomodacaoID = int.Parse(Console.ReadLine());
            bool v =ca.VerificarIDeTipo(ac.tipo, ac.acomodacaoID);
            if(v == true)
            {
                ac = ca.GetAcomodacao(ac);

                return ac;
            }
            Console.WriteLine("ops... Algo deu errado");
            return null;
            
        }

        public bool VerificarIDeTipo(string tipo, int id)
        {
            Registro_de_Acomodacoes ra = Registro_de_Acomodacoes.GetInstancia();
            for (int i = 0; i < ra.acomodacoes.Count; i++)
            {
                if((ra.acomodacoes[i].acomodacaoID == id && ra.acomodacoes[i].tipo == tipo) && ra.acomodacoes[i].disponibilidade == true)
                {
                    return true;
                }
                
            }
            return false;
        }
         public int SelecionarAcomodacaoIndisponivel()
        {
            Console.Write("Insira o número da Acomodação: ");
            int acomodacaoID = int.Parse(Console.ReadLine());
            Controlador_de_Acomodacoes ca = Controlador_de_Acomodacoes.GetInstancia();
            bool v = ca.VerificarAcomodacaoIndisponivel(acomodacaoID);
            if(v == true)
            {
                 return acomodacaoID;
            }
            return -1;
        }

        public bool VerificarAcomodacaoIndisponivel(int acomodacaoID)
        {

            Registro_de_Acomodacoes ra = Registro_de_Acomodacoes.GetInstancia();
            for (int i = 0; i < ra.acomodacoes.Count; i++)
            {
                if(ra.acomodacoes[i].acomodacaoID == acomodacaoID && ra.acomodacoes[i].disponibilidade == false)
                {
                    return true;
                }
            }
            return false;
        }
        public string PegarTipo(int acomodacaoID)
        {
             Registro_de_Acomodacoes ra = Registro_de_Acomodacoes.GetInstancia();
            for (int i = 0; i < ra.acomodacoes.Count ; i++)
            {
                if(ra.acomodacoes[i].acomodacaoID == acomodacaoID)
                {
                    string tipo = ra.acomodacoes[i].tipo;
                    Console.WriteLine("\nTipo Resgatado com sucesso!\n");
                    return tipo;
                }
            }
            return null;
        }

        public IAcomodacao InstanciarAcomodacaoPorTipo(string tipo)
        {
            IAcomodacao ac = null;
            switch(tipo)
            {
                case "Simples":
                    ac = new Acomodacao_Simples();
                    break;
                case "Dupla":
                    ac = new Acomodacao_Dupla();
                    break;
                case "Tripla":
                    ac = new Acomodacao_Tripla();
                    break;
            }   

            return ac;
        }

        public IAcomodacao GetAcomodacao(IAcomodacao ac)
        {
            Registro_de_Acomodacoes ra = Registro_de_Acomodacoes.GetInstancia();
            for (int i = 0; i < ra.acomodacoes.Count ; i++)
            {
                if(ra.acomodacoes[i].acomodacaoID == ac.acomodacaoID)
                {
                    ac = ra.acomodacoes[i];
                    Console.WriteLine("\nAcomodação Resgatada com sucesso!\n");
                }
            }
            return ac;
        }



        public void OcuparAcomodacao(IAcomodacao ac)
        {
             Registro_de_Acomodacoes ra = Registro_de_Acomodacoes.GetInstancia();
               for (int i = 0; i < ra.acomodacoes.Count ; i++)
            {
                if(ra.acomodacoes[i].acomodacaoID == ac.acomodacaoID)
                {
                    ra.acomodacoes[i].disponibilidade = false;
                    Console.WriteLine("Acomodação ocupada com sucesso!");
                }
            }
        }

         public void DesocuparAcomodacao(IAcomodacao ac)
        {
             Registro_de_Acomodacoes ra = Registro_de_Acomodacoes.GetInstancia();
               for (int i = 0; i < ra.acomodacoes.Count ; i++)
            {
                if(ra.acomodacoes[i].acomodacaoID == ac.acomodacaoID)
                {
                    ra.acomodacoes[i].disponibilidade = true;
                }
            }
        }

        public void AdicionandoAcomodacoesIniciais()
        {
            Registro_de_Acomodacoes ra = Registro_de_Acomodacoes.GetInstancia();
            IAcomodacao ac = null;
            for (int i = 0; i < 5; i++)
            {
                ac = new Acomodacao_Simples();
                ac.acomodacaoID = 100 + i;
                ra.acomodacoes.Add(ac);
            } 
            for (int i = 5; i < 10; i++)
            {
                ac = new Acomodacao_Dupla();
                ac.acomodacaoID = 100 + i;
                ra.acomodacoes.Add(ac);
            } 
            for (int i = 10; i < 15; i++)
            {
                ac = new Acomodacao_Tripla();
                ac.acomodacaoID = 100 + i;
                ra.acomodacoes.Add(ac);
            } 

        }
    }

}