namespace factory
{
    public class Acomodacao_Simples : IAcomodacao
    {
        public int acomodacaoID { get; set; }
        public string tipo { get;}
        public bool disponibilidade { get; set; }

        public Acomodacao_Simples()
        {
            tipo = "Simples";
            disponibilidade = true;
        }
    }
}