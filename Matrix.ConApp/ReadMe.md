# POSE

## Matrix-Vergleich

Lernziele

- Zugriff auf Werte einer zweidimensionalen Matrix
- Methoden

### Aufgabenstellung

Schreiben Sie ein Programm ***Matrix***, mit dem ein zweidimensionales Array ***beliebiger*** Größe mit ganzen Zufallszahlen zwischen 1 und 9 gefüllt wird. Anschließend sollen diese Zahlen und die Beziehungen zwischen horizontal benachbarten Zahlen mit **<**, **>** oder **=** auf den Bildschirm ausgegeben werden (siehe Screenshot, Einfärbung optional).

![Illustration](Task.003.png)

Definieren und Implementieren Sie dazu zumindest zwei Methoden:

- ***CreateMatrix(...)***: Diese  Methode erzeugt und befüllt  die Matrix in der gewünschten  Größe mit Zufallszahlen  zwischen 1 und 9
- ***CompareAndPrintMatrix(...)***:  Diese Methode gibt die Zahlen  der Matrix und die  Vergleichsoperatoren zwischen  diesen Zahlen auf die Konsole

  aus.

**Zusatzaufgabe:**

Geben Sie zusätzlich zu den horizontalen Beziehungen auch die  Beziehungen zwischen übereinander liegenden Zahlen mit  „**A**“, „**V**“ oder „**=**“ aus!

![Illustration](Task.004.png)

## Activity Diagrams

### Program.Main

![Program.Main](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/Matrix.ConApp/Diagrams/ac_Program_Main.puml)

### Program.ReadMatrixDimensions

![Program.ReadMatrixDimensions](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/Matrix.ConApp/Diagrams/ac_Program_ReadMatrixDimensions.puml)

### Program.CreateMatrix

![Program.CreateMatrix](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/Matrix.ConApp/Diagrams/ac_Program_CreateMatrix.puml)

### Program.CompareAndPrintMatrix

![Program.CompareAndPrintMatrix](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/Matrix.ConApp/Diagrams/ac_Program_CompareAndPrintMatrix.puml)

### Program.CompareAndPrintMatrixValues

![Program.CompareAndPrintMatrixValues](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/Matrix.ConApp/Diagrams/ac_Program_CompareAndPrintMatrixValues.puml)

### Program.CompareAndPrintMatrixRows

![Program.CompareAndPrintMatrixRows](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/Matrix.ConApp/Diagrams/ac_Program_CompareAndPrintMatrixRows.puml)
