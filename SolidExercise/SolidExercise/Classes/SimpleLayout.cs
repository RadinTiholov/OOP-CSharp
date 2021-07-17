using SolidExercise.Interfaces;

namespace SolidExercise.Classes
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
