using System.Text.RegularExpressions;

namespace Directions.Utils
{
    public class FormatInstructionUtil
    {
        public string FormatInstructions(string instructions)
        {
            int startIndex = instructions.IndexOf("<div");

            if (startIndex > 0)
                instructions = instructions.Substring(0, startIndex);

            return Regex.Replace(instructions, "<[^>]*>", " ").Trim();
        }
    }
}
