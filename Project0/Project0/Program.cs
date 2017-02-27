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
            String inPath = "..\\..\\input.txt"; //Input.txt
            String outPath = "..\\..\\output";   //Output.txt
            int switchTime = 2;                  //Amount of Time It Takes To Switch Jobs

            Console.Write("Please Enter Maximum RunTime: ");
            string input = Console.ReadLine();
            int maxRunTime = 0;
            if (int.TryParse(input, out maxRunTime))
            {
                for (int runTime = 1; runTime <= maxRunTime; runTime++) //Do Not Start From 0!!!
                {
                    Console.WriteLine("***Runtime {0}***", runTime);
                    Job.lastID = 0;
                    Queue jobQueue = new Queue(); //Queue For Jobs

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
                    using (StreamWriter writer = File.CreateText(outPath + runTime + ".txt"))
                    {
                        writer.WriteLine("ID \t Time Worked \t Time Needed \t Time Waiting \t Time Started \t Time Ended"); //Simple Header
                        //Write Times For Jobs
                        foreach (Job job in sched.jobComplete)
                        {
                            writer.WriteLine(job.ID + "\t\t" + (job.timeWorked + job.timeRemaining) + "\t\t" + job.timeNeeded + "\t\t" + job.timeWaiting +
                                "\t\t" + job.timeStarted + "\t\t" + job.timeEnded);
                        }
                    }
                }
            }
        }
    }
}
