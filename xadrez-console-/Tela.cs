using System;
using tabuleiro;
using xadrez;

namespace xadrez_console_
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)//Void não retorna valor, e static pois independe de variável de instância 
        {
            for(int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " "); //a cada loop ele vai subtraindo 
                for (int j = 0; j < tab.colunas; j++)
                {
                        imprimirPeca(tab.peca(i, j));
                } 
                Console.WriteLine(); //quebra de linha
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)//Sobrecarga para marcar possíveis posições 
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " "); 
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[1, j])// se a posição estiver marcada como possível altera a cor do fundo
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else// se não, mantem o origial
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;// Para garantir que volte ao fundo original 
        }

        public static PosicaoXadrez lerPosicaoXadrez()//Lê o que o usuário digitou no teclado 
        {
            string s = Console.ReadLine();//lê a entrada em um string 
            char coluna = s[0];//pega a letra da posição desejada
            int linha = int.Parse(s[1] + "");//pega o número referente a coluna, INT.PARSE CONVERTE
            return new PosicaoXadrez(coluna, linha);
        }


        public static void imprimirPeca(Peca peca)
        {

            if (peca == null)//se não tiver peça 
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor; // recebe a cor original de fundo e armazena na variavel aux
                    Console.ForegroundColor = ConsoleColor.Yellow; // transforma a cor padrão em Amarelo
                    Console.Write(peca);//imprime com peça com a nova cor
                    Console.ForegroundColor = aux;// volta a cor original usando a informação armazenada em "aux"
                }
                Console.Write(" ");
            }
        }

    }
}
