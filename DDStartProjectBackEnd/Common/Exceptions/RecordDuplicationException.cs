using System;

namespace DDStartProjectBackEnd.Common.Exceptions
{
    [Serializable]
    public class RecordDuplicationException : Exception
    {
        public RecordDuplicationException() : base() { }
        public RecordDuplicationException(string message) : base(message) { }
        public RecordDuplicationException(string message, Exception inner) : base(message, inner) { }

        protected RecordDuplicationException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
