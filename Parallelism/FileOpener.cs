using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallelism
{
    internal class FileOpener
    {
        public FileOpener(string FileName) 
        {
            this.FullFileName = FileName + fileEnding;
            this.FileName = FileName;
        }
        public string FullFileName { get; set; }
        public string FileName { get; set; }
        public static int fileNumber = 1;
        private int fileSize = 1000000;
        private string fileEnding = ".txt";
        public void isExists(string FileName) 
        {
            StreamWriter sw = new StreamWriter(FileName);    
        }
        public void writeToFile(string str)
        {
            isExists(this.FullFileName);
            checkSize(this.FullFileName);
            StreamWriter sw = new StreamWriter(this.FullFileName);
            sw.WriteLine(str);
            sw.Close();
        }
        public void checkSize(string FileName)
        {
            FileInfo fi = new FileInfo(FileName);
            while(fi.Exists)
            {
                fi = new FileInfo(FileName + fileEnding);
                if (fi.Length > fileSize)
                {
                    fileNumber++;
                    this.FileName = this.FileName + fileNumber.ToString();
                    FullFileName= this.FileName + fileEnding;
                }
                else return;
            } 
         
        }
    }
}
