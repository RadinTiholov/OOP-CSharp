using SolidExercise.Interfaces;

namespace SolidExercise.Classes
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.appenders = new IAppender[appenders.Length];
            for (int i = 0; i < this.appenders.Length; i++)
            {
                this.appenders[i] = appenders[i];
            }
        }
        private IAppender[] appenders;
        public void Error(string date, string error)
        {
            foreach (var appender in appenders)
            {
                appender.Apppend(date, nameof(Error).ToUpper(), error);
            }
        }

        public void Info(string date, string error)
        {
            foreach (var appender in appenders)
            {
                appender.Apppend(date, nameof(Info).ToUpper(), error);
            }
        }

        public void Warning(string date, string error)
        {
            foreach (var appender in appenders)
            {
                appender.Apppend(date, nameof(Warning).ToUpper(), error);
            }
        }
        public void Critical(string date, string error)
        {
            foreach (var appender in appenders)
            {
                appender.Apppend(date, nameof(Critical).ToUpper(), error);
            }
        }
        public void Fatal(string date, string error)
        {
            foreach (var appender in appenders)
            {
                appender.Apppend(date, nameof(Fatal).ToUpper(), error);
            }
        }
    }
}
