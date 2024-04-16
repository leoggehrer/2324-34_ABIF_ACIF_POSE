﻿namespace LinkedList.ConApp
{
    using PlantUML.Logic;
    public static class ObjectDiagram
    {
        public const string DiagramPath = @"C:\Temp\LinkedList";
        public const string FilePath = $"{DiagramPath}\\od_LinkedList.puml";

        public static void Generate(params object[] items)
        {
            var diagramData = DiagramCreator.CreateObjectDiagram(100, items).ToList();

            diagramData.Insert(0, "@start" + "uml stack");
            diagramData.Insert(1, "title Object Diagram for LinkedList");
            diagramData.Add("@end" + "uml");

            if (Path.Exists(DiagramPath) == false)
            {
                Directory.CreateDirectory(DiagramPath);
            }
            File.WriteAllLines(FilePath, diagramData);
        }
    }
}

