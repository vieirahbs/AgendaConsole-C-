using AgendaConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole.Telas
{
    class TelaMeusDados
    {
        public static void MostrarTelaMeusDados(Usuario usuario)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("********************************************");
            Console.WriteLine("******* AGENDA CONSOLE - MEUS DADOS ********");
            Console.WriteLine("********************************************");
            Console.WriteLine();
            Console.WriteLine("MEUS DADOS");
            Console.WriteLine();
            Console.WriteLine($"Id: {usuario.Id}");
            Console.WriteLine($"Nome: {usuario.Nome}");
            Console.WriteLine($"Login: {usuario.Login}");
            Console.WriteLine();
            Console.WriteLine("Menu");
            Console.WriteLine("(1)Editar nome: ");
            Console.WriteLine("(2)Alterar senha: ");
            Console.WriteLine("(3)Excluir minha conta: ");
            Console.WriteLine("(4)Voltar à tela principal: ");
            Console.WriteLine();
            Console.Write("Qual das opções deseja realizar: ");
            
            string resposta = Console.ReadLine();
            if (resposta == "1")
            {
                TelaEditarNome.MostrarTelaEditarNome(usuario);
            }
            else if (resposta == "2")
            {
                TelaAlterarSenha.MostrarTelaAlterarSenha(usuario);
            }
            else if (resposta == "3")
            {
                TelaExcluirConta.MostrarTelaExcluirConta(usuario);
            }
            else if (resposta == "4")
            {
                TelaPrincipal.MostraTelaPrincipal(usuario);
            }
            else
            {
                MostrarTelaMeusDados(usuario);
            }



        }
    }
}
