using System;

namespace DDStartProjectBackEnd.Common.Helpers.Logger
{
    public interface ILogger
    {
        void Log(Exception exception, string additionalInformation = "");
    }
}
