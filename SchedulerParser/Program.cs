using System;
using Scheduler;
using Scheduler.Source;

namespace SchedulerParser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please input your command \n" +
                              "<config-file-path.txt> <current time as HH:MM>");
            var userInput = Console.ReadLine()?.Split(' ');
            try
            {
                Run(userInput);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong. Did you input in the correct format?");
            }
        }

        private static void Run(string[] userInput)
        {
            var configFilePath = userInput?[0];
            var time = userInput?[1].Split(':');
            var commands = FileReader.ReadFile(configFilePath);
            if (commands == null)
            {
                Console.WriteLine("Please enter a valid file path.");
                return;
            }

            var converter = new ConfigConverter(time?[0], time?[1]);
            var results = converter.Convert(commands);
            Console.WriteLine("\n");
            foreach (var result in results)
                Console.WriteLine(result);
        }
    }
}