/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*---------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 CommentRate
*                 This program calculates the ratio between 
*                 code characters and comment characters.
*----------------------------------------------------------
*/
#nullable disable

namespace CommentRate.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main method of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Kommentarquote für C#-Dateien");
            Console.WriteLine("=============================");
            Console.WriteLine();

            string fileName;
            int codeChars, commentChars;
            double relationShip;

            fileName = GetFileName();
            AnalyzeFile(fileName, out codeChars, out commentChars);

            relationShip = (double)commentChars / (codeChars + commentChars) * 100;
            Console.WriteLine($"Von {codeChars + commentChars} Zeichen waren {commentChars} Kommentare, das ergibt {relationShip:f} % Kommentarquote.");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Prompts the user to enter a file name and validates if the file exists.
        /// </summary>
        /// <returns>The name of the existing file entered by the user.</returns>
        private static string GetFileName()
        {
            int counter = 0;
            string result = string.Empty;
            string input;

            do
            {
                if (counter++ == 0)
                {
                    Console.Write("Dateiname ohne Endung: ");
                }
                else
                {
                    Console.Write(@"Dateiname ohne Endung <im Anwendungsverzeichnis \bin\debug>: ");
                }
                input = $"{Console.ReadLine()}.cs";
                if (File.Exists(input))
                {
                    result = input;
                }
            } while (string.IsNullOrEmpty(result));
            return result;
        }

        /// <summary>
        /// Analyzes a file and counts the number of code characters and comment characters.
        /// </summary>
        /// <param name="fileName">The path of the file to analyze.</param>
        /// <param name="codeChars">The number of code characters in the file.</param>
        /// <param name="commentChars">The number of comment characters in the file.</param>
        private static void AnalyzeFile(string fileName, out int codeChars, out int commentChars)
        {
            int blockCommentStartIdx = -1, blockCommentEndIdx = -1;
            int lineCommentStartIdx = -1, lineCommentEndIdx = -1;
            string text = File.ReadAllText(fileName);
            
            codeChars = 0;
            commentChars = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (blockCommentStartIdx == -1 && lineCommentStartIdx == -1)
                {
                    blockCommentStartIdx = text.IndexOf("/" + "*", i);
                    if (blockCommentStartIdx > -1)
                    {
                        blockCommentEndIdx = text.IndexOf("*" + "/", blockCommentStartIdx);
                        if (blockCommentEndIdx > blockCommentStartIdx)
                        {
                            blockCommentEndIdx += 2;
                        }
                        else
                        {
                            blockCommentStartIdx = blockCommentEndIdx = -1;
                        }
                    }
                }
                else if (i >= blockCommentEndIdx)
                {
                    blockCommentStartIdx = blockCommentEndIdx = -1;
                }

                if (blockCommentStartIdx == -1 &&  lineCommentStartIdx == -1)
                {
                    lineCommentStartIdx = text.IndexOf("/" + "/", i);
                    if (lineCommentStartIdx > -1)
                    {
                        lineCommentEndIdx = text.IndexOf("\n", lineCommentStartIdx);
                        if (lineCommentEndIdx > lineCommentStartIdx)
                        {
                            lineCommentEndIdx += 2;
                        }
                        else
                        {
                            lineCommentStartIdx = lineCommentEndIdx = -1;
                        }
                    }
                }
                else if (i >= lineCommentEndIdx)
                {
                    lineCommentStartIdx = lineCommentEndIdx = -1;
                }

                if ((i >= blockCommentStartIdx && i <= blockCommentEndIdx)
                    || (i >= lineCommentStartIdx && i <= lineCommentEndIdx))
                {
                    commentChars = char.IsLetterOrDigit(text[i]) ? commentChars + 1 : commentChars;
                }
                else
                {
                    codeChars = char.IsLetterOrDigit(text[i]) ? codeChars + 1 : codeChars;
                }
            }
        }
    }
}
