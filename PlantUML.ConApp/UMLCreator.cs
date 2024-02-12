using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PlantUML.ConApp
{
    internal class UMLCreator
    {
        public static void CreateActivityDiagram(string path, string source)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(source);
            var syntaxRoot = syntaxTree.GetRoot();
            var classNodes = syntaxRoot.DescendantNodes().OfType<ClassDeclarationSyntax>();

            foreach (var classNode in classNodes)
            {
                var methodNodes = classNode.DescendantNodes().OfType<MethodDeclarationSyntax>();

                foreach (var methodNode in methodNodes)
                {
                    var fileName = $"{classNode.Identifier.Text}_{methodNode.Identifier.Text}.puml";
                    var statements = methodNode?.Body?.Statements;

                    foreach(StatementSyntax statement in statements!)
                    {
                        if (statement is IfStatementSyntax ifStmt)
                        {

                        }

                        Console.WriteLine(statement.GetType().Name);
                        Console.WriteLine($"{statement}");
                    }
                }
            }
        }
    }
}
