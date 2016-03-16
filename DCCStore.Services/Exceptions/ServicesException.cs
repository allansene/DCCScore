using System;
using System.Runtime.Serialization;

namespace DCCStore.Services.Membership
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