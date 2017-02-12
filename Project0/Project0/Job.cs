/**
 * Operating Systems - Project0
 * 
 * Written by Simon Rosner, Petro Sokirniy, Taylor Hohenstein, Timothy Benson
 * 2/28/17
 */

using System.Threading;

namespace Project0
{
    /// <summary>
    /// Represents a simple system job.
    /// </summary>
    class Job
    {
        private static int _intanceCount;


        /// <param name="timeRequired">The time required to complete the job.</param>
        /// <param name="createdTimestamp">The timestamp when the the job was created.</param>
        public Job(int timeRequired, int createdTimestamp)
        {
            // Set times
            TimeRequired = timeRequired;
            CreatedTimestamp = createdTimestamp;
            CompletedTimestamp = -1;
            TimeSpentWaiting = 0;
            TimeSpentWorking = 0;

            // Set ID
            Id = Interlocked.Increment(ref _intanceCount); // thread-safe update+access

            // Set IsComplete
            CheckIfComplete();
        }


        public int TimeRequired { get; set; }
        public int CreatedTimestamp { get; set; }
        public int CompletedTimestamp { get; set; }
        public int TimeSpentWaiting { get; set; }
        public int TimeSpentWorking { get; set; }
        public int Id { get; }
        public bool IsComplete { get; set; }


        private void CheckIfComplete()
        {
            if (TimeSpentWorking >= TimeRequired)
            {
                IsComplete = true;
                CompletedTimestamp = CreatedTimestamp + TimeSpentWorking + TimeSpentWaiting;
            }
            else
            {
                IsComplete = false;
            }
        }

        public void AddWaitTime(int waitTime = 1)
        {
            TimeSpentWaiting += waitTime;
        }

        public void AddWorkTime(int workTime = 1)
        {
            TimeSpentWorking += workTime;
            CheckIfComplete();
        }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"TimeRequired: {TimeRequired}\n" +
                   $"CreatedTimestamp: {CreatedTimestamp}\n" +
                   $"CompletedTimestamp: {CompletedTimestamp}\n" +
                   $"TimeSpentWaiting: {TimeSpentWaiting}\n" +
                   $"TimeSpentWorking: {TimeSpentWorking}\n" +
                   $"IsComplete: {IsComplete}";
        }
    }
}