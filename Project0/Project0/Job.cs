//Object representing simple system job
//Written by Simon Rosner
// v1.0.2


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    class Job
    {
        public static int lastID = 0;   //class variable for last ID
        public int ID { get; set; } //instance variable for ID
        public int timeStarted { get; set; }    //time job was created
        public int timeEnded { get; set; }  //time job ended
        public int timeWaiting { get; set; }    //time job has been waiting
        public int timeWorked { get; set; } //time spent being worked
        public int timeNeeded { get; set; } //time required to complete job
        public int timeRemaining { get; set; } //time remaining until completion
        public bool complete { get; set; }  //has the job finished?

        //constructor
        public Job(int timeNeeded, int timeStarted)
        {
            //set times
            this.timeNeeded = timeNeeded;
            timeRemaining = timeNeeded;
            this.timeStarted = timeStarted;
            timeWaiting = 0;
            timeWorked = 0;
            timeEnded = -1;
            //set complete
            CheckDone();
            //set IDs
            lastID++;
            this.ID = lastID;
        }
        //wait
        public void Wait()
        {
            timeWaiting++;
        }
        public void Wait(int timeWaiting)
        {
            this.timeWaiting += timeWaiting;
        }
        //work
        public void Work()
        {
            timeWorked++;
            timeRemaining--;
            CheckDone();
        }
        public void Work(int timeWorked)
        {
            this.timeWorked += timeWorked;
            timeRemaining -= timeWorked;
            CheckDone();
        }
        //is the job complete
        private void CheckDone()
        {
            if (timeRemaining <= 0)
            {
                complete = true;
                timeEnded = timeStarted + timeWorked + timeWaiting;
            }
            else
            {
                complete = false;
            }
        }
    }
}
