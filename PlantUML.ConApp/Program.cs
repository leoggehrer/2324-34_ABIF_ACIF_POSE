namespace PlantUML.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PlantUML-Creator");
            var slnPath = GetCurrentSolutionPath();
            var files = GetSourceCodeFiles(slnPath, ["*.cs"]);

            foreach (var file in files)
            {
                var sourcePath = Path.GetDirectoryName(file);
                var source = File.ReadAllText(file!);

                UMLCreator.CreateActivityDiagram(sourcePath!, source);
            }
        }

        /// <summary>
        /// Retrieves the current solution path.
        /// </summary>
        /// <returns>
        /// The current solution path as a string.
        /// </returns>
        internal static string GetCurrentSolutionPath()
        {
            int endPos = AppContext.BaseDirectory
                                   .IndexOf($"{nameof(PlantUML)}", StringComparison.CurrentCultureIgnoreCase);
            var result = AppContext.BaseDirectory[..endPos];

            while (result.EndsWith(Path.DirectorySeparatorChar))
            {
                result = result[0..^1];
            }
            return result;
        }
        /// <summary>
        /// Retrieves a collection of source code files in the specified directory and its subdirectories based on the given search patterns.
        /// </summary>
        /// <param name="path">The directory path to search for source code files.</param>
        /// <param name="searchPatterns">An array of search patterns to match against the names of files in the specified directory and its subdirectories.</param>
        /// <returns>A collection of source code file paths.</returns>
        private static List<string> GetSourceCodeFiles(string path, string[] searchPatterns)
        {
            var result = new List<string>();
            var ignoreFolders = new string[] { $"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}", $"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}" };

            foreach (var searchPattern in searchPatterns)
            {
                result.AddRange(Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories)
                      .Where(f => ignoreFolders.Any(e => f.Contains(e)) == false)
                      .OrderBy(i => i));
            }
            return result;
        }

    }
}
