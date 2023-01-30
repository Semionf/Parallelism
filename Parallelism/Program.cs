using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Parallelism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyThread thread = new MyThread();
            //thread.Run1();
            //MyThread thread2 = new MyThread();
            //thread2.Run2();
            ThreadRace tr = new ThreadRace();


        }
    }
}
