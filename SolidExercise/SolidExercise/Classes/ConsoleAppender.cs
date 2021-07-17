using SolidExercise.Enums;
using SolidExercise.Interfaces;
using System;

namespace SolidExercise.Classes
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            Layout = layout;
        }
        public ConsoleAppender(ILayout layout, ReportLevel level)
        {
            Layout = layout;
            Level = level;
        }
        public ILayout Layout { get; }

        public ReportLevel Level { get; private set; }
        private int appendCounter = 0;

        public void Apppend(string date, string type, string error)
        {
            ReportLevel givenLevel = ReportLevelExtractor(type);
            if (givenLevel >= this.Level)
            {
                Console.WriteLine(Layout.Format, date, type, error);
                appendCounter++;
            }
        }
        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {Level.GetType().Name}, Messages appended: {appendCounter}";
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
