using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace TaskFcty
{
    class Program
    {       
        static void Main(string[] args)
        {
            #region Task ContinueWith & WaitAll
                ConcurrentStack<int> stack = new ConcurrentStack<int>();

                //Serial t1
                var t1 = Task.Factory.StartNew(() =>
                {
                    stack.Push(1);
                    stack.Push(2);
                });
                //Parellel t2 and t3
                var t2 = t1.ContinueWith(t =>
                {
                    int result;

                    stack.TryPop(out result);
                });
                var t3 = t1.ContinueWith(t =>
                {
                    int result;

                    stack.TryPop(out result);
                });
                Task.WaitAll(t2, t3);

                //Serial t4
                var t4 = Task.Factory.StartNew(() =>
                {
                    stack.Push(1);
                    stack.Push(2);
                });
                //Parallel t5 and t6
                var t5 = t4.ContinueWith(t =>
                {
                    int result;

                    stack.TryPop(out result);
                });
                var t6 = t4.ContinueWith(t =>
                {
                    int result;
                    stack.TryPeek(out result);
                });
                Task.WaitAll(t5, t6);

                //Serial t7
                var t7 = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Collection：" + stack.Count);
                });

                Console.Read();
            #endregion

            #region Task and factory
                //One way
                var task1 = new Task(() =>
                {
                    Run1();
                });

                //Another way using factory
                var task2 = Task.Factory.StartNew(() =>
                {
                    Run2();
                });

                Console.WriteLine("Before start****************************");
                Console.WriteLine("task1: {0}", task1.Status);
                Console.WriteLine("task2: {0}", task2.Status);

                task1.Start();
                Console.WriteLine("\nAfter start****************************");
                Console.WriteLine("task1: {0}", task1.Status);
                Console.WriteLine("task2: {0}", task2.Status);

                //Main thread's waiting for all completion.
                Task.WaitAll(task1, task2);
                Console.WriteLine("\nAll task completed****************************");
                Console.WriteLine("task1: {0}", task1.Status);
                Console.WriteLine("task2: {0}", task2.Status);

                Console.Read();
            #endregion

            #region Task ContinueWith
                var t11 = Task.Factory.StartNew<List<string>>(() => { return Run3(); });
                var t12 = t11.ContinueWith((i) =>
                {
                    Console.WriteLine("Collection：" + string.Join(",", i.Result));
                });
                Console.Read();
            #endregion

            #region Task Result
                var t111 = Task.Factory.StartNew<List<string>>(() => { return Run4(); });
                t1.Wait();
                var t222 = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Collection：" + string.Join(",", t111.Result));
                });
                Console.Read();
            #endregion

            #region Task Cancellation
                var cts = new CancellationTokenSource();
                var ct = cts.Token;
                Task task1111 = new Task(() => { Run5(ct); }, ct);
                Task task2222 = new Task(Run6);
                try
                {
                    task1111.Start();
                    task2222.Start();
                    Thread.Sleep(1000);
                    cts.Cancel();
                    Task.WaitAll(task1111, task2222);
                }
                catch (AggregateException ex)
                {
                    foreach (var e in ex.InnerExceptions)
                    {
                        Console.WriteLine("\nhi,I AM OperationCanceledException：{0}\n", e.Message);
                    }
                    Console.WriteLine("task1111 cancelled? {0}", task1111.IsCanceled);
                    Console.WriteLine("task2222 cancelled? {0}", task2222.IsCanceled);
                }
                Console.Read();
            #endregion
        }

        static void Run1()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Task 1");
        }

        static void Run2()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task 2");
        }


        static List<string> Run3()
        {
            return new List<string> { "1", "4", "8" };
        }

        static List<string> Run4()
        {
            return new List<string> { "1", "4", "8" };
        }


        static void Run5(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            Console.WriteLine("Task 5");
            Thread.Sleep(2000);
            ct.ThrowIfCancellationRequested();

            //Never get printed out.
            Console.WriteLine("Second part of the message from task 5");
        }

        static void Run6()
        {
            Console.WriteLine("Task 6");
        }
    }
}
