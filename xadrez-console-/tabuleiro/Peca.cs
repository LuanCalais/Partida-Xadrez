namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }//Associação Entre Classes
        public Cor cor { get; protected set; }//PROTECT só pode ser alterada por ela ou pelas subclasses dela
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }//A peça está em um tabuleiro

        public Peca(Posicao posicao, Tabuleiro tab, Cor cor)
        {
            this.posicao = posicao;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0; //A peça sempre inicia com 0 quando ela é criada
        }



    }
}
