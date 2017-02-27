using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    //Operating System - 
    class OperatingSystem
    {
        //*****VARIABLES*****
        CPU cpu;
        IScheduler scheduler;

        //*****CONSTRUCTORS*****
        public OperatingSystem(CPU cpu, IScheduler sched)
        {
            this.cpu = cpu;
            this.scheduler = sched;
        }

        //*****METHODS*****

        //Run Machine - Runs CPU and Scheduler
        public void RunMachine()
        {
            while (true)
            {
                Job job = scheduler.NextJob();
                if (job == null)
                    break;

                cpu.Run(job, scheduler.JobRunTime);
                scheduler.Wait(scheduler.JobRunTime);
            }
        }

    }
}
