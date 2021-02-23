using System;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {

        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);//Pega a peça nessa posição 
            return p == null || p.cor != cor;// ela é sem peça, ou possui peça adversária
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while(tab.posicaoValida(pos) && podeMover(pos))//enquanto existir casa livre ou peça adversária
            {
                mat[pos.linha, pos.coluna] = true;//pode mover pra lá 
                if(tab.peca(pos) != null && tab.peca(pos).cor != this.cor)//a torre deve parar se houver uma peça adversária
                {
                    break;
                }
                pos.linha = pos.linha - 1;//Continua verificando acima 
            }



            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))//enquanto existir casa livre ou peça adversária
            {
                mat[pos.linha, pos.coluna] = true;//pode mover pra lá 
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)//a torre deve parar se houver uma peça adversária
                {
                    break;
                }
                pos.linha = pos.linha + 1;//Continua verificando abaixo 
            }



            //direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))//enquanto existir casa livre ou peça adversária
            {
                mat[pos.linha, pos.coluna] = true;//pode mover pra lá 
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)//a torre deve parar se houver uma peça adversária
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;//Continua verificando direita
            }



            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))//enquanto existir casa livre ou peça adversária
            {
                mat[pos.linha, pos.coluna] = true;//pode mover pra lá 
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)//a torre deve parar se houver uma peça adversária
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;//Continua verificando esquerda
            }


            return mat;

        }


    }
}
