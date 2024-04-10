namespace UPNCalculator.ConApp
{
    using PlantUML.Logic;
    public static class ObjectDiagram
    {
        public const string FilePath = @"/Users/ggehrer/source/Test/UPNCalculator/od_Stack.puml";

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
