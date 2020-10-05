using System;
using System.Runtime.Serialization;

namespace WE02Library
{
    [Serializable]
    internal class AmountInvalidException : Exception
    {
        public AmountInvalidException()
        {
        }

        public AmountInvalidException(string message) : base(message)
        {
        }

        public AmountInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AmountInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}