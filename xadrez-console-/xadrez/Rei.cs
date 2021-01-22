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

    }
}
