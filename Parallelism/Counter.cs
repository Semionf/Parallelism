using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallelism
{
    internal class Counter
    {
        public Counter(string str)
        {
            this.str = str;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{str} + {i + 1}");
            }
        }
        public string str { get; set; }
    }
}
