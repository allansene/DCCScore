using System;

namespace Sinco.Configuracao
{
    public class ParametroNaoEncontradoException : SystemException
    {
        public ParametroNaoEncontradoException(string msg)
            : base(msg)
        {

        }
    }
}
