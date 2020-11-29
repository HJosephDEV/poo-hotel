using entidades;
using registros;
using System;

namespace controladores
{
    public class Controlador_de_Clientes
    {
        private static Controlador_de_Clientes instancia;
        public Cliente cl;
        public Registro_de_Clientes rc;

         private Controlador_de_Clientes(){
          
         }

        public static Controlador_de_Clientes GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Controlador_de_Clientes();

            }
            return instancia;
        }

        public Cliente GetDadosDeBusca()
        {
            cl = new Cliente();

            Controlador_de_Clientes cc = Controlador_de_Clientes.GetInstancia();
            Console.WriteLine("\n##### Busca por cadastro #####\n");
            Console.Write("Nome: ");
            cl.nome = Console.ReadLine();
            Console.WriteLine("\n##### Data de Nascimento #####");
            Console.Write("Dia: ");
            int diaNasc = int.Parse(Console.ReadLine());
            Console.Write("Mês: ");
            int mesNasc = int.Parse(Console.ReadLine());
            Console.Write("Ano: ");
            int anoNasc = int.Parse(Console.ReadLine());
            cl.dataNascimento = new DateTime(anoNasc, mesNasc, diaNasc);

            cl = cc.ProcurarCadastro(cl);

            return cl;
        }
        
        public Cliente ProcurarCadastro(Cliente cl)
        {
            Registro_de_Clientes rc = Registro_de_Clientes.GetInstancia();
            if(rc.clientes.Count != 0)
            {
                for (int i = 0; i < rc.clientes.Count; i++)
                {
                    if(rc.clientes[i].nome == cl.nome && rc.clientes[i].dataNascimento == cl.dataNascimento )
                    {
                        cl = rc.clientes[i];
                    }
                    else
                    {
                        Controlador_de_Clientes cc = Controlador_de_Clientes.GetInstancia();
                        cl = cc.Cadastrar(cl);
                    }
                }
            }
            else
            {
                Controlador_de_Clientes cc = Controlador_de_Clientes.GetInstancia();
                cl = cc.Cadastrar(cl);
            }
            

            
            return cl;
        }

        public Cliente Cadastrar(Cliente cl)
        {
           Console.WriteLine("\n\n#### Cadastramento ####");
           Console.WriteLine("Nome: " + cl.nome);
           Console.WriteLine("Data de nascimento: " + cl.dataNascimento.ToString("d"));
           Console.Write("RG: ");
           cl.rg = int.Parse(Console.ReadLine());
           Console.Write("Telefone: ");
           cl.telefone = Console.ReadLine();
           Console.WriteLine("\n##### Endereço #####");
           Console.Write("Rua: ");
           cl.endereco.rua = Console.ReadLine();
           Console.Write("Bairro: ");
           cl.endereco.bairro= Console.ReadLine();
           Console.Write("Cidade: ");
           cl.endereco.cidade = Console.ReadLine();
           Console.Write("Estado: ");
           cl.endereco.estado = Console.ReadLine();

            Controlador_de_Clientes cc = Controlador_de_Clientes.GetInstancia();
            cc.RegistrarCadastro(cl);
            
           return cl;
        }
       
       public void RegistrarCadastro(Cliente cl)
       {
           Registro_de_Clientes rc = Registro_de_Clientes.GetInstancia();
           rc.clientes.Add(cl);
           Console.WriteLine("\nCadastro registrado com sucesso!\n");
       }
    }

}