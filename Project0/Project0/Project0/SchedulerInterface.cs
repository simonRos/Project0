using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    //Scheduler Interface - 
    interface IScheduler
    {
        // Scheduler will need a way to get the next job,
        //a way to get the amount of time that job should run for,
        //and a way to add time to all the jobs in the wait queue

        Job NextJob();      
        int JobRunTime { get; }
        void Wait(int time);
    }
}
