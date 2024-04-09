namespace HorseRace.ConApp
{
    public class Horse
    {
        #region fields
        private int number;
        private int age;
        private string name = string.Empty;
        private int position;
        private int rank;
        #endregion fields

        #region properties
        /// <summary>
        /// Gets or sets the number of the horse.
        /// </summary>
        public int Number { get => number; set => number = value; }
        /// <summary>
        /// Gets or sets the age of the horse.
        /// </summary>
        public int Age { get => age; set => age = value; }
        /// <summary>
        /// Gets or sets the name of the horse.
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Gets or sets the position of the horse.
        /// </summary>
        public int Position { get => position; set => position = value; }
        /// <summary>
        /// Gets or sets the rank of the horse.
        /// </summary>
        public int Rank { get => rank; set => rank = value; }
        #endregion properties
    }
}

