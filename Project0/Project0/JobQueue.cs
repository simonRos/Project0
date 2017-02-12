/**
 * Operating Systems - Project0
 * 
 * Written by Simon Rosner, Petro Sokirniy, Taylor Hohenstein, Timothy Benson
 * 2/28/17
 */

using System;
using System.Collections;

namespace Project0
{
    /// <summary>
    /// Represents a job queue.
    /// </summary>
    class JobQueue : CollectionBase
    {
        public void AddJob(Job job)
        {
            List.Add(job);
        }

        public bool RemoveJobAt(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                return false;
            }
            List.RemoveAt(index);
            return true;
        }

        public Job GetJobAt(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            return (Job) List[index];
        }

        public void AddWaitTimeToAllJobs(int waitTime = 1)
        {
            for (int i = 0; i < Count; i++)
            {
                GetJobAt(i).AddWaitTime(waitTime);
            }
        }

        public override string ToString()
        {
            string toString = "JOB QUEUE:\n";
            foreach (var job in List)
            {
                toString += job.ToString() + "\n";
            }
            return toString;
        }
    }
}