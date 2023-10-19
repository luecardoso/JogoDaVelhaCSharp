namespace Desafio_I
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //JOGO DA VELHA
            //menu();
            //tabuleiro();
            matrizTabuleiro(0);

            
        }
        
        static void menu()
        {
            Console.WriteLine("##########################");
            Console.WriteLine("##### JOGO DA VELHA ######");
            Console.WriteLine("##########################");
            Console.WriteLine("# 1 - Player vs Player   #");
            Console.WriteLine("# 2 - Player vs Máquina  #");
            Console.WriteLine("##########################");
            Console.Write("SELECIONE UMA OPÇÃO: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    PlayerVsPlayer();
                    break;
                case "2":
                    PlayerVsMaquina();
                    break;
                default:
                    Console.WriteLine("Nenhuma opção escolhida!");
                    break;
            }
        }

        static string nomeJogador()
        {
            Console.Write("Digite seu nome: ");
            return Console.ReadLine();
        }
        static void PlayerVsPlayer()
        {
            Console.Clear();
            Console.WriteLine("##############################");
            Console.WriteLine("##### PLAYER VS. PLAYER ######");
            Console.WriteLine("##############################");
            Console.WriteLine("PLAYER 1 = X ");
            Console.WriteLine("PLAYER 2 = O ");
            Console.Write("PLAYER 1 ");
            string player1 = nomeJogador();
            Console.Write("PLAYER 2 ");
            string player2 = nomeJogador();
            Console.Clear();
            int sorteio = sorteioJogador();
            if (sorteio == 0)
            {
                Console.WriteLine(player1+" Começa");
            }
            else
            {
                Console.WriteLine(player2+"  Começa");
            }
        }

        static int sorteioJogador()
        {
            Console.WriteLine("Sorteando...");
            return new Random().Next(0, 2);
        }
        static void PlayerVsMaquina()
        {

        }

        static void matrizTabuleiro(int posicao)
        {
            string[,] matriz = new string[3, 3];
            montarTabuleiro();
            for (int i = 0; i< matriz.GetLength(0); i++)
            {
                for (int j =0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = " " + posicao + " ";
                    Console.Write(matriz[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        static void montarTabuleiro()
        {
            Console.WriteLine("");
            string[,] matriz = new string[3, 3];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {

                    if (j == matriz.GetLength(1) - 1)
                    {
                        break;
                    }
                    Console.Write(matriz[i, j] + "|");
                }
                if (i == matriz.GetLength(0) - 1)
                {
                    break;
                }
                Console.WriteLine("\n---+---+---");
            }
            Console.WriteLine("");
        }

        static void verificarLinha()
        {

        }
        static void verificarColuna()
        {

        }
        static void verificarDiagonalPrincipal()
        {

        }
        static void verificarDiagonalSecundaria()
        {

        }
    }
}