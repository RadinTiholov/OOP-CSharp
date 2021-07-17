namespace SolidExercise.Interfaces
{
    public interface ILogger
    {
        void Info(string date, string error);
        void Warning(string date, string error);
        void Error(string date, string error);
        void Critical(string date, string error);
        void Fatal(string date, string error);
    }
}
