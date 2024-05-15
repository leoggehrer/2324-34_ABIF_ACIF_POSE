namespace UPNCalculator.ConApp
{
    using PlantUML.Logic;
    public static class ObjectDiagram
    {
        public static string UserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string FilePath = Path.Combine(UserPath, "od_Stack.puml");

        public static void Generate(object obj)
        {
            var listItems = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var diagramData = DiagramCreator.CreateObjectDiagram(100, listItems).ToList();

            if (diagramData.Any())
            {
                diagramData.Insert(0, "@start" + "uml stack");
                diagramData.Add("@end" + "uml");
            }
            File.WriteAllLines(FilePath, diagramData);
        }
    }
}
