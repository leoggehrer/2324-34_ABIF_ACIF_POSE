# POSE

## UPN-Calculator

Lehrziele

- Erstellen einfacher Klassen (Stack und Element)
- Anwendung der abstrakte Datenstruktur ‚Stack’.

### Aufgabenstellung

In dieser Übung ist ein so genannter *UPN-Calculator* zu implementieren. Das Besondere an diesem Rechner ist, dass dieser ohne die Verwendung von Klammern auskommt. Operanden und Zwischenergebnisse werden auf den Stack abgelegt.

Beispiel:

(5 + 3) \* 2 wird als 5 3 + 2 \* in den Rechner eingegeben

Der Rechner analysiert die eingegebene Zeile und speichert alle Zahlen auf den Stack. Kommt er zu einem Operation (bei uns ‚+’ ‚-’ ‚\*’ ‚/’ -> das sind alles zweistellig Operationen) werden zwei Operanden vom Stack genommen, der Operator auf die zwei Operanden angewandt und das Ergebnis (in unserem Fall 5 3 + -> 8) wird wieder auf den Stack gestellt. Nach dem Ende der Eingabe muss am Stack genau eine Zahl liegen. Diese Zahl stellt das Ergebnis der Rechenoperation dar.

Folgende Aufgaben sind zu bewältigen:

- Einlesen eines Terms in UPN-Notation
- Ablegen von Zahlen auf den Stack
  - Realisierung des Stacks als lineare Liste
- Den Rechner ausführlich auf korrekte Implementierung testen.

Die Programmstruktur ist entsprechend dem nachfolgenden Klassendiagramm zu entwickeln:

![Illustration](cd_ProgramWithStack.png)

**Ausgabe:**

Eine mögliche Ausgabe zeigt die folgende Abbildung:

![Illustration](output.png)

#### Erweiterte Anforderungen für Spezialisten

- Keine

#### Dokumente

- Lösungsidee (Notizen bitte in einer Mappe sammeln)
- Ablaufdiagramm (Konzept)
- Kommentierter Programmcode (Programmkopf bitte nicht vergessen)
- Testdokumentation (kann auch in dieser Übungsangabe enthalten sein)

#### Ergebnisdokumente

- Kommentierter Programmcode (erkläre in Kommentare deine Gedanken)

**Viel Spaß!**

## Class Diagram

### ObjectDiagram (CD)

![ObjectDiagram (CD)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/cd_ObjectDiagram.puml)

### Program (CD)

![Program (CD)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/cd_Program.puml)

### Stack (CD)

![Stack (CD)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/cd_Stack.puml)

### Element (CD)

![Element (CD)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/cd_Element.puml)

## Activity Diagrams

### ObjectDiagram.Generate (AC)

![ObjectDiagram.Generate (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/ac_ObjectDiagram_Generate.puml)

### Program.Main (AC)

![Program.Main (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/ac_Program_Main.puml)

### Program.Parse (AC)

![Program.Parse (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/ac_Program_Parse.puml)

### Stack.Push (AC)

![Stack.Push (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/ac_Stack_Push.puml)

### Stack.Pop (AC)

![Stack.Pop (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/ac_Stack_Pop.puml)

## Sequence Diagrams

### ObjectDiagram.Generate (SQ)

![ObjectDiagram.Generate (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/sq_ObjectDiagram_Generate.puml)

### Program.Main (SQ)

![Program.Main (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/sq_Program_Main.puml)

### Program.Parse (SQ)

![Program.Parse (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/sq_Program_Parse.puml)

### Stack.Push (SQ)

![Stack.Push (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/sq_Stack_Push.puml)

### Stack.Pop (SQ)

![Stack.Pop (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/UPNCalculator.ConApp/diagrams/sq_Stack_Pop.puml)
