using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    class OperatingSystem
    {
        CPU cpu;
        IScheduler scheduler;

        public OperatingSystem(CPU cpu, IScheduler sched)
        {
            this.cpu = cpu;
            this.scheduler = sched;
        }

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
