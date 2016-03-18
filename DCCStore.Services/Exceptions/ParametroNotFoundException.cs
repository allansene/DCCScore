using System;
using System.Runtime.Serialization;

namespace DCCStore.Services.Exceptions
{
    [Serializable]
    internal class ParametroNotFoundException : Exception
    {
        public ParametroNotFoundException()
        {
        }

        public ParametroNotFoundException(string message) : base(message)
        {
        }

        public ParametroNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParametroNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}