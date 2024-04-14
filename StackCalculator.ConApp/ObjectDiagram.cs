namespace StackCalculator.ConApp
{
    using PlantUML.Logic;
    public static class ObjectDiagram
    {
        public const string DiagramPath = @"C:\Temp\StackCalculator";
        public const string FilePath = $"{DiagramPath}\\od_Stack.puml";

        public static void Generate(params object[] items)
        {
            var diagramData = DiagramCreator.CreateObjectDiagram(100, items).ToList();

            if (diagramData.Any())
            {
                diagramData.Insert(0, "@start" + "uml stack");
                diagramData.Add("@end" + "uml");
            }
            if (Path.Exists(DiagramPath) == false)
            {
                Directory.CreateDirectory(DiagramPath);
            }
            File.WriteAllLines(FilePath, diagramData);
        }
    }
}
