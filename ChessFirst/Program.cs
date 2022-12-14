using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessFirst
{
    internal static class Program
    {
        //Main Programm.
        private static void CoordinationDataStructures()
        {
            /*Not to be outshined, our concurrent collections and synchronization
             primitives have also been improved.This again follows the principle
             that you don?t need to make any code changes: you just upgrade and
             your code becomes more efficient.A good example of this is with updating
             the contents of a ConcurrentDictionary<TKey, TValue>.We?ve optimized some 
             common cases to involve less allocation and synchronization.Consider 
             the following code, which continually updates the same entry in the 
             dictionary to have a new value:
             After upgrading my machine to .NET 4.5, this runs 15% faster than it did with .NET 4.*/
            while (true)

            {
                while (!AllDraw.ThinkingRunInBothSide) { Thread.Sleep(1); }


                ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>();

                Stopwatch sw = Stopwatch.StartNew();

                cd.TryAdd(42, 0);

                for (int i = 1; i < 10000000; i++)

                {
                    int k = i - 1;
                    cd.TryUpdate(42, i, k);

                }

                Console.WriteLine(sw.Elapsed);

            }

        }

        private static void TaskParallelLibrary()

        {
            /*Just by upgrading from .NET 4 to.NET 4.5, on the machine on which I?m 
             writing this blog post, this code runs 400 % faster!This is of course 
             a microbenchmark that?s purely measuring a particular kind of overhead, 
             but nevertheless it should give you a glimpse into the kind of improvements
             that exist in the runtime.*/
            Stopwatch sw = new Stopwatch();

            while (true)

            {
                while (!AllDraw.ThinkingRunInBothSide) { Thread.Sleep(1); }

                GC.Collect();

                GC.WaitForPendingFinalizers();

                GC.Collect();



                TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();

                Task<object> t = tcs.Task;

                sw.Restart();

                for (int i = 0; i < 1000000; i++)
                {
                    t = t.ContinueWith(_ => (object)null);
                }

                TimeSpan elapsed = sw.Elapsed;

                GC.KeepAlive(tcs);



                Console.WriteLine(elapsed);

            }

        }
        [STAThread]
        private static void Main()
        {
            /* Task ttap = new Task(new Action(TaskParallelLibrary));
             ttap.Start();
             Task ttta = new Task(new Action(CoordinationDataStructures));
             ttta.Start();
           */
            Application.Run(new ChessFirstForm());
        }
    }
}
//End of Documents.