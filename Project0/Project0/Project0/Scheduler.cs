using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    //Scheduler - Round-Robin Algorithm. Decides when what Job
    //to switch to next. Keeps track of current and last Jobs.
    class Scheduler : IScheduler
    {
        //*****VARIABLES*****
        private Queue jobQueue;
        public Queue jobComplete;
        private Job lastJob = null;
        private int switchTime;
        private int jobRunTime;

        //*****CONSTRUCTORS*****
        public Scheduler(Queue jobQueue, int switchTime, int jobRunTime)
        {
            this.jobQueue = jobQueue;
            this.switchTime = switchTime;
            this.jobRunTime = jobRunTime;
            jobComplete = new Queue();
        }

        //*****METHODS*****
        public int JobRunTime
        {
            get { return jobRunTime; }
        }

        //Goes To Next Job
        public Job NextJob()
        {
            //Switch Jobs
            if (lastJob != null && lastJob.complete == false)
            {
                jobQueue.Add(lastJob);
            }
            else if (lastJob != null)
            {
                jobComplete.Add(lastJob);
                if (jobQueue.Count == 0)
                {
                    return null;
                }
            }
            //Last Job
            jobQueue.Wait(switchTime);
            lastJob = jobQueue.Item(0);
            jobQueue.Remove(0);
            return lastJob;
        }

        //Wait
        public void Wait(int time)
        {
            jobQueue.Wait(time);
        }
    }
}
