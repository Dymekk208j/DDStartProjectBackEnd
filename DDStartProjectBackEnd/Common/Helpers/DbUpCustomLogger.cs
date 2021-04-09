using DbUp.Engine.Output;

namespace DDStartProjectBackEnd.Common.Helpers
{
    public class DbUpCustomLogger : IUpgradeLog
    {
        public string filename { get; set; }

        public void WriteError(string format, params object[] args)
        {
            var msg = "Database upgrade has occured error" + "\n" + string.Format(format,args);

            if (filename.StartsWith("SQL exception has occured in script"))
            {
                msg = filename + "\n" + string.Format(format, args);
            }

            throw new System.Exception(msg);
        }

        public void WriteInformation(string format, params object[] args)
        {
            if (format.StartsWith("SQL exception has occured in script"))
            {
                filename = string.Format(format, args);
            }
        }

        public void WriteWarning(string format, params object[] args)
        {
        }
    }
}
