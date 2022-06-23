using System;
using AgendaConsole.Entities;

namespace AgendaConsole.Telas
{
    class TelaLogin
    {
        public static void MostraTelaLogin()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            bool usuarioValido = true;

            do
            {
                Console.Clear();
                if (usuarioValido == false)
                {
                    Console.WriteLine("Usuário inválido!");
                    usuarioValido = true;
                }
                Console.WriteLine("********************************************");
                Console.WriteLine("********* AGENDA CONSOLE - LOGIN ***********");
                Console.WriteLine("********************************************");
                Console.WriteLine("Se quiser voltar, deixe os campos vazios e pressione Enter.");
                Console.Write("Login: ");
                string login = Console.ReadLine().Trim();                
                Console.Write("Senha: ");
                string senha = Console.ReadLine().Trim();
                if (login == "" || senha == "")
                {
                    TelaInicial.MostraTelaInicial();
                }

                Usuario usuario = Usuario.ValidarUsuario(login, senha);

                if (usuario.Login != null)
                {
                    TelaPrincipal.MostraTelaPrincipal(usuario);
                }
                else
                {
                    usuarioValido = false;
                }
            } while (usuarioValido == false);
            
        }
    }
}
