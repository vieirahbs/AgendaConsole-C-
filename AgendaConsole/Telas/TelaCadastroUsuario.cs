using System;
using AgendaConsole.Entities;

namespace AgendaConsole.Telas
{
    class TelaCadastroUsuario
    {
        public static void MostraTelaCadastroUsuario()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("********************************************");
            Console.WriteLine("**** AGENDA CONSOLE - CADASTRAR USUÁRIO ****");
            Console.WriteLine("********************************************");
            Console.WriteLine("Se quiser voltar, deixe os campos vazios e pressione Enter.");
            Console.WriteLine();

            Console.Write("Informe seu nome: ");
            string nome = Console.ReadLine().Trim();
            Console.Write("Crie um login: ");
            string login = Console.ReadLine().Trim();
            Console.Write("Crie uma senha: ");
            string senha = Console.ReadLine().Trim();
            if (nome == "" || login == "" || senha == "")
            {
                TelaInicial.MostraTelaInicial();
            }
            Console.WriteLine();
            Console.Write("(1)Confirmar cadastro? - (2)Não, voltar para a tela inicial: ");
            string resposta = Console.ReadLine();

            if (resposta == "1")
            {
                bool retorno = Usuario.CriarCadastro(nome, login, senha);
                if (retorno)
                {
                    Console.WriteLine("Usuário cadastrado com sucesso!");
                    Console.WriteLine();
                    Console.Write("Pressione Enter para voltar a tela incial: ");
                    string enter = Console.ReadLine();

                    if (enter == "")
                    {
                        TelaInicial.MostraTelaInicial();
                    }
                    else
                    {
                        TelaInicial.MostraTelaInicial();
                    }

                }
                else
                {
                    Console.WriteLine("Houve uma falha no cadastro");
                    Console.WriteLine();
                    Console.Write("Pressione Enter para voltar a tela incial: ");
                    string enter = Console.ReadLine();

                    if (enter == "")
                    {
                        TelaInicial.MostraTelaInicial();
                    }
                    else
                    {
                        TelaInicial.MostraTelaInicial();
                    }
                }
            }
            else
            {
                TelaInicial.MostraTelaInicial();
            }

        }
    }
}
