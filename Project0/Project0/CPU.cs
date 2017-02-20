using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    class CPU
    {
        //Instance Variables
        int runTime;

        //Constructor
        public CPU(int runTime = 0)
        {
            this.runTime = runTime;
        }

        //Methods

        //Run simulates the amount of time a job in on the CPU
        //it returns the amount of excess time given to the job
        public int Run(Job job)
        {
            return Run(job, runTime);
        }

        public int Run(Job job, int runTime)
        {
            job.Work(runTime);
            if (job.complete)
                return Math.Abs(job.timeRemaining);
            return 0;
        }

    }
}
