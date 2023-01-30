using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallelism
{
    internal class Race
    {
        Thread thread;
        public int KM { get; set; } = 0;
        Random rand = new Random(DateTime.Now.Millisecond);
        public string Name { get; set; }
        public bool STOP = false;
        public static bool TotalStop = false;
        public object obj = new object();
        public Race(string name)
        {
            this.Name = name;
            thread = new Thread(MainLoop);
            thread.Start();
        }
        public void Drive()
        {
            int km = rand.Next(0, 101);
            
            KM += km;
            if(KM > 10000)
                STOP = true;
        }
        public void MainLoop()
        {
            while(!STOP) 
            { 
                Drive();
            }
            if(KM >= 10000 && !TotalStop)
                lock(obj)
                {
                    Console.WriteLine(Name + " Reached " + KM);
                    TotalStop = true;
                    Thread.Sleep(10000);
                }
            Console.Read();
        }
    }
}
