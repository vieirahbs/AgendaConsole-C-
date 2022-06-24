using System;
using System.Collections.Generic;
using AgendaConsole.Entities;

namespace AgendaConsole.Telas
{
    class TelaPrincipal
    {
        public static void MostraTelaPrincipal(Usuario usuario)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            string[] nomeVect = usuario.Nome.Split(" ");
            Console.Clear();
            Console.WriteLine("********************************************");
            Console.WriteLine("************* AGENDA CONSOLE ***************");
            Console.WriteLine("********************************************");
            Console.WriteLine("Olá, " + nomeVect[0] + "!");

            Console.WriteLine();

            Console.WriteLine("Menu");
            Console.WriteLine("(1) Novo contato");
            Console.WriteLine("(2) Editar contatos");
            Console.WriteLine("(3) Deletar contatos");
            Console.WriteLine("(4) Meus dados");
            Console.WriteLine("(5) Sair");

            Console.WriteLine();            

            List<Contato> contatos = Contato.RecuperaListaContato(usuario.Id);

            if (contatos.Count == 0)
            {
                Console.WriteLine("Você ainda não possui contatos.");
            }
            else
            {
                Console.WriteLine("SEUS CONTATOS:");
                foreach (Contato contato in contatos)
                {
                    Console.WriteLine($"- {contato.Nome} - {contato.Telefone}");
                }
            }
            Console.WriteLine();
            Console.Write("Selecione a opção que deseja realizar: ");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                TelaCadastroContato.MostraTelaCadastroContato(usuario);
            }
            else if (opcao == 2)
            {
                TelaEditarContato.MostraTelaEditarContato(usuario);
            }
            else if (opcao == 3)
            {
                TelaDeletarContato.MostraTelaDeletarContato(usuario);
            }
            else if (opcao == 4)
            {
                TelaMeusDados.MostrarTelaMeusDados(usuario);
            }
            else if (opcao == 5)
            {
                TelaInicial.MostraTelaInicial();
            }
        }    
    }
}
