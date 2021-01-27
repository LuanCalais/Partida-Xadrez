using System;
using tabuleiro;
using xadrez;

namespace xadrez_console_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(-1, 9));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));

                Tela.ImprimirTabuleiro(tab);
                
            }catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);//imprime a mensagem de erro já definida
            }
            Console.ReadLine();
        }
    }
}
