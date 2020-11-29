using registros;
using entidades;
using System;
namespace controladores
{   
    public class Controlador_de_Gastos
    {
        private static Controlador_de_Gastos instancia;
        public Registro_de_Gastos rgs;
        public Controlador_de_Servicos cs;
        public Controlador_de_Reservas cr;
        public double precoAlimentacao;
        public double precoTelefone;
        public double precoDiaria;
        public double precoSimples;
        public double precoDupla;
        public double precoTripla;
        public double total;


         private Controlador_de_Gastos(){
             precoAlimentacao = 45.50;
             precoTelefone = 36.20;
             precoSimples = 69.90;
             precoDupla = 99.90;
             precoTripla = 124.99;
             precoDiaria = 0;
             total = 0;
         }

        public static Controlador_de_Gastos GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Controlador_de_Gastos();

            }
            return instancia;
        }

        public void CalcularGastosDiarios()
        {
            cs = Controlador_de_Servicos.GetInstancia();
            cs.rs = Registro_de_Servicos.GetInstancia();

            Gastos gastos = new Gastos();
            for (int i = 0; i < cs.rs.servicos.Count; i++)
            {
                Controlador_de_Gastos cg = Controlador_de_Gastos.GetInstancia();
                gastos.reserva = cs.rs.servicos[i].reserva;
                gastos.dataGasto = cs.rs.servicos[i].dataServico;
                gastos.gastoDiaria = cg.CalculaDiaria(gastos.reserva.acomodacao.tipo);
                if(cs.rs.servicos[i].pediuAlimentacao == true)
                {
                    gastos.gastoAlimentacao = precoAlimentacao;
                }
                else if(cs.rs.servicos[i].pediuTelefone == true)
                {
                    gastos.gastoTelefone = precoTelefone;
                }
                gastos.gastoTotal = gastos.gastoAlimentacao + gastos.gastoTelefone + gastos.gastoDiaria;
                cg.RegistrarGastos(gastos);
            }
        }


        public double CalculaDiaria(string tipo)
        {
            double diaria = 0;
            switch(tipo)
            {
                case "Simples":
                    diaria = precoSimples;
                    break;
                case "Dupla":
                    diaria = precoDupla;
                    break;
                case "Tripla":
                    diaria = precoTripla;
                    break;
            }
            return diaria;
        }

        public void RegistrarGastos(Gastos gastos)
        {
            Registro_de_Gastos rg = Registro_de_Gastos.GetInstancia();
            rg.gastos.Add(gastos);
            
        }

    }
    
}