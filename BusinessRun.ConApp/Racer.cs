namespace BusinessRun.ConApp
{
    /// <summary>
    /// Represents a racer in a race.
    /// </summary>
    public class Racer
    {
        /// <summary>
        /// Gets or sets the racer's number.
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the racer's name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the racer's vintage.
        /// </summary>
        public int Vintage { get; set; }

        /// <summary>
        /// Gets or sets the nationality of the racer.
        /// </summary>
        public string Nationality { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the racer's company.
        /// </summary>
        public string Company { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the racer's team.
        /// </summary>
        public string Team { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the racer's time.
        /// </summary>
        public double Time { get; set; }
    }
}

