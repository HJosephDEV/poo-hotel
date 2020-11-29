using System;

namespace entidades
{
    public class Cliente
    {
        public string nome { get; set;}
        public int rg { get; set; }
        public DateTime dataNascimento { get; set; }
        public string telefone{ get; set; }
        public Endereco endereco { get; set; }

        public Cliente()
        {
            endereco = new Endereco();
        }
    }
}