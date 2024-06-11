namespace BandOfPearl.Logic
{
    public class Band
    {
        private class Element
        {
            public Pearl? Pearl { get; set; }
            public Element? Next { get; set; }
        }
        #region fields
        private Element? _firstPearl = null;
        #endregion fields

        #region properties
        public int Count
        {
            get
            {
                int result = 0;
                Element? run = _firstPearl;

                while (run != null)
                {
                    result++;
                    run = run.Next;
                }
                return result;
            }
        }
        #endregion properties

        #region methods
        public void AddPearl(Pearl? pearl)
        {
            if (pearl != null)
            {
                _firstPearl = new Element { Pearl = pearl, Next = _firstPearl };
            }
       }

        public Pearl? GetPearlAtPosition(int position)
        {
            Pearl? result = null;
            int counter = 0;
            Element? run = _firstPearl;

            if (position >= 0 && position < Count)
            {
                while (run != null && counter < position)
                {
                    counter++;
                    run = run.Next;
                }
                result = run!.Pearl;
            }
            return result!;
        }

        public int GetNumberOfColoredPearls(string? color)
        {
            int result = 0;
            Element? run = _firstPearl;

            while (run != null && color != null)
            {
                if (color.Equals(run.Pearl!.Color, StringComparison.CurrentCultureIgnoreCase))
                {
                    result++;
                }
                run = run.Next;
            }
            return result!;
        }
        #endregion methods
    }
}
