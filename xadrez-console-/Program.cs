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
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)//enquanto a partida não estiver terminada 
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Digite a origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();//Pega essa posição e transforma em posição de matriz
                        partida.validarPosicaoDeOrigem(origem);

                        //Incremento para alterar a cor de fundo e mostrar as posições possíveis para o usuário
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();


                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Digite o destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }


                
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
            
        }
    }
}
