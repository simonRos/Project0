using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    //CPU - "Runs" Jobs.
    class CPU
    {
        //*****VARIABLES*****
        int runTime; //Amount of Time on CPU

        //*****CONSTRUCTORS*****
        public CPU(int runTime = 0)
        {
            this.runTime = runTime;
        }

        //*****METHODS*****

        //Run - Simulates the amount of time a job on the CPU
        //and returns the amount of excess time given to the job
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
