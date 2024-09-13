using Continuation.Model;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Continuation
{
    class Program
    {
        /* Pada chapter kali ini kita akan membahas macam-macam kemampuan Continuation dari Task yang tidak dimiliki Thread.
         * Continuity adalah keberlangsungan asynchronous process yang kita bisa tentukan secara sequential lewat code. 
         * Bisa dikatakan kemampuan code dimanage secara micro management (micro task) urutannya, agar melakukan concurrent development lebih mudah
         * baik untuk readability maupun penulisannya.
         * 
         * Note: Pada C# versi-versi yang latest, kalian bisa menulis Main program untuk Console aplication dengan cara async.
         * key word akan dijelaskan nanti pada topic ini.
         * 
         * static async Task Main(string[] args) { }
         */

        static void Main(string[] args) {

            /* Uncomment untuk berexperiment dan menjalankan fungsi
             */

            #region Awaiter Experiment
            //UtilizingAwaiter.GettingResult();
            //UtilizingAwaiter.EventOnComplete();
            //UtilizingAwaiter.MomentOfOnComplete();
            //UtilizingAwaiter.CheckIfAwaiterIsDone();
            #endregion

            #region Wait And Delay
            //UtilizingWaitAndDelay.WaitingForTask();
            //UtilizingWaitAndDelay.SynchronousWait();
            //UtilizingWaitAndDelay.DelayingTask();
            //UtilizingWaitAndDelay.DelayingAwaiter();
            //UtilizingWaitAndDelay.WaitingAllTask();
            //UtilizingWaitAndDelay.WaitingAnyTask();
            #endregion

            #region ContinueWith
            //UtilizingContinueWith.UsingContinue();
            //UtilizingContinueWith.MultipleContinue();
            //UtilizingContinueWith.ReturnFrom();
            #endregion

            #region AsyncAndAwait
            //UtilizingAsynchAndAwait.InvokingRunningTasks();
            //UtilizingAsynchAndAwait.ExecuteReturnedTask();
            //UtilizingAsynchAndAwait.ExecuteAwaitingProcess();
            //UtilizingAsynchAndAwait.DelayingAwaitingProcess();
            //UtilizingAsynchAndAwait.ExecuteWaitingLoop();
            //UtilizingAsynchAndAwait.ExecuteAwaitLoop();
            //UtilizingAsynchAndAwait.ExecuteAsynchronousReturnResult();
            #endregion

            //TravelAgency.PrintProfit();
        }
    }
}
