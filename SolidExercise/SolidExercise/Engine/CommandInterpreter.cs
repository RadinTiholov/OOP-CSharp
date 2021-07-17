using SolidExercise.Classes;
using SolidExercise.Enums;
using SolidExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Engine
{
    public class CommandInterpreter
    {
        public void Run() 
        {
            //var simpleLayout = new SimpleLayout();
            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);

            //var file = new LogFile();

            //var fileAppender = new FileAppender(simpleLayout, file);
            //var logger = new Logger(consoleAppender, fileAppender);

            //logger.Error("3 / 26 / 2015 2:08:11 PM", "Error parsing JSON");
            //logger.Info("3 / 26 / 2015 2:08:11 PM", "User Pesho successfully registered.");
            int n = int.Parse(Console.ReadLine());
            List<IAppender> appenders = new List<IAppender>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                IAppender appender = null;
                ILayout layout = null;
                ReportLevel reportLevel = ReportLevel.Info;
                var file = new LogFile();
                //Layout checker
                if (input[1] == "SimpleLayout")
                {
                    layout = new SimpleLayout();
                }
                else if (input[1] == "XmlLayout")
                {
                    layout = new XmlLayout();
                }
                //Appender checker
                if (input[0] == "ConsoleAppender")
                {
                    if (input.Length == 2)
                    {
                        appender = new ConsoleAppender(layout);
                    }
                    else
                    {
                        reportLevel = ReportLevelExtractor(input[2]);

                        appender = new ConsoleAppender(layout, reportLevel);
                    }
                }
                else if (input[0] == "FileAppender")
                {
                    if (input.Length == 2)
                    {
                        appender = new FileAppender(layout, file);
                    }
                    else
                    {
                        reportLevel = ReportLevelExtractor(input[2]);
                        appender = new FileAppender(layout, file, reportLevel);
                    }
                }
                appenders.Add(appender);
            }
            var logger = new Logger(appenders.ToArray());
            string secondInput = Console.ReadLine();
            while (secondInput != "END")
            {
                string[] splitted = secondInput.Split("|");
                
                if (splitted[0] == "INFO")
                {
                    logger.Info(splitted[1], splitted[2]);
                }
                else if (splitted[0] == "WARNING")
                {
                    logger.Warning(splitted[1], splitted[2]);
                }
                else if (splitted[0] == "FATAL")
                {
                    logger.Fatal(splitted[1], splitted[2]);
                }
                else if (splitted[0] == "ERROR")
                {
                    logger.Error(splitted[1], splitted[2]);
                }
                else if (splitted[0] == "CRITICAL")
                {
                    logger.Critical(splitted[1], splitted[2]);
                }
                secondInput = Console.ReadLine();
            }
            PrintLoggerInfo(appenders);

        }

        private void PrintLoggerInfo(List<IAppender> appenders)
        {
            Console.WriteLine("Logger info");
            Console.WriteLine();
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }

        private ReportLevel ReportLevelExtractor(string input)
        {
            ReportLevel reportLevel = ReportLevel.Info;
            //ReportLevel checker
            if (input == "INFO")
            {
                reportLevel = ReportLevel.Info;
            }
            else if (input == "WARNING")
            {
                reportLevel = ReportLevel.Warning;
            }
            else if (input == "FATAL")
            {
                reportLevel = ReportLevel.Fatal;
            }
            else if (input == "ERROR")
            {
                reportLevel = ReportLevel.Error;
            }
            else if (input == "CRITICAL")
            {
                reportLevel = ReportLevel.Critical;
            }
            return reportLevel;
        }
    }
}
