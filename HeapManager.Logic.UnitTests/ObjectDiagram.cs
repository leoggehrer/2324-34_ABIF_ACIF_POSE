namespace HeapManager.Logic.UnitTests
{
    internal class ObjectDiagram
    {
        #region fields
        private static int _counter = 0;
        private static PlantUML.Logic.ObjectDiagramCreator diagramCreator = new();
        #endregion fields

        #region properties
        public static string FileName { get; set; } = "Heap";
        public static string DiagramPath 
        { 
            get => diagramCreator.DiagramPath; 
            set => diagramCreator.DiagramPath = value; 
        }
        #endregion properties

        #region constructors
        #endregion constructors

        #region methods
        public static void Create(object obj, params string[] notes)
        {
            diagramCreator.FileName = $"od_{FileName}_{++_counter}.puml";
            diagramCreator.CreateToFile(obj, notes);
        }
        #endregion methods
    }
}
