using System;
using AgendaConsole.Entities;

namespace AgendaConsole.Telas
{
    class TelaCadastroContato
    {
        public static void MostraTelaCadastroContato(Usuario usuario)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            string[] nomeVect = usuario.Nome.Split(' ');
            Console.Clear();
            Console.WriteLine("********************************************");
            Console.WriteLine("**** AGENDA CONSOLE - CADASTRAR CONTATO ****");
            Console.WriteLine("********************************************");
            Console.WriteLine();

            Console.WriteLine(nomeVect[0] + ", informe os dados do novo contato:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            if (nome == "" || telefone == "")
            {
                MostraTelaCadastroContato(usuario);
            }
            
            bool retorno = Contato.AdicionarContato(usuario.Id, nome, telefone);

            Console.WriteLine();
            if (retorno)
            {
                Console.WriteLine("Contato adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro! Contato não adicionado");
            }

            Console.WriteLine();
            Console.Write("Deseja adicionar outro contato? (1)Sim - (2)Não: ");
            string resposta = Console.ReadLine();

            if (resposta == "1")
            {
                MostraTelaCadastroContato(usuario);
            }
            else
            {
                TelaPrincipal.MostraTelaPrincipal(usuario);
            }

        }
    }
}
