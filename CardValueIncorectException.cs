using System;
using System.Runtime.Serialization;

namespace Bela
{
    [Serializable]
    /// <summary>
    /// Handles error if a player gets a card out of range
    /// </summary>
    internal class CardValueIncorectException : Exception
    {
        public CardValueIncorectException()
        {
        }

        public CardValueIncorectException(string message) : base(message)
        {
        }

        public CardValueIncorectException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CardValueIncorectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}