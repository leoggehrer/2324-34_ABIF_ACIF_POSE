namespace SkiResults.ConApp
{
    /// <summary>
    /// Represents a racer in a ski race.
    /// </summary>
    public class Racer
    {
        /// <summary>
        /// Gets or sets the name of the racer.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the country of the racer.
        /// </summary>
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the time for the first run of the racer.
        /// </summary>
        public double TimeOne { get; set; } = 0;

        /// <summary>
        /// Gets or sets the time for the second run of the racer.
        /// </summary>
        public double TimeTwo { get; set; } = 0;

        /// <summary>
        /// Gets the total time of the racer (sum of TimeOne and Timetow).
        /// </summary>
        public double TotalTime
        {
            get
            {
                return TimeOne + TimeTwo;
            }
        }
    }
}

