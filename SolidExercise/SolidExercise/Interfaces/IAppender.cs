using SolidExercise.Enums;

namespace SolidExercise.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel Level { get;}
        void Apppend(string date, string type, string error);
    }
}
