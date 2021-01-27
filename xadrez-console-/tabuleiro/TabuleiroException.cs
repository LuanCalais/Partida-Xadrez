using System;


namespace tabuleiro
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string msg) : base(msg)//recebe uma mensagem e repassa para a classe exception do C#
        {

        } 
    }
}
