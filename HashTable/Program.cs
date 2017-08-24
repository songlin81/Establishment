using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;

namespace HashTable
{
    class Program
    {
        // obsolete
        static Hashtable sharedList = Hashtable.Synchronized(new Hashtable());

        // preferred
        static ConcurrentDictionary<Guid, Object> sharedList2 = new ConcurrentDictionary<Guid, object>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                sharedList.Add(Guid.NewGuid(), new object());
            }

            //Reading thread  
            new Thread(() =>
            {
                while (true)
                {
                    Console.Clear();
                    lock (sharedList.SyncRoot)
                    {
                        foreach (var key in sharedList.Keys)
                        {
                            Console.WriteLine("-->"+key.ToString());
                        }
                    }
                    Thread.Sleep(1);  //Give some time to other threads to kick in  
                }
            }).Start();

            //Writing thread  
            new Thread(() =>
            {
                while (true)
                {
                    Console.ReadLine();
                    lock (sharedList.SyncRoot)
                    {
                        sharedList.Add(Guid.NewGuid(), new object());
                    }
                }
            }).Start();



            for (int i = 0; i < 3; i++)
            {
                sharedList2.AddOrUpdate(Guid.NewGuid(), new object(), (key, oldValue) => new object());
            }

            //Reading thread  
            new Thread(() =>
            {
                while (true)
                {
                    Console.Clear();

                    foreach (var key in sharedList2.Keys)
                    {
                        Console.WriteLine("**** "+key.ToString());
                    }
                    //Give some time to other threads to kick in  
                    Thread.Sleep(1);
                }
            }).Start();

            //Writing thread  
            new Thread(() =>
            {
                while (true)
                {
                    Console.ReadLine();
                    sharedList2.AddOrUpdate(Guid.NewGuid(), new object(), (key, oldValue) => new object());
                }
            }).Start();
        }
    }
}
