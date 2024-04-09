namespace ClassManagement.ConApp
{
    /// <summary>
    /// Represents a pupil.
    /// </summary>
    public class Pupil
    {
        #region fields
        private int catalogNumber;
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string postalCode = string.Empty;
        #endregion fields

        #region properties
        /// <summary>
        /// Gets or sets the catalog number of the pupil.
        /// </summary>
        public int CatalogNumber { get => catalogNumber; set => catalogNumber = value; }
        /// <summary>
        /// The first name of the pupil.
        /// </summary>
        public string FirstName { get => firstName; set => firstName = value; }
        /// <summary>
        /// The last name of the pupil.
        /// </summary>
        public string LastName { get => lastName; set => lastName = value; }
        /// <summary>
        /// Gets or sets the postal code of the pupil.
        /// </summary>
        public string PostalCode { get => postalCode; set => postalCode = value; }
        #endregion properties
        
        /// <summary>
        /// Returns a string that represents the current pupil object.
        /// </summary>
        /// <returns>A string that contains the catalog number, first name, last name, and postal code of the pupil.</returns>
        override public string ToString()
        {
            return $"{CatalogNumber, 2} {FirstName, 20} {LastName, 20} {PostalCode}";
        }
    }
}
