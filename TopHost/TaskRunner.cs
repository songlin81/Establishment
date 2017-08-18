using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using LoggerLib;
using Structure;
using Timer = System.Timers.Timer;

namespace TopHost
{
    public class TaskRunner
    {
        readonly Timer _timer;
        private static int _temp;
        readonly LoggerBlock _loggerBlock = new LoggerBlock();

        public TaskRunner()
        {
            _timer = new Timer();
        }

        public void Start()
        {
            try
            {
                _timer.AutoReset = false;
                _timer.Elapsed += Timer_Elapsed;
                _timer.Interval = 1000;
                _timer.Start();
            }
            catch (Exception)
            {
                _loggerBlock.LogWriter.Write("Task started at " + DateTime.Now, "General", 5, 2000, TraceEventType.Error);
                throw;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                _loggerBlock.LogWriter.Write("Task initiated", "General", 5, 2000, TraceEventType.Information);

                #if DEBUG
                    Console.WriteLine("Debug at {0} with counter {1}.", DateTime.Now, _temp++);
                #endif

                //heavy lifting comes here...
                Thread.Sleep(2000);

                var service = Facade.CreateService("foundation");
                service.init();

                #if DEBUG
                    Console.WriteLine("Task completed at {0}.\n", DateTime.Now);
                #endif
            }
            catch (Exception)
            {
                _loggerBlock.LogWriter.Write("Error occurred at " + DateTime.Now, "General", 5, 2000, TraceEventType.Error);
            }
            finally
            {
                _timer.Start();
            }
        }

        public void Stop()
        {
            try
            {
                _loggerBlock.LogWriter.Write("Task stopped at " + DateTime.Now, "General", 5, 2000, TraceEventType.Information);
            }
            catch (Exception)
            {
                _loggerBlock.LogWriter.Write("Error occurred at " + DateTime.Now, "General", 5, 2000, TraceEventType.Error);
            }
            finally
            {
                _timer.Stop();
            }
        }
    }
}
