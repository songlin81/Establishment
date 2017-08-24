using System.Collections.Generic;

namespace QueuedEmailer
{
    class TimerCustom : System.Timers.Timer
    {
        public Queue<int> queue = new Queue<int>();

        public TimerCustom()
        {
            //for (int i = 0; i < short.MaxValue; i++)
            for (int i = 0; i < 3; i++)
            {
                queue.Enqueue(i);
            }
        }
    }
}
