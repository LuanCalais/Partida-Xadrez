using System;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca //A classe Rei Herda da Classe Peca
    {

        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)//Repassa o tabuleiro e a cor para o construtor da SuperClasse Peca
        {
        } 

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);//Pega a peça nessa posição 
            return p == null || p.cor != cor;// ela é nula, sem peça, ou possui peça adversária
        }

        public override bool[,] movimentosPossiveis() 
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);//uma linha a menos e a mesma coluna 
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //nordeste
            pos.definirValores(posicao.linha -1, posicao.coluna +1);//uma linha a menos e uma coluna a mais 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Direita
            pos.definirValores(posicao.linha, posicao.coluna +1);//Mesma linha e uma coluna a mais
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //sudeste
            pos.definirValores(posicao.linha +1, posicao.coluna +1);//uma linha a mais e uma coluna a mais 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //abaixo
            pos.definirValores(posicao.linha +1, posicao.coluna);//Uma linha a mais e a mesma coluna 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //sudoeste
            pos.definirValores(posicao.linha +1, posicao.coluna -1);//Mais uma linha e menos uma coluna 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna -1);//Mesma linha e menos uma coluna
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //noroeste
            pos.definirValores(posicao.linha -1, posicao.coluna -1);//Uma linha a mais e a mesma coluna 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;

        }

    }
}
