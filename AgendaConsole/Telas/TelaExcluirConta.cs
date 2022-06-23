using AgendaConsole.Entities;
using System;

namespace AgendaConsole.Telas
{
    class TelaExcluirConta
    {
        public static void MostrarTelaExcluirConta(Usuario usuario)
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
                    Console.WriteLine("***** AGENDA CONSOLE - EXCLUIR CONTA *******");
                    Console.WriteLine("********************************************");
                    Console.WriteLine();
                    if (erro == true)
                    {
                        Console.WriteLine("Senha atual incorreta!");
                        erro = false;
                    }
                    Console.WriteLine();
                    Console.Write($"Informe sua senha para confirmar a exclusão da conta ou pressione Enter para voltar: ");
                    string senha = Console.ReadLine();
                    if (senha == "")
                    {
                        TelaMeusDados.MostrarTelaMeusDados(usuario);
                    }
                    else
                    {
                        Usuario retorno = Usuario.ValidarUsuario(usuario.Login, senha);

                        if (retorno.Nome != null)
                        {
                            bool exclusaoConfirmada = Usuario.ExcluirConta(usuario.Id);

                            if (exclusaoConfirmada)
                            {
                                Console.WriteLine("Sua conta foi excluida com sucesso.");
                                Console.Write("Pressione Enter para sair: ");
                                string resposta = Console.ReadLine();
                                if (resposta == "")
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
                            erro = true;
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
