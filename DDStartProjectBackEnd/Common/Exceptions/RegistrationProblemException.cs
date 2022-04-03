using System;

namespace DDStartProjectBackEnd.Common.Exceptions
{
    [Serializable]
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException() : base() { }
        public RecordNotFoundException(string message) : base(message) { }
        public RecordNotFoundException(string message, Exception inner) : base(message, inner) { }

        protected RecordNotFoundException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
