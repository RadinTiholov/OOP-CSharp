using SolidExercise.Interfaces;
using System;
using System.Text;

namespace SolidExercise.Classes
{
    public class XmlLayout : ILayout
    {
        public string Format => FormatText();

        private string FormatText() 
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("<log>");
            text.AppendLine("   <date>{0}</date>");
            text.AppendLine("   <level>{1}</level>");
            text.AppendLine("   <message>{2}</message>");
            text.AppendLine("</log>");
            return text.ToString().Trim();
        }
    }
}
