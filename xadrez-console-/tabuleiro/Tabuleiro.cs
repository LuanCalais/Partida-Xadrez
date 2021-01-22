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

        public void colocarPeca(Peca p, Posicao pos)
        {
            pecas[pos.linha, pos.coluna] = p; //coloca a peça na matriz de peças 
            p.posicao = pos; //Diz que a nova posição da peça é o valor de linha e coluna armazenados na Posicao pos
        }



    }
}
