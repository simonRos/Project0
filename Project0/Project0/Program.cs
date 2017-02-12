/**
 * Operating Systems - Project0
 * 
 * TODO: Program description
 * 
 * Written by Simon Rosner, Petro Sokirniy, Taylor Hohenstein, Timothy Benson
 * 2/28/17
 */

using System;

namespace Project0
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Playing around with things
            JobQueue jobQeue = new JobQueue();

            jobQeue.AddJob(new Job(8, 0));
            jobQeue.AddJob(new Job(34, 1));
            Console.WriteLine(jobQeue.GetJobAt(0).ToString());
            Console.WriteLine("\n" + jobQeue.ToString());

            jobQeue.AddWaitTimeToAllJobs(5);
            jobQeue.GetJobAt(0).AddWorkTime();
            Console.WriteLine("\n" + jobQeue.GetJobAt(0).ToString());
            Console.WriteLine("\n" + jobQeue.ToString());

            jobQeue.GetJobAt(0).AddWorkTime(7);
            Console.WriteLine("\n" + jobQeue.GetJobAt(0).ToString());
            Console.WriteLine("\n" + jobQeue.ToString());

            if (jobQeue.GetJobAt(0).IsComplete)
            {
                jobQeue.RemoveJobAt(0);
                Console.WriteLine("job removed");
            }
            Console.WriteLine("\n" + jobQeue.ToString());

            jobQeue.AddJob(new Job(4, 29));
            /* The index "shifts" here since we removed a job above. Seems like unnecessary complexity. Using Queue<>
             * instead of extending CollectionBase would be simpler, no? If we need to access one job in particular,
             * it will always be at the front of the queue and any other access is to every other job in the queue,
             * so we just dequeue, modify, and requeue right? Let me know if I'm missing something. */
            jobQeue.GetJobAt(1).AddWorkTime(34);
            Console.WriteLine("\n" + jobQeue.ToString());
        }
    }
}