namespace UPNCalculator.ConApp
{
    using PlantUML.Logic;

    public static class ObjectDiagram
    {
        public static string DiagramPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string FilePath = Path.Combine(DiagramPath, "od_Stack.puml");

        public static void Generate(object obj)
        {
            var diagramData = DiagramCreator.CreateObjectDiagram(100, obj).ToList();

            if (diagramData.Any())
            {
                diagramData.Insert(0, "@start" + "uml stack");
                diagramData.Add("@end" + "uml");
            }
            File.WriteAllLines(FilePath, diagramData);
        }
    }
}
