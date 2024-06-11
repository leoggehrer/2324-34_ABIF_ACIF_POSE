namespace BandOfPearl.Logic
{
    public class Pearl
    {
        #region fields
        private Pearl? _nextPearl = null;
        private string _color = "Unknown";
        private double _weight = 0;
        #endregion fields

        #region properties
        public string Color
        {
            get { return _color; }
        }
        
        public double Weight
        {
            get { return _weight; }
        }
        #endregion properties
        
        #region constructors
        public Pearl(string? color, double weight)
        {
            _weight = weight > 0 ? weight : 0;

            if (color != null 
                && (color.ToLower() == "red" 
                    || color.ToLower() == "green"
                    || color.ToLower() == "blue"))
            {
                _color = color;
            }
        }
        #endregion constructors
    }
}
