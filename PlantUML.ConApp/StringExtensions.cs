using System.Text;

namespace PlantUML.ConApp
{
    public static class StringExtensions
    {
        public static string Indent = "  ";
        /// <summary>
        /// Diese Methode fuegt einem Text n Einzuege hinzu.
        /// </summary>
        /// <param name="text">Text, dem die Einzuege hinzugefuegt werden.</param>
        /// <param name="count">Anzahl der Einzuege die dem Text hinzugefuegt werden.</param>
        /// <returns>Text mit Anzahl von Einzuegen.</returns>
        public static string SetIndent(this string text, int count)
        {
            StringBuilder sb = new();

            if (text != null)
            {
                for (int i = 0; i < count; i++)
                    sb.Append(Indent);        // spaces for one indent.
            }
            sb.Append(text);
            return sb.ToString();
        }

        /// <summary>
        /// This method adds n indents to a string array.
        /// </summary>
        /// <param name="lines">String array to which the indents are added.</param>
        /// <param name="count">Number of indents that are added to the string array.</param>
        /// <returns>String array with number of indents.</returns>
        public static string[] SetIndent(this string[] lines, int count)
        {
            if (lines != null)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].SetIndent(count);
                }
            }
            return lines ?? Array.Empty<string>();
        }
    }
}
