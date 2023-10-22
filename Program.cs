using System.Xml.Linq;

namespace Desafio_I
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //JOGO DA VELHA
            menu();    
        }
        
        static void menu()
        {
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("|       #JOGO DA VELHA#        |");
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| 1 - Player vs Player         |");
            Console.WriteLine("| 2 - Player vs Máquina        |");
            Console.WriteLine("+------------------------------+");
            Console.Write("| SELECIONE UMA OPÇÃO: ");
            string escolha = Console.ReadLine();
            string[,] matriz = new string[3, 3];
            
            Console.WriteLine("+------------------------------+");

            switch (escolha)
            {
                case "1":
                    PlayerVsPlayer(matriz);
                    break;
                case "2":
                    PlayerVsMaquina(matriz);
                    break;
                default:
                    Console.WriteLine("Nenhuma opção escolhida!");
                    break;
            }
        }

        static string nomeJogador()
        {
            Console.Write("| Digite seu nome: ");
            return Console.ReadLine();
        }
        static void PlayerVsPlayer(string[,] matriz)
        {
            Console.Clear();
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("|       PLAYER VS. PLAYER      |");
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| PLAYER 1 = X                 |");
            Console.WriteLine("| PLAYER 2 = O                 |");
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| PLAYER 1                     |");
            string player1 = nomeJogador();
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| PLAYER 2 ");
            string player2 = nomeJogador();
            Console.WriteLine("+------------------------------+");
            Console.Clear();
            int sorteio = sorteioJogador();
            int linha, coluna;
            string elemento;
            Console.Clear();
            bool venceu = false;
            
            do
            {
                if (sorteio == 0)
                {
                    Console.WriteLine("Vez de "+player1);
                    Console.WriteLine("X");
                    elemento = "X";
                    Console.Write("Linha ");
                    linha = posicao();
                    Console.Write("Coluna ");
                    coluna = posicao();
                    sorteio = 1;
                    //tabuleiro(matriz);
                
                }
                else
                {
                    Console.WriteLine("Vez de " + player2);
                    Console.WriteLine("O");
                    elemento = "O";
                    Console.Write("Linha ");
                    linha = posicao();
                    Console.Write("Coluna ");
                    coluna = posicao();
                    sorteio = 0;
                    //tabuleiro(matriz);
                }
                escolherPosicao(matriz, linha, coluna, elemento);
                tabuleiro(matriz);
            } while (!venceu);
        }
        static void tabuleiro(string[,] matriz)
        {
            Console.WriteLine("");
            Console.WriteLine(" "+matriz[0, 0] + " | " + matriz[0, 1] + " | " + matriz[0, 2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" "+matriz[1, 0] + " | " + matriz[1, 1] + " | " + matriz[1, 2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + matriz[2, 0] + " | " + matriz[2, 1] + " | " + matriz[2, 2]);
            Console.WriteLine("");

        }
        static int sorteioJogador()
        {
            Console.WriteLine("Sorteando...");
            return new Random().Next(0, 2);
        }
        static int posicao()
        {
            int x;
            do
            {
                Console.Write(" jogada: ");
                x = int.Parse(Console.ReadLine());
            } while (x < 1 || x > 3);

            return x;
        }
        static void PlayerVsMaquina(string[,] matriz)
        {
            //ppontuacao maquina, pontuacao jogador
            Console.Clear();
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("|      PLAYER VS. MÁQUINA      |");
            Console.WriteLine("+------------------------------+");
        }
        static void posicaoPreenchida(string[,] matriz)
        {

        }
        /*
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
        */
        /*
        static void montarTabuleiro(string[,] matriz)
        {
            Console.WriteLine("");
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
        */

        static void escolherPosicao(string[,] matriz, int linha, int coluna, string elemento)
        {
            Console.WriteLine("");
            linha--;
            coluna--;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] != null)
                    {
                        Console.WriteLine(" posição já preenchida   ");
                        break;
                    }
                    else
                    {
                        matriz[linha, coluna] = elemento;
                    }

                }
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