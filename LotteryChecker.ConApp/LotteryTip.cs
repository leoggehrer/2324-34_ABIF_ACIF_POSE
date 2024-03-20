namespace LotteryChecker.ConApp
{
    /// <summary>
    /// Represents a lottery tip.
    /// </summary>
    public class LotteryTip
    {
        #region properties

        /// <summary>
        /// Gets or sets the ID of the lottery tip.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the numbers of the lottery tip.
        /// </summary>
        public int[] Numbers { get; set; } = new int[6];

        #endregion properties
    }
}

