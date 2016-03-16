using System;
using System.Runtime.Serialization;

namespace DCCStore.Services.Membership
{
    [Serializable]
    internal class EntidadeInvalidaException : Exception
    {
        public EntidadeInvalidaException()
        {
        }

        public EntidadeInvalidaException(string message) : base(message)
        {
        }

        public EntidadeInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntidadeInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}