using AgendaConsole.Entities;
using System;

namespace AgendaConsole.Telas
{
    class TelaAlterarSenha
    {
        public static void MostrarTelaAlterarSenha(Usuario usuario)
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
                    Console.WriteLine("***** AGENDA CONSOLE - ALTERAR SENHA *******");
                    Console.WriteLine("********************************************");
                    Console.WriteLine("Se quiser cancelar a edição, deixe os campos vazios e pressione Enter.");
                    Console.WriteLine();
                    if (erro == true)
                    {
                        Console.WriteLine("Senha atual incorreta!");
                        erro = false;
                    }
                    Console.WriteLine();
                    Console.Write($"Informe sua senha atual: ");
                    string senhaAtual = Console.ReadLine();
                    Console.Write($"Informe sua nova senha: ");
                    string senhaNova = Console.ReadLine();
                    if (senhaAtual == "" || senhaNova == "")
                    {
                        TelaMeusDados.MostrarTelaMeusDados(usuario);
                    }
                    else
                    {
                        Usuario retorno = Usuario.ValidarUsuario(usuario.Login, senhaAtual);

                        if (retorno.Nome != null)
                        {
                            bool novaSenhaValidada = Usuario.AlterarSenha(usuario.Id, senhaNova);

                            if (novaSenhaValidada)
                            {
                                Console.WriteLine("Senha atualizada com sucesso!");
                                Console.Write("(1)Voltar para Meus Dados - (2)Atualizar senha novamente: ");
                                string resposta = Console.ReadLine();
                                if (resposta == "2")
                                {
                                    MostrarTelaAlterarSenha(retorno);
                                }
                                else
                                {
                                    TelaMeusDados.MostrarTelaMeusDados(retorno);
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
