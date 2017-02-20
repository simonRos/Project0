using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    class Scheduler : IScheduler
    {
        /*
         * Round Robin Scheduler
         */

        //Instance Variables
        private Queue jobQueue;
        private Queue jobComplete;
        private Job lastJob = null;
        private int switchTime;
        private int jobRunTime;


        public Scheduler(Queue jobQueue, int switchTime, int jobRunTime)
        {
            this.jobQueue = jobQueue;
            this.switchTime = switchTime;
            jobComplete = new Queue();
        }

        public int JobRunTime
        {
            get { return jobRunTime; }
        }


        public Job NextJob()
        {

            if (lastJob != null && lastJob.complete == false)
            {
                jobQueue.Add(lastJob);
            }
            else
            {
                jobComplete.Add(lastJob);
                if (jobQueue.Count == 0)
                {
                    return null;
                }
                    
            }

            jobQueue.Wait(switchTime);
            lastJob = jobQueue.Item(0);
            jobQueue.Remove(0);
            return lastJob;
        }

        public void Wait(int time)
        {
            jobQueue.Wait(time);
        }

    }
}
