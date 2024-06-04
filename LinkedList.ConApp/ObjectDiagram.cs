namespace LinkedList.ConApp
{
    using PlantUML.Logic;
    public static class ObjectDiagram
    {
        #region fields
        private static PlantUML.Logic.ObjectDiagramCreator diagramCreator = new("od_LinkedList.puml");
        #endregion fields

        #region properties
        #endregion properties

        #region constructors
        #endregion constructors

        #region methods
        public static void Create(object obj, params string[] notes)
        {
            diagramCreator.CreateToFile(obj, notes);
        }
        #endregion methods
    }
}


