using System.Threading.Tasks;
using System;
using System.Threading;

namespace CountDownEvent
{
    class Program
    {
        static CountdownEvent cde = new CountdownEvent(Environment.ProcessorCount);

        static void Main(string[] args)
        {
            var userTaskCount = 5;
            cde.Reset(userTaskCount);

            for (int i = 0; i < userTaskCount; i++)
            {
                Task.Factory.StartNew(LoadUser, i);
            }
            cde.Wait();
            Console.WriteLine("\nUser load complete!\n");

            var productTaskCount = 8;
            cde.Reset(productTaskCount);
            for (int i = 0; i < productTaskCount; i++)
            {
                Task.Factory.StartNew(LoadProduct, i);
            }
            cde.Wait();
            Console.WriteLine("\nProduct load complete!\n");

            var orderTaskCount = 12;
            cde.Reset(orderTaskCount);
            for (int i = 0; i < orderTaskCount; i++)
            {
                Task.Factory.StartNew(LoadOrder, i);
            }
            cde.Wait();
            Console.WriteLine("\nOrder load complete!\n");

            Console.WriteLine("\nAll done\n");
            Console.Read();
        }

        static void LoadUser(object obj)
        {
            try
            {
                Console.WriteLine("-->{0}load user", obj);
            }
            finally
            {
                cde.Signal();
            }
        }

        static void LoadProduct(object obj)
        {
            try
            {
                Console.WriteLine("-->:{0}load Product", obj);
            }
            finally
            {
                cde.Signal();
            }
        }

        static void LoadOrder(object obj)
        {
            try
            {
                Console.WriteLine("-->:{0}load Order", obj);
            }
            finally
            {
                cde.Signal();
            }
        }
    }
}
