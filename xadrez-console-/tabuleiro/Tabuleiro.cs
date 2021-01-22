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


        public Peca peca(int linhas, int colunas)
        {
            return pecas[linhas, colunas];
        } 


    }
}
