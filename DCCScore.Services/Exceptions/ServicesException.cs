using System;
using System.Runtime.Serialization;

namespace DCCScore.Services.Exceptions
{
    [Serializable]
    internal class ServicesException : Exception
    {
        public ServicesException()
        {
        }

        public ServicesException(string message) : base(message)
        {
        }

        public ServicesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ServicesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}