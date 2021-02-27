using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas; //Conjunto que guarda todas as peças da partida 
        private HashSet<Peca> capturadas;//Conjunto que guarda todas as peças capturadas 

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();//Instanciando conjuntos
            capturadas = new HashSet<Peca>();
            colocarPecas();//Método auxiliar
        }

        public void executaMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = tab.retirarPeca(origem);//retira a peça da posição de origem
            p.incrementarQteMovimentos();//Aciona método que conta o movimento
            Peca pecaCapturada = tab.retirarPeca(destino);//Retira peça que está alocada na posição que se deseja andar, se houver alguma
            tab.colocarPeca(p, destino);//Coloca a peça deseja na posição destino 

            if(pecaCapturada != null)//Se tinha realmente uma peca na posição de destino 
            {
                capturadas.Add(pecaCapturada);//É inserida no conjunto das peças capturadas 
            }
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


        public HashSet<Peca> pecasCapturadas(Cor cor)//Retorna peças capturadas e guardadas no conjunto 
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)//Para cada peça x no conjunto capturadas...
            {
                if(x.cor == cor)//...se a cor da peça do conjunto for igual a do parâmetro... 
                {
                    aux.Add(x);//...ela sera adicionada no conjunto aux
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)//Retorna o conjunto de peças que ainda está em jogo 
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in pecas)//Para cada peça x no conjunto pecas
            {
                if(x.cor == cor)//...se a cor da peça do conjunto for igual a do parâmetro...
                {
                    aux.Add(x);//...ela será adicionada no conjunto aux 
                }
            }
            //pega as peças da cor, EXCETO as que já foram capturadas 
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        //Metodo que coloca no tabuleiro da partida uma peça, levando como parametro coluna, linha e a peça 
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);//Adiciona no conjunto de peças da partida essa peça em questão(faz parte da partida)
        }

        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));

        }

    }
}
