using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Parallelism
{
    internal class MyThread
    {
        public void Run1()
        {
            Count c1 = new Count("A", 2000);
            Count c2 = new Count("B", 500);
        }
        public void Run2()
        {
            Count c1 = new Count("A", 1000);
            Count c2 = new Count("B", 500);
            Count c3 = new Count("C", 250);
        }
        public void Run3()
        {
            File file1 = new File("File1.txt");
            File file2 = new File("File2.txt");
            File file3 = new File("File3.txt");
            File file4 = new File("File4.txt");
        }
    }
    public class Count
    {
        Thread thread;
        public Count(string label, int sleep)
        {
            Label = label;
            SleepTime = sleep;
            thread = new Thread(Run);
            thread.Start();
        }

        public string Label { get; set; }
        public int SleepTime { get; set; }
        private static bool Running = true;

        public void Run()
        {
            int i = 1;
            while(Running)
            {
                Console.WriteLine($"This is num {i} {Label}");
                Thread.Sleep(SleepTime);
                if (i % 10 == 0)
                {
                    Console.WriteLine("In order to stop loop press 0");
                    int input = int.Parse(Console.ReadLine());

                    if (input == 0)
                    {
                       Running= false;
                    }
                }
                i++;
            }
            Console.Read();
        }
        public bool checkBreak()
        {
            string input;
            Console.WriteLine("In order to stop loop press 0");
            input = Console.ReadLine();
            if(input == "0")
                return true;
            else return false;
        }
        
    }

   
    public class File
    {

        public string FileName { get; set; }
        public string str { get; set; } = "Hello";
        public File(string FileName)
        {
            Thread thread = new Thread(insertLine);
            this.FileName = FileName;
            
            thread.Start();
            
        }
        public void insertLine()
        {
            StreamWriter sw = new StreamWriter(FileName);
            Random rand = new Random(DateTime.Now.Millisecond);
            for(int i = 0; i < 10000; i++)
            {
                sw.WriteLine($"{i+1}. " + rand.Next());
            }
            sw.Close();
        }
    }
}

