namespace Desafio_I
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //JOGO DA VELHA
            menu();
            tabuleiro();
        }

        static void tabuleiro()
        {
            Console.WriteLine("");
            Console.WriteLine("   |   |   ");
            Console.WriteLine("---+---+---");
            Console.WriteLine("   |   |   ");
            Console.WriteLine("---+---+---");
            Console.WriteLine("   |   |   ");
            Console.WriteLine("");
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
        }
    }
}