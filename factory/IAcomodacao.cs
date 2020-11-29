namespace factory
{
    public interface IAcomodacao
    {
        public int acomodacaoID { get; set; }
        public string tipo { get; }
        public bool disponibilidade { get; set; }
    }
}   