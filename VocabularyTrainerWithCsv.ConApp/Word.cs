namespace VocabularyTrainerWithCsv.ConApp
{
    /// <summary>
    /// Represents a word with its English and German translations.
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Gets or sets the German word.
        /// </summary>
        public string GermanWord { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the English word.
        /// </summary>
        public string EnglishWord { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the number of hits for this word.
        /// </summary>
        public int Hits { get; set; } = 0;

        /// <summary>
        /// Gets or sets the number of fails for this word.
        /// </summary>
        public int Fails { get; set; } = 0;
    }
}

