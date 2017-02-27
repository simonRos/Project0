using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//*****Petro Sokirniy*****
//******Simon Rosner******
//****Taylor Hohenstein***
//*****Timothy Benson*****

//********Project0********
//*******02/27/2017*******

//Project 0 is a representation of a time-sharing system using the 
//round-robin algorithm. The algorithm uses processes or "jobs" and
//puts them in a queue. The program gives each jobs a set amount of
//time on the CPU and then goes to the next "job" in the queue until
//each "job" is completed. Finally the program displayes the amount
//of time on the CPU, amount waited, and when the job ended.

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            //*****VARIABLES*****
            String inPath = "..\\..\\input.txt";   //Input.txt
            String outPath = "..\\..\\output.txt"; //Output.txt
            int jobsCreated = 50;                  //Amount of Jobs
            int switchTime = 2;                    //Amount of Time It Takes To Switch Jobs
            int runTime = 10;                      //Amount of Time on CPU
            Queue jobQueue = new Queue();          //Queue For Jobs
            //Array of Job Tims
            int[] timeNeeded = {22,46,10,42,57,27,35,36,42,5,
                60,16,34,16,17,1,26,35,6,12,24,15,11,
                23,49,45,53,51,46,21,46,16,15,
                23,55,53,23,8,20,56,18,17,58,
                25,54,34,54,5,3,5};

            //*****READS JOBS FROM TEXT FILE*****
            using (StreamReader reader = File.OpenText(inPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    jobQueue.Add(new Job(Convert.ToInt32(line), 0));
                }
            }

            //*****RUN OPERATING SYSTEM*****
            Scheduler sched = new Scheduler(jobQueue, switchTime, runTime); //Creation of Scheduler
            OperatingSystem os = new OperatingSystem(new CPU(), sched);     //Creation of OperatingSystem
            os.RunMachine(); //Runs CPU + Scheduler

            //*****CREATE TEXT FILE + WRITE TO TEXT FILE*****
            if (!File.Exists(outPath))
            {
                using (StreamWriter writer = File.CreateText(outPath))
                {
                    writer.WriteLine("ID \t Time worked \t Time waiting \t Time Ended"); //Simple Header
                    //Write Times For Jobs
                    foreach (Job job in sched.jobComplete)
                    {
                        writer.WriteLine((job.timeWorked + job.timeRemaining) + "\t\t" + job.timeWaiting
                            + "\t\t" + job.timeEnded);
                    }
                }
            }
        }
    }
}
