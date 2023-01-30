using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallelism
{
    internal class ThreadRace
    {
        public ThreadRace()
        { 
            Race[] races = new Race[10];
            initRaces(races);
        }
        string[] Names = { "Fiat","Subaro", "Reno", "Toyota", "Mercedes", "Seat", "Ford", "Lamburgini", "Audi", "Susita" };
        public void initRaces(Race[] races)
        {
            for(int i = 0; i < 10; i++)
            {
                races[i] = new Race(Names[i]);
            }
        }
    }

  
}
