namespace factory
{
    public class Acomodacao_Dupla : IAcomodacao
    {
        public int acomodacaoID { get; set; }
        public string tipo { get;}
        public bool disponibilidade { get; set; }

        public Acomodacao_Dupla()
        {
            tipo = "Dupla";
            disponibilidade = true;
        }
    }
}