using AgendaConsole.Entities;
using System;
using System.Collections.Generic;

namespace AgendaConsole.Telas
{
    class TelaEditarContato
    {
        public static void MostraTelaEditarContato(Usuario usuario)
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
                    Console.WriteLine("***** AGENDA CONSOLE - EDITAR CONTATO ******");
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
                    Console.Write(nomeVect[0] + ", informe o Id do contato que deseja editar: ");
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
                        Console.WriteLine("Se quiser cancelar a edição, deixe os campos vazios e pressione Enter.");
                        erro = false;
                        Console.WriteLine($"Edite o contato: {contatoDB.Nome} - {contatoDB.Telefone}");
                        Console.WriteLine();
                        Console.WriteLine("Informe os novos dados: ");
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Telefone: ");
                        string telefone = Console.ReadLine();
                        if (nome == "" || telefone == "")
                        {
                            MostraTelaEditarContato(usuario);
                        }
                            Console.WriteLine();
                        bool retorno = Contato.EditarContato(id, nome, telefone);

                        if (retorno)
                        {
                            Console.WriteLine("Contato atualizado com sucesso!");
                            Console.WriteLine();
                            Console.Write("Deseja editar outro contato? (1)Sim - (2)Não: ");
                            string resposta = Console.ReadLine();

                            if (resposta == "1")
                            {
                                MostraTelaEditarContato(usuario);
                            }
                            else
                            {
                                TelaPrincipal.MostraTelaPrincipal(usuario);
                            }

                        }
                        else
                        {
                            Console.WriteLine("Erro! Não foi possível atualizar o contato.");
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
