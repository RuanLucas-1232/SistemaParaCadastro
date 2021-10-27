using System;
using System.Threading;

namespace SistemaParaCadastro
{
    class Program
    {
        static void Main(string[] args)
        {
            PessoaFisica UsuarioPessoaFisica = new PessoaFisica();
            PessoaFisica ValidadorPessoaFisica = new PessoaFisica();
            Endereco localidade = new Endereco();

            PessoaJuridica UsuarioPessoaJuridica = new PessoaJuridica();
            PessoaJuridica ValidadorPessoaJuridica = new PessoaJuridica();

            char respostaUsuario;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            carregarPagina("INICIANDO");

            do
            {
                Console.WriteLine(@$"
                =================================================
                |SISTEMA DE CADASTRO DE PESSOA FÍSICA E JURÍDICA|
                |-----------------------------------------------|
                |       DIGITE 1 - PARA PESSOA FÍSICA           |
                |       DIGITE 2 - PARA PESSOA JURÍDICA         |
                |       DIGITE 0 - PARA SAIR                    |
                =================================================
                ");


                respostaUsuario = char.Parse(Console.ReadLine());

                switch (respostaUsuario)
                {
                    case '1':

                        carregarPagina("Carregando");

                        Console.WriteLine("SEU ENDEREÇO É COMERCIAL? DIGITE true PARA SIM E false PARA NÃO");
                        localidade.EnderecoComercial = bool.Parse(Console.ReadLine());

                        Console.WriteLine($"INSIRA O LOGRADOURO");
                        localidade.Logradouro = Console.ReadLine();

                        Console.WriteLine($"INSIRA O NÚMERO");
                        localidade.Numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"INSIRA O COMPLEMENTO. CASO NÃO TENHA DIGITE nenhum");
                        localidade.Complemento = Console.ReadLine();

                        UsuarioPessoaFisica.Localizacao = localidade;

                        Console.WriteLine($"INSIRA O SEU NOME");
                        UsuarioPessoaFisica.nome = Console.ReadLine();

                        Console.WriteLine($"INSIRA O DIA DE NASCIMENTO");
                        var DIA = int.Parse(Console.ReadLine());

                        Console.WriteLine($"INSIRA O MÊS DE NASCIMENTO");
                        var MES = int.Parse(Console.ReadLine());

                        Console.WriteLine($"INSIRA O ANO DE NASCIMENTO");
                        var ANO = int.Parse(Console.ReadLine());
                        UsuarioPessoaFisica.dataNascimento = new DateTime(ANO, MES, DIA);

                        Console.WriteLine($"INSIRA O SEU cpf");
                        UsuarioPessoaFisica.cpf = Console.ReadLine();

                        bool IdadeValidada = ValidadorPessoaFisica.ValidarDataNascimento(UsuarioPessoaFisica.dataNascimento);
                        if (IdadeValidada == true)
                        {
                            Console.WriteLine($"Acesso Permitido!");
                            Thread.Sleep(3000);
                            carregarPagina("REDIRECIONANDO");
                        }
                        else
                        {
                            Console.WriteLine($"Acesso Negado! Acesso Permitido Somente Para Maiores de Idade");
                            Thread.Sleep(3000);
                            carregarPagina("REDIRECIONANDO");
                        }
                        break;

                    case '2':

                        carregarPagina("Carregando");

                        Console.WriteLine("DIGITE O SEU NOME:");
                        UsuarioPessoaJuridica.nome = Console.ReadLine();

                        Console.WriteLine("DIGITE A SUA RAZÃO SOCIAL:");
                        UsuarioPessoaJuridica.RazaoSocial = Console.ReadLine();

                        Console.WriteLine("DIGITE O SEU cnpj:");
                        UsuarioPessoaJuridica.cnpj = Console.ReadLine();


                        Console.WriteLine("SEU ENDEREÇO É COMERCIAL? DIGITE true PARA SIM E false PARA NÃO");
                        localidade.EnderecoComercial = bool.Parse(Console.ReadLine());

                        Console.WriteLine("DIGITE O SEU LOGRADOURO:");
                        localidade.Logradouro = Console.ReadLine();

                        Console.WriteLine("DIGITE O SEU COMPLEMENTO. CASO NÃO TENHA DIGITE nenhum");
                        localidade.Complemento = Console.ReadLine();

                        Console.WriteLine("DIGITE O SEU NÚMERO:");
                        localidade.Numero = int.Parse(Console.ReadLine());

                        UsuarioPessoaJuridica.Localizacao = localidade;

                        bool cnpjValidado = ValidadorPessoaJuridica.validarCnpj(UsuarioPessoaJuridica.cnpj);

                        if (cnpjValidado)
                        {
                            Console.WriteLine("CADASTRO REALIZADO COM SUCESSO");
                            Thread.Sleep(3000);
                            carregarPagina("REDIRECIONANDO");
                        }
                        else
                        {
                            Console.WriteLine($"CADASTRO NEGADO! SEU cnpj NÃO POSSUI OS NÚMEROS 0001 DE UMA MATRIZ OU 0002 DE UMA FILIAL");
                            Thread.Sleep(3000);
                            carregarPagina("REDIRECIONANDO");
                        }
                        break;

                    default:

                        Console.WriteLine($"OBRIGADO POR  ACESSAR NOSSO SERVIÇO!");
                        Thread.Sleep(3000);
                        carregarPagina("REDIRECIONANDO");
                        break;
                }
            }
            while (respostaUsuario > '0' && respostaUsuario < '3');
            Console.ResetColor();
        }

        static void carregarPagina(string mensagemDeCarregamento)
        {
            Console.Clear();
            Console.Write(mensagemDeCarregamento);
            for (int vez = 0; vez < 10; vez++)
            {
                Console.Write('.');

                Thread.Sleep(300);

                if (vez == 9)
                {
                    Console.Clear();
                }
            }

        }
    }
}