using System;

namespace DCCScore.Utils.Parametrizacao
{
    public class ParametroNaoEncontradoException : SystemException
    {
        public ParametroNaoEncontradoException(string msg)
            : base(msg)
        {

        }
    }
}
