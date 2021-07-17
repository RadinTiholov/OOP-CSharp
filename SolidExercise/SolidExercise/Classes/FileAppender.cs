using SolidExercise.Enums;
using SolidExercise.Interfaces;
using System.IO;

namespace SolidExercise.Classes
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout,LogFile logFile)
        {
            Layout = layout;
            LogFile = logFile;
        }
        public FileAppender(ILayout layout, LogFile logFile, ReportLevel level)
        {
            Layout = layout;
            LogFile = logFile;
            Level = level;
        }
        public ILayout Layout { get; }
        private LogFile LogFile;
        private int appendCounter = 0;
        public ReportLevel Level { get; private set; }
        public void Apppend(string date, string type ,string error)
        {
            ReportLevel givenLevel = ReportLevelExtractor(type);
            if (givenLevel >= this.Level)
            {
                LogFile.Write(Layout, date, type, error);
                File.WriteAllText("log.txt", LogFile.Text.ToString());
                appendCounter++;
            }
        }
        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {Level.GetType().Name}, Messages appended: {appendCounter}, File size: {LogFile.Size}";
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
