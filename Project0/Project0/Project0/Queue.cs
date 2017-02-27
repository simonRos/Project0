//Represents job queue
//Written by Simon Rosner
//v1.0.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    //Queue - List of Jobs, Jobs may be added or removed from 
    //the queue depending on if they are complete. Job may 
    //also be referenced by getting index of said job.
    class Queue : System.Collections.CollectionBase
    {
        //*****METHODS*****

        //Add Job To Queue
        public void Add(Job job)
        {
            List.Add(job);
        }
        
        //Remove Job To Queue
        public bool Remove(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                return false;
            }
            else
            {
                List.RemoveAt(index);
                return true;
            }
        }

        //Referance A Job From Queue
        public Job Item(int index)
        {
            return (Job)List[index];
        }

        //Wait
        public void Wait(int waitTime = 1)
        {
            for (int lcv = 0; lcv < Count; lcv++)
            {
                this.Item(lcv).Wait(waitTime);
            }
        }
    }
}
