using AgendaConsole.Entities;
using System;
using System.Collections.Generic;

namespace AgendaConsole.Telas
{
    class TelaDeletarContato
    {
        public static void MostraTelaDeletarContato(Usuario usuario)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            bool erro = false;
            do
            {
                try
                {
                    string[] nomeVect = usuario.Nome.Split(' ');
                    Console.Clear();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("***** AGENDA CONSOLE - DELETAR CONTATO *****");
                    Console.WriteLine("********************************************");
                    Console.WriteLine();

                    List<Contato> contatos = Contato.RecuperaListaContato(usuario.Id);

                    Console.WriteLine("SEUS CONTATOS:");
                    foreach (Contato contato in contatos)
                    {
                        Console.WriteLine($"- Id: {contato.Id} - {contato.Nome} - {contato.Telefone}");
                    }
                    Console.WriteLine("(0)Para voltar a tela principal");
                    Console.WriteLine();
                    if (erro == true)
                    {
                        Console.WriteLine("Id não localizado!");
                    }
                    
                    Console.WriteLine();
                    Console.Write(nomeVect[0] + ", informe o Id do contato que deseja deletar: ");
                    int id = int.Parse(Console.ReadLine());
                    if (id == 0)
                    {
                        TelaPrincipal.MostraTelaPrincipal(usuario);
                    }
                    Console.WriteLine();
                    Contato contatoDB = Contato.RecuperaContato(id);

                    if (contatoDB.Nome == null)
                    {
                        erro = true;
                    }
                    else
                    {
                        erro = false;
                        Console.WriteLine($"Tem certeza que deseja deletar o contato: Id: {contatoDB.Id} - {contatoDB.Nome}?");
                        Console.Write("(1)Sim - (2)Não: ");
                        string resposta = Console.ReadLine();

                        if (resposta == "1")
                        {
                            bool retorno = Contato.DeletarContato(id);

                            Console.WriteLine("Contato deletado com sucesso!");
                            Console.WriteLine();
                            Console.Write("Deseja deletar outro contato? (1)Sim - (2)Não: ");
                            resposta = Console.ReadLine();

                            if (resposta == "1")
                            {
                                MostraTelaDeletarContato(usuario);
                            }
                            else
                            {
                                TelaPrincipal.MostraTelaPrincipal(usuario);
                            }
                        }
                        else
                        {
                            TelaPrincipal.MostraTelaPrincipal(usuario);
                        }
                    }
                }
                catch (Exception)
                {
                    erro = true;
                }
            } while (erro == true);  
        }
    }
}
