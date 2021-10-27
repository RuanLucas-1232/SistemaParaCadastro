using System;

namespace SistemaParaCadastro
{
    public class PessoaFisica : Pessoa
    {
        public string cpf { get; set; }
        public DateTime dataNascimento { get; set; }
        public bool ValidarDataNascimento(DateTime DataNascimento)
        {
            DateTime DataAtual = DateTime.Today;
            double idade = (DataAtual - DataNascimento).TotalDays / 365;
            if (idade >= 18)
            {
                return true;
            }
            return false;
        }
        public override void PagarImposto(float Salario)
        {
            
        }
    }
}