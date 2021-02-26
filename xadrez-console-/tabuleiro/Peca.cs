namespace tabuleiro
{
    abstract class Peca
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

        public bool existeMovimentosPossiveis()//Verifica se a peça não está bloqueada de movimentos 
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if(mat[i,j])
                    {
                        return true;//se ela percorrer as matrizes e encontrar um movimento possível, retorna true
                    }
                }
            }
            return false;//se não encontrar nada verdadeiro na matriz, retorna false
        }

        public bool podeMoverPara(Posicao pos)//Diz se a peça pode mover para uma dada posição 
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];//testa se nessa linha e coluna é true 
        }

        public abstract bool[,] movimentosPossiveis();//bool pois vai ser true onde o movimento for possível e false onde não for
      


    }
}
