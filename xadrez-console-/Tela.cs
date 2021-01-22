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
                for(int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.peca(i, j) + "");
                    }
                    
                }
                Console.WriteLine();
            }

        }
    }
}
