using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace LoggerLib
{
    public class LoggerBlock
    {
        private LogWriter _logWriter;

        public LoggerBlock()
        {
            InitLogging();
        }

        private void InitLogging()
        {
            _logWriter = new LogWriterFactory().Create();
            Logger.SetLogWriter(_logWriter, false);
        }

        public LogWriter LogWriter
        {
            get
            {
                return _logWriter;
            }
        }
    }
}
