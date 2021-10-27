namespace SistemaParaCadastro
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public override void PagarImposto(float Salario)
        {

        }
        public bool validarCnpj(string cnpj)
        {
            if (cnpj.Substring(8, 4) == "0001")
            {
                return true;
            }
            else if (cnpj.Substring(8, 4) == "0002")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}