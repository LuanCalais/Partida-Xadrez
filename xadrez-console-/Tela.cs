using System;
using tabuleiro;

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
                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                    
                } 
                Console.WriteLine(); //quebra de linha
            }
            Console.WriteLine("  a b c d e f g h");
        }


        public static void imprimirPeca(Peca peca)
        {
            if(peca.cor == Cor.Branca)
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
        }

    }
}
