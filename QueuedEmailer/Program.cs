using System;
using System.Threading;

namespace QueuedEmailer
{
    static class Program
    {
        static void Main()
        {
            var timer = new TimerCustom {Interval = 1500};

            timer.Elapsed += (obj, evt) =>
            {
                var singleTimer = obj as TimerCustom;

                //Stop the timer.
                if (singleTimer == null) return;
                singleTimer.Stop();

                if (singleTimer.queue.Count == 0) return;
                var item = singleTimer.queue.Dequeue();

                Send(item);

                //Start the timer once email's out
                singleTimer.Start();
            };

            timer.Start();

            var i = 100;
            while (i >= 0)
            {
                Console.WriteLine("ongoing");
                Thread.Sleep(1000);
                i--;
            }

            Console.Read();
        }

        static void Send(int obj)
        {
            Thread.Sleep(new Random().Next(8000, 10000));

            Console.WriteLine("Current Time：{0}，Mail{1} is out!", DateTime.Now, obj);
        }
    }
}
