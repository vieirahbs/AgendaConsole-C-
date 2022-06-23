using System;


namespace AgendaConsole.Telas
{
    static class TelaInicial
    {
        public static void MostraTelaInicial()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            bool error = false;
            do
            {
                try
                {                    
                    Console.Clear();                    
                    Console.WriteLine("********************************************");
                    Console.WriteLine("****** BEM VINDO(A) A AGENDA CONSOLE *******");
                    Console.WriteLine("********************************************");
                    if (error == true)
                    {
                        Console.WriteLine("Opção invalida! Selecione uma das opções abaixo!");
                        error = false;
                    }
                    Console.Write("Digite (1) Para fazer login ou (2) Para se cadastrar: ");
                    int opcao = int.Parse(Console.ReadLine());

                    if (opcao == 1)
                    {
                        TelaLogin.MostraTelaLogin();
                    }
                    else if (opcao == 2)
                    {
                        TelaCadastroUsuario.MostraTelaCadastroUsuario();
                    }
                    else if (opcao.ToString() == "")
                    {
                        MostraTelaInicial();
                    }
                    else
                    {
                        MostraTelaInicial();
                    }
                }
                catch (Exception)
                {
                    error = true;
                }
            } while (error == true);
        }
    }
}

