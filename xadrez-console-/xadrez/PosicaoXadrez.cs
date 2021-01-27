using System;
using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez//Essa classe auxilia ao pensamento de como funciona o posicionamento no xadrez, que é diferente da matriz do C#
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosicao()//converte uma posição do xadrez para uma interna de matriz
        {
            return new Posicao(8 - linha, coluna - 'a');
                /* se for por exemplo a linha posiçao 3 no tabuleio, na matriz se faz 8 - 3, que resulta na mesma posicao*/
        }

        public override string ToString()
        {
            return "" + coluna + linha;//As aspas forçam a conversão para string
        }

    }
}
