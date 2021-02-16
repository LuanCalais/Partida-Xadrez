namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }//Associação Entre Classes
        public Cor cor { get; protected set; }//PROTECT só pode ser alterada por ela ou pelas subclasses dela
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }//A peça está em um tabuleiro

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;//Quando uma peça é criada ela ainda não tem posição, é o tabuleiro o responsável por coloca-la 
            this.tab = tab;                                                             //Com o métotodo colocarPeca
            this.cor = cor;
            this.qteMovimentos = 0; //A peça sempre inicia com 0 quando ela é criada
        }

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }


    }
}
