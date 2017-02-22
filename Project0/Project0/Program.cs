using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            int jobsCreated = 50;
            int switchTime = 2;
            int runTime = 10;

            int[] timeNeeded = {22,46,10,42,57,27,35,36,42,5,60,16,
                                   34,16,17,1,26,35,6,12,24,15,11,
                                   23,49,45,53,51,46,21,46,16,15,
                                   23,55,53,23,8,20,56,18,17,58,
                                   25,54,34,54,5,3,5};

            Queue jobQueue = new Queue();

            foreach (int i in timeNeeded)
            {
                jobQueue.Add(new Job(i, 0));
            }

            Scheduler sched = new Scheduler(jobQueue, switchTime, runTime);
            OperatingSystem os = new OperatingSystem(new CPU(), sched);
            os.RunMachine();

            foreach (Job job in sched.jobComplete)
            {
                Console.WriteLine((job.timeWorked + job.timeRemaining) + "\t\t" + job.timeWaiting 
                    + "\t\t" + job.timeEnded);
            }


        }
    }
}
