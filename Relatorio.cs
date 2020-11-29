using System;
using registros;
using controladores;

public class Relatorio
{
    public Registro_de_Gastos rg;
    public Controlador_de_Gastos cg;
    public void GerarRealatorioDiario()
    {
       Relatorio rl = new Relatorio();
       cg = Controlador_de_Gastos.GetInstancia();
       cg.CalcularGastosDiarios();
       DateTime data = rl.definirData();
       rl.BuscarGastos(data);
    }

    public DateTime definirData()
    {
        Console.WriteLine("\n\n#### Informe a data ####");
        Console.Write("Dia: ");
        int dia = int.Parse(Console.ReadLine());
         Console.Write("Mês: ");
        int mes = int.Parse(Console.ReadLine());
         Console.Write("Ano: ");
        int ano = int.Parse(Console.ReadLine());
        DateTime data = new DateTime(ano, mes, dia);

        return data;
    }



    public void BuscarGastos(DateTime data)
    {
        rg = Registro_de_Gastos.GetInstancia();
        Console.WriteLine("\n\n#### Relatório ####");
        for (int i = 0; i < rg.gastos.Count; i++)
        {
            if(rg.gastos[i].dataGasto == data)
            {
                Console.WriteLine("Reserva " + rg.gastos[i].reserva.reservaID + " - Diária: R$" +rg.gastos[i].gastoDiaria
                                + " - Alimentacão: R$" + rg.gastos[i].gastoAlimentacao + " - Telefone: R$" + rg.gastos[i].gastoTelefone
                                + " - Total: R$" + rg.gastos[i].gastoTotal);
            }
        }
    }
}