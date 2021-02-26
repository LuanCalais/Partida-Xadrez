using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();//Método auxiliar
        }

        public void executaMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = tab.retirarPeca(origem);//retira a peça da posição de origem
            p.incrementarQteMovimentos();//Aciona método que conta o movimento
            Peca pecaCapturada = tab.retirarPeca(destino);//Retira peça que está alocada na posição que se deseja andar, se houver alguma
            tab.colocarPeca(p, destino);//Coloca a peça deseja na posição destino 
        }

        public void realizaJogada(Posicao origem, Posicao destino)//Método de mais alto nível
        {
            executaMovimento(origem, destino);//Executa o movimento da peça
            turno++;//Passa o turno 
            mudaJogador();
        } 

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)//não tem peça
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if(jogadorAtual != tab.peca(pos).cor)//Só pode escolher uma peça da cor do jogador atual
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if(!tab.peca(pos).existeMovimentosPossiveis())//A peça está bloqueada
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (tab.peca(origem).podeMoverPara(destino) == false)
            {
                throw new TabuleiroException("Posição de destino inválida inválida!"); 
            }
        }

        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());


            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());

        }

    }
}
