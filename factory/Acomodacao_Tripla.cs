namespace factory
{
    public class Acomodacao_Tripla : IAcomodacao
    {
        public int acomodacaoID { get; set; }
        public string tipo { get;}
        public bool disponibilidade { get; set; }

        public Acomodacao_Tripla()
        {
            tipo = "Tripla";
            disponibilidade = true;
        }
    }
}