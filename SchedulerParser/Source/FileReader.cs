using System;
using System.IO;

namespace Scheduler
{
    public class FileReader
    {
        public static string[] ReadFile(string textFilePath)
        {
            try
            {
                return File.ReadAllLines(textFilePath);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}