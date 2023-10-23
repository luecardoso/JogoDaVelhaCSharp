using System.Net.Http.Headers;
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
            int linha, coluna, pontuacaoP1 =0, pontuacaoP2 =0;
            string elemento;
            Console.Clear();
            bool venceu = false, posicaoOcupada = false, empate = false;
            string denovo = "";
            while (denovo.ToUpper() != "N")
            {
                tabuleiroInicial(matriz);
                do
                {
                    tabuleiro(matriz);
                    if (sorteio == 0)
                    {
                        do
                        {
                            Console.WriteLine("+---------------X--------------+");
                            Console.WriteLine("|     Vez de " + player1);
                            Console.WriteLine("+------------------------------+");
                            elemento = "X";
                            Console.Write("| Linha ");
                            linha = posicao();
                            Console.Write("| Coluna ");
                            coluna = posicao();

                            posicaoOcupada = verificarPosicao(matriz, linha, coluna, elemento);
                            venceu = verificarLinha(matriz, elemento);
                            if (venceu)
                            {
                                tabuleiro(matriz);
                                break;
                            }
                            empate = verificarEmpate(matriz, elemento);
                            if (empate)
                            {
                                sorteio = -1;
                                break;
                            }
                            if (posicaoOcupada)
                            {
                                sorteio = 1;
                                posicaoOcupada = false;
                            }
                            else
                            {
                                sorteio = 0;
                                posicaoOcupada = true;
                            }
                        } while (posicaoOcupada);



                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine("+---------------O--------------+");
                            Console.WriteLine("|     Vez de " + player2);
                            Console.WriteLine("+------------------------------+");
                            elemento = "O";
                            Console.Write("| Linha ");
                            linha = posicao();
                            Console.Write("| Coluna ");
                            coluna = posicao();
                            posicaoOcupada = verificarPosicao(matriz, linha, coluna, elemento);
                            venceu = verificarLinha(matriz, elemento);
                            if (venceu)
                            {
                                tabuleiro(matriz);
                                break;
                            }
                            empate = verificarEmpate(matriz, elemento);
                            if (empate)
                            {
                                sorteio = -1;
                                break;
                            }
                            if (posicaoOcupada)
                            {
                                sorteio = 0;
                                posicaoOcupada = false;
                            }
                            else
                            {

                                sorteio = 1;
                                posicaoOcupada = true;
                            }
                        } while (posicaoOcupada);

                    }
                    //escolherPosicao(matriz, linha, coluna, elemento, sorteio);
                    //
                } while (!venceu);
                if (sorteio == 0)
                {
                    pontuacaoP1++;
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("        VITÓRIA DE " + player2.ToUpper());
                    Console.WriteLine("+--------------------------------------+");
                }
                else if (sorteio == 1)
                {
                    pontuacaoP2++;
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("        VITÓRIA DE " + player2.ToUpper());
                    Console.WriteLine("+--------------------------------------+");
                }
                if (empate)
                {
                    Console.WriteLine("+------------------------------+");
                    Console.WriteLine("|            EMPATE            |");
                    Console.WriteLine("+------------------------------+");
                }
                Console.Write("| Deseja jogar novamente? S/N  ");
                denovo = Console.ReadLine();
            }
            Console.WriteLine("+-----------PLACAR-------------+");
            Console.WriteLine(player1+" = "+pontuacaoP1+"   VS "+player2+" = "+pontuacaoP2);
            Console.WriteLine("+------------------------------+");

        }
        static void tabuleiro(string[,] matriz)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" "+matriz[0, 0] + " | " + matriz[0, 1] + " | " + matriz[0, 2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" "+matriz[1, 0] + " | " + matriz[1, 1] + " | " + matriz[1, 2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + matriz[2, 0] + " | " + matriz[2, 1] + " | " + matriz[2, 2]);
            Console.WriteLine("");

        }

        static void tabuleiroInicial(string[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = null;
                }
            }
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
        
        static bool verificarEmpate(string[,] matriz, string elemento)
        {
            int pontuacao = 0;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i,j] != null)
                    {
                        
                        pontuacao++;
                        if (i == (matriz.GetLength(0) - 1) && j == (matriz.GetLength(1) - 1))
                        {
                            if (pontuacao == 9)
                            {
                                
                                return true;
                            }
                        }
                        
                        /*
                        if (verificarColuna(matriz,elemento) == false && verificarLinha(matriz, elemento) == false
                            && verificarDiagonalPrincipal(matriz, elemento) == false && 
                            verificarDiagonalSecundaria(matriz, elemento) == false)
                        {
                            return true;
                        }
                        */
                    }
                    
                }

            }
            return false;
        }
        static bool verificarPosicao(string[,] matriz, int linha, int coluna, string elemento)
        {
            linha--;
            coluna--;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[linha, coluna] == null)
                    {
                        matriz[linha, coluna] = elemento;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("+------------------------------+");
                        Console.WriteLine("|    Posição já preenchida     |");
                        return false;
                    }

                }
                
            }
            return false;
        }

        static bool verificarLinha(string[,] matriz, string elemento)
        {
            
            string caractere;
            int pontos = 0;
            bool ganhou = false;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {

                    caractere = matriz[i, j];
                    if (caractere == elemento)
                    {
                        pontos++;
                    }
                }
                if (pontos == 3)
                {
                    ganhou = true;
                    return ganhou;
                }
                else
                {
                    pontos = 0;
                }
                
            }
            return ganhou;
        }
        static bool verificarColuna(string[,] matriz, string elemento)
        {
            string caractere;
            int linha1 = 0, linha2 = 0,linha3 = 0;
            bool ganhou = false;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        caractere = matriz[i, j];
                        if (caractere == elemento)
                        {
                            linha1++;
                        }
                    }
                    if (j == 1)
                    {
                        caractere = matriz[i, j];
                        if (caractere == elemento)
                        {
                            linha2++;
                        }
                    }
                    if (j == 2)
                    {
                        caractere = matriz[i, j];
                        if (caractere == elemento)
                        {
                            linha3++;
                        }
                    }
                }
            }
            if (linha1 == 3)
            {
                ganhou = true;
                return ganhou;
            }
            if (linha2 == 3)
            {
                ganhou = true;
                return ganhou;
            }
            if (linha3 == 3)
            {
                ganhou = true;
                return ganhou;
            }
            return ganhou;
        }
        static bool verificarDiagonalPrincipal(string[,] matriz, string elemento)
        {
            string caractere;
            int pontos = 0;
            bool ganhou = false;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        caractere = matriz[i, j];
                        if (caractere == elemento)
                        {
                            pontos++;
                        }
                    }
                }
            }
            if (pontos == 3)
            {
                ganhou = true;
                return ganhou;
            }
            else
            {
                return ganhou;
            }
        }
        static bool verificarDiagonalSecundaria(string[,] matriz, string elemento)
        {
            string caractere;
            int pontos = 0;
            bool ganhou = false;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (i + j == matriz.GetLength(0) - 1)
                    {
                        caractere = matriz[i, j];
                        if (caractere == elemento)
                        {
                            pontos++;
                        }
                    }
                }
            }
            if (pontos == 3)
            {
                ganhou = true;
                return ganhou;
            }
            else
            {
                return ganhou;
            }
        }

        static void PlayerVsMaquina(string[,] matriz)
        {
            //ppontuacao maquina, pontuacao jogador
            Console.Clear();
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("|      PLAYER VS. MÁQUINA      |");
            Console.WriteLine("+------------------------------+");
        }
    }
}