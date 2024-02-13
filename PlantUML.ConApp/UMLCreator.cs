using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PlantUML.ConApp
{
    internal class UMLCreator
    {
        /// <summary>
        /// Creates an activity diagram for the specified source code and saves it to the specified path.
        /// </summary>
        /// <param name="path">The path where the activity diagram will be saved.</param>
        /// <param name="source">The source code to generate the activity diagram from.</param>
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
                    var filePath = Path.Combine(path, fileName);
                    var diagramData = CreateActivityDiagram(methodNode);

                    diagramData.Insert(0, $"@startuml {classNode.Identifier.Text}.{methodNode.Identifier.Text}");
                    diagramData.Insert(1, $"title {classNode.Identifier.Text}.{methodNode.Identifier.Text}");
                    diagramData.Insert(2, "start");

                    diagramData.Add("stop");
                    diagramData.Add("@enduml");
                    File.WriteAllLines(filePath, diagramData);
                }
            }
        }

        /// <summary>
        /// Creates an activity diagram based on the provided method declaration syntax.
        /// </summary>
        /// <param name="methodNode">The method declaration syntax to analyze.</param>
        /// <returns>A list of strings representing the activity diagram data.</returns>
        public static List<string> CreateActivityDiagram(MethodDeclarationSyntax methodNode)
        {
            var diagramData = new List<string>();
            var statements = methodNode?.Body?.Statements;

            foreach (StatementSyntax statement in statements!)
            {
                AnalysisStatement(statement, diagramData, 0);
            }
            return diagramData;
        }

        /// <summary>
        /// Analyzes a syntax node and generates diagram data based on the structure of the code.
        /// </summary>
        /// <param name="syntaxNode">The syntax node to analyze.</param>
        /// <param name="diagramData">The list to store the generated diagram data.</param>
        /// <param name="level">The indentation level for the diagram data.</param>
        public static void AnalysisStatement(SyntaxNode syntaxNode, List<string> diagramData, int level)
        {
            if (syntaxNode is LocalDeclarationStatementSyntax localDeclarationStatement)
            {
                System.Diagnostics.Debug.WriteLine($"{nameof(localDeclarationStatement)} is known but not used!");
            }
            else if (syntaxNode is ExpressionStatementSyntax expressionStatement)
            {
                var expression = expressionStatement.ToString();

                expression = expression.Replace("System.Console.WriteLine", "PrintLine");
                expression = expression.Replace("Console.WriteLine", "PrintLine");
                expression = expression.Replace("System.Console.Write", "Print");
                expression = expression.Replace("Console.Write", "Print");

                expression = expression.Replace("System.Console.ReadLine", "ReadLine");
                expression = expression.Replace("Console.ReadLine", "ReadLine");
                expression = expression.Replace("System.Console.Read", "Read");
                expression = expression.Replace("Console.Read", "Read");

                diagramData.Add($":{expression}".SetIndent(level));
            }
            else if (syntaxNode is BlockSyntax blockSyntax)
            {
                foreach (var node in blockSyntax.ChildNodes())
                {
                    if (node is StatementSyntax statementSyntax)
                    {
                        AnalysisStatement(statementSyntax, diagramData, level + 1);
                    }
                }
            }
            else if (syntaxNode is IfStatementSyntax ifStatement)
            {
                diagramData.Add($"if ({ifStatement.Condition}) then (yes)".SetIndent(level));
                AnalysisStatement(ifStatement.Statement, diagramData, level + 1);
                if (ifStatement.Else != null)
                    AnalysisStatement(ifStatement.Else, diagramData, level + 1);

                diagramData.Add("endif".SetIndent(level));
            }
            else if (syntaxNode is ElseClauseSyntax elseClause)
            {
                diagramData.Add($"else (no)".SetIndent(level));
                AnalysisStatement(elseClause.Statement, diagramData, level + 1);
            }
            else if (syntaxNode is SwitchStatementSyntax switchStatement)
            {
                diagramData.Add($"switch ({switchStatement.Expression})".SetIndent(level));
                foreach (var section in switchStatement.Sections)
                {
                    var labels = $"{section.Labels}".Replace("case", "case(");

                    if (labels.Contains("default:"))
                        labels = labels.Replace("default:", "case ( default )");
                    else
                        labels = labels.Replace(":", " )");

                    diagramData.Add($"{labels}".SetIndent(level + 1));
                    foreach (var node in section.ChildNodes())
                    {
                        if (node is StatementSyntax statementSyntax)
                        {
                            AnalysisStatement(statementSyntax, diagramData, level + 1);
                        }
                    }
                }
                diagramData.Add("endswitch".SetIndent(level));
            }
            else if (syntaxNode is BreakStatementSyntax breakStatement)
            {
                System.Diagnostics.Debug.WriteLine($"{nameof(breakStatement)} is known but not used!");
            }
            else if (syntaxNode is ContinueStatementSyntax continueStatement)
            {
                System.Diagnostics.Debug.WriteLine($"{nameof(continueStatement)} is known but not used!");
            }   
            else if (syntaxNode is DoStatementSyntax doStatement)
            {
                diagramData.Add("repeat".SetIndent(level));
                AnalysisStatement(doStatement.Statement, diagramData, level + 1);
                diagramData.Add($"repeat while ({doStatement.Condition}) is (yes)".SetIndent(level));
            }
            else if (syntaxNode is WhileStatementSyntax whileStatement)
            {
                diagramData.Add($"while ({whileStatement.Condition}) is (yes)".SetIndent(level));
                AnalysisStatement(whileStatement.Statement, diagramData, level + 1);
                diagramData.Add("endwhile (no)".SetIndent(level));
            }
            else if (syntaxNode is ForStatementSyntax forStatement)
            {
                diagramData.Add($":{forStatement.Declaration};".SetIndent(level));
                diagramData.Add($"while ({forStatement.Condition}) is (yes)".SetIndent(level));
                AnalysisStatement(forStatement.Statement, diagramData, level + 1);
                if (forStatement.Incrementors.Count > 0)
                    diagramData.Add($":{forStatement.Incrementors};".SetIndent(level));

                diagramData.Add("endwhile (no)".SetIndent(level));
            }
            else if (syntaxNode is ReturnStatementSyntax returnStatement)
            {
                System.Diagnostics.Debug.WriteLine($"{nameof(returnStatement)} is known but not used!");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"{syntaxNode.GetType().Name} is unknown!");
            }
        }
    }
}
