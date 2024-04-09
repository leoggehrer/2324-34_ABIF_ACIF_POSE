# POSE

## BigInteger mit Methoden

Lernziele

- Implementierung von Methoden nach vorgegebenen verbalen Schnittstellenbeschreibungen und Lösungsansätzen
- Vertiefung String-, Character- und Integerdatentypen

Hintergrund

Wie  Sie  der  Microsoft-Dokumentation  zu  den  in  C#  unterstützten  einfachen  Datentypen [(https://msdn.microsoft.com/de-de/library/cs7y5x0x%28v=vs.90%29.aspx)](https://msdn.microsoft.com/de-de/library/cs7y5x0x%28v=vs.90%29.aspx)  entnehmen  können, stehen in C# verschiedene Datentypen zum Rechnen mit positiven und negativen ganzen Zahlen zur Verfügung.

Der größte dieser ganzzahligen Datentypen ist „decimal“ mit einer Speichergröße von 128 Bits oder 16 Bytes. Das ist der Wertebereich von decimal:

-79228162514264337593543950335 .. 79228162514264337593543950335

Das Rechnen mit noch größeren Zahlen ist nur möglich, wenn man dazu auf Zeichenketten zum Abspeichern der Zahlen ausweicht und die Berechnungen für jede einzelne Stelle der Zeichenkette selbst durchführt.

### Aufgabenstellung

In dieser Aufgabe sollen Sie ein C#-Programm schreiben, das beliebig große natürliche Zahlen addieren kann.

Das Programm soll aus folgenden Methoden bestehen:

#### ReadBigInteger

Diese Methode liest einen beliebig langen Text ein, und liefert diesen als String zurück. Solange die Eingabe andere Zeichen als Ziffern enthält, wird die Eingabe wiederholt.

- Parameter:
  - Ein String-Parameter gibt an, welche Eingabeaufforderung dem Benutzer vor dem Einlesen des Textes angezeigt werden soll.
- Rückgabewert:
- Ein String, der nur Ziffern enthält

#### AddLeadingCharacters

Diese Methode soll vor einem übergebenen String eine bestimmte Anzahl von Zeichen ergänzen.

- Parameter:
  - Der String, der ergänzt werden soll
  - Der Character, mit dem der String ergänzt werden soll
  - Die Anzahl der Zeichen, um die der String ergänzt werden soll.
- Rückgabewert:
- Der neue String, aufgefüllt mit den ergänzten Zeichen

Beispiel: AddLeadingCharacters(„1234“, ‘0‘,  5) liefert: „000001234“

#### AddBigInteger

Diese Methode soll zwei BigInteger-Strings ziffernweise addieren und das Ergebnis als String zurückliefern.

- Parameter:
  - Ein String für den ersten Operanden
  - Ein String für den zweiten Operanden
- Rückgabewert:
- Die Summe als BigInteger-String

**Lösungsansatz:**

- Sorgen Sie dafür, dass beide Strings gleich lang sind (durch führende Nullen auf gleiche Länge bringen).
- Von der niedrigsten bis zur höchsten Stelle der Strings:
  - Jedes einzelne Zeichen auf eine Ziffer umwandeln.
  - Die beiden Ziffern addieren  und dabei einen allfälligen Übertrag aus der vorherigen Stelle berücksichtigen.
  - Die Einerstelle in den Ergebnisstring schreiben und die Zehnerstelle als Übertrag für die nächste Stelle aufheben.
- Achten Sie darauf, dass der Übertrag auch an der höchsten Stelle richtig berücksichtigt wird!

**Testen und Bildschirmausgabe:**

Testen Sie ihre Methoden im Hauptprogramm. Eine mögliche Bildschirmausgabe könnte wie folgt aussehen:

![Illustration](Task.002.png)

## Class Diagram

### Program (CD)

![Program (CD)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BigInteger.ConApp/diagrams/cd_Program.puml)

## Activity Diagrams

### Program.Main (AC)

![Program.Main (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BigInteger.ConApp/diagrams/ac_Program_Main.puml)

### Program.AddBigInteger (AC)

![Program.AddBigInteger (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BigInteger.ConApp/diagrams/ac_Program_AddBigInteger.puml)

### Program.AddLeadingCharacters (AC)

![Program.AddLeadingCharacters (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BigInteger.ConApp/diagrams/ac_Program_AddLeadingCharacters.puml)

### Program.ReadBigInteger (AC)

![Program.ReadBigInteger (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BigInteger.ConApp/diagrams/ac_Program_ReadBigInteger.puml)

### Program.IsBigNumber (AC)

![Program.IsBigNumber (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BigInteger.ConApp/diagrams/ac_Program_IsBigNumber.puml)

## Sequence Diagrams

### Program.Main (SQ)

![Program.Main (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BigInteger.ConApp/diagrams/sq_Program_Main.puml)

### Program.AddBigInteger (SQ)

![Program.AddBigInteger (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BigInteger.ConApp/diagrams/sq_Program_AddBigInteger.puml)

### Program.ReadBigInteger (SQ)

![Program.ReadBigInteger (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BigInteger.ConApp/diagrams/sq_Program_ReadBigInteger.puml)

### Program.IsBigNumber (SQ)

![Program.IsBigNumber (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BigInteger.ConApp/diagrams/sq_Program_IsBigNumber.puml)
