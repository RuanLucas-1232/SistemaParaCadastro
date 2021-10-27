namespace SistemaParaCadastro
{
    public abstract class Pessoa
    {
        public string nome { get; set; }
        public Endereco Localizacao { get; set; }
        public abstract void PagarImposto(float Salario);
    }
}