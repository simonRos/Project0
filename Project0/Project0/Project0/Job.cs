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
    //Job - Represents a process that will be put into
    //a queue and ran through the CPU.
    class Job
    {
        //*****VARIABLES*****
        public static int lastID = 0;           //Class Variable For Last ID
        public int ID { get; set; }             //Instance Variable For ID
        public int timeStarted { get; set; }    //Time Job Was Created
        public int timeEnded { get; set; }      //Time Job Was Ended
        public int timeWaiting { get; set; }    //Time Job Has Waiting
        public int timeWorked { get; set; }     //Time Job Has Worked
        public int timeNeeded { get; set; }     //Time Required To Complete Job
        public int timeRemaining { get; set; }  //Time Remaining Until Completion
        public bool complete { get; set; }      //Job Finished?

        //*****CONSTRUCTORS*****
        public Job(int timeNeeded, int timeStarted)
        {
            //Set Times
            this.timeNeeded = timeNeeded;
            timeRemaining = timeNeeded;
            this.timeStarted = timeStarted;
            timeWaiting = 0;
            timeWorked = 0;
            timeEnded = -1;
            //Set Complete
            CheckDone();
            //Set IDs
            lastID++;
            this.ID = lastID;
        }

        //Wait
        public void Wait(int timeWaiting = 1)
        {
            this.timeWaiting += timeWaiting;
        }

        //*****METHODS*****

        //Work
        public void Work(int timeWorked = 1)
        {
            this.timeWorked += timeWorked;
            timeRemaining -= timeWorked;
            CheckDone();
        }

        //Checks If Job Is Complete
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
