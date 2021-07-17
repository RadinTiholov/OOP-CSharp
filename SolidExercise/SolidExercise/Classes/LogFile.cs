using SolidExercise.Interfaces;
using System.Text;

namespace SolidExercise.Classes
{
    public class LogFile
    {
        public LogFile()
        {
            Text = new StringBuilder();
        }
        public int Size
        {
            get 
            {
                int sum = 0;
                foreach (char item in Text.ToString().Trim())
                {
                    if (char.IsLetter(item))
                    {
                        sum += (int)item;
                    }
                }
                return sum; 
            }
        }
        public StringBuilder Text {
            get;
        }
        public void Write(ILayout layout, string date, string type, string error) 
        {
            string someText = string.Format(layout.Format, date, type, error);
            Text.AppendLine(someText);
        }
    }
}
