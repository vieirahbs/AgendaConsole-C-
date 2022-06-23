using AgendaConsole.Entities;
using System;

namespace AgendaConsole.Telas
{
    class TelaEditarNome
    {
        public static void MostrarTelaEditarNome(Usuario usuario)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            bool erro = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("****** AGENDA CONSOLE - EDITAR NOME ********");
                    Console.WriteLine("********************************************");
                    Console.WriteLine("Se quiser cancelar a edição, deixe o campo vazio e pressione Enter.");
                    Console.WriteLine();
                    Console.WriteLine($"Nome atual: {usuario.Nome}");
                    Console.Write("Novo nome: ");
                    string nome = Console.ReadLine();
                    if (nome == "")
                    {
                        TelaMeusDados.MostrarTelaMeusDados(usuario);
                    }
                    else
                    {
                        Usuario retorno = Usuario.AtualizarNome(usuario.Id, nome);

                        if (retorno.Nome != null)
                        {
                            Console.WriteLine("Nome atualizado com sucesso!");
                            Console.Write("(1)Voltar para Meus Dados - (2)Editar nome novamente: ");
                            string resposta = Console.ReadLine();
                            if (resposta == "2")
                            {
                                MostrarTelaEditarNome(retorno);
                            }
                            else
                            {
                                TelaMeusDados.MostrarTelaMeusDados(retorno);
                            }
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
