using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task Cancellation

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            var task01 = Task.Run(() => {
                Console.WriteLine("running task");
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("finishing task");
                Trace.WriteLine("finishing task");
            });


            try {
                var task02 = Task.Run(() => {
                    cts.Cancel();
                    doWork(ct);

                });

                task02.Wait();
            }
            catch (AggregateException ae) {
                    foreach(var v in ae.InnerExceptions)
                {
                    Console.WriteLine(v.Message);
                }
            }
            finally {
                cts.Dispose();
            }





   


        }

        static void doWork(CancellationToken token) {

            Console.WriteLine("running task 2");
            
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancelling task");
                token.ThrowIfCancellationRequested();
            }

            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("finishing task 2");
            Trace.WriteLine("finishing task 2");

        }



    }


}
