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
    class Queue : System.Collections.CollectionBase
    {
        public void Add(Job job)    //Add job
        {
            List.Add(job);
        }
        public bool Remove(int index)   //Remove job
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
        public Job Item(int index) //Reference a job
        {
            return (Job)List[index];
        }
        //
        public void Wait()
        {
            for (int lcv = 0; lcv < Count; lcv++)
            {
                this.Item(lcv).Wait();
            }
        }
        public void Wait(int waitTime)
        {
            for (int lcv = 0; lcv < Count; lcv++)
            {
                this.Item(lcv).Wait(waitTime);
            }
        }
    }
}
