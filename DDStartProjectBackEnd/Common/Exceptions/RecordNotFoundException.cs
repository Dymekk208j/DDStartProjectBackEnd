using System;

namespace DDStartProjectBackEnd.Common.Exceptions
{
    [Serializable]
    public class RegistrationProblemException : Exception
    {
        public RegistrationProblemException() : base() { }
        public RegistrationProblemException(string message) : base(message) { }
        public RegistrationProblemException(string message, Exception inner) : base(message, inner) { }

        protected RegistrationProblemException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
