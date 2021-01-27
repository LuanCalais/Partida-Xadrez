namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas; //O tabuleiro possui uma matriz de peças e só o tabuleiro pode acessar por isso PRIVATE  

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];//que ela pode estar em uma das posições de linhas que colunas informadas como argumento
        }


        public Peca peca(int linha, int coluna)//Método público que pode acessar uma peça //está no singular por cuasa da classe POSICAO
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos)//Testa se já existe uma peça na posição requerida
        {
            validarPosicao(pos); 
            return peca(pos) != null;//retorna que existe uma peca ocupando essa posicao
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))//se existe uma peca nessa posicao
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p; //coloca a peça na matriz de peças 
            p.posicao = pos; //Diz que a nova posição da peça é o valor de linha e coluna armazenados na Posicao pos
        }

        public bool posicaoValida(Posicao pos)//Metodo que testa se a posicao POS é válida 
        {
            if(pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }

            return true;
        }

        public void validarPosicao(Posicao pos) //esse método recebe uma posicao e caso ela não seja válida ele lança uma exceção personalizada
        {
            if (!posicaoValida(pos))//se a posicao não é válida
            {
                throw new TabuleiroException("Posição inválida!");//Repassa para a classe de exceção a mensagem e a classe repassa para a classe exception
            }
        }

    }
}
