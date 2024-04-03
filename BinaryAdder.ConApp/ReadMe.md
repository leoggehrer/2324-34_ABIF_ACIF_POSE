# POSE

## POSE

### BinaryAdder, 3ABIF/3AKIF

Lehrziele

- Stringbearbeitung
- Methoden

#### Aufgabenstellung

Ihr Programm liest zwei (beliebig lange) Binärzahlen ein und addiert sie. Die Benutzerführung hat sich an der unten stehenden Vorgabe zu orientieren

![Illustration](Task.002.png)

Wird eine Fehleingabe gemacht, ist entsprechend zu reagieren:

![Illustration](Task.003.png)

**Hinweise:**

- Versuchen  Sie,  gleiche  Abläufe  in  Methoden  zu  strukturieren.  Das  Einlesen  einer  Dualzahl,  bis endlich eine korrekte Dualzahl eingegeben wurde, ist z.B. ein Fixkandidat für eine Methode, die für beide Dualzahlen verwendet werden kann.
- Die Addition wird einfacher, wenn zuvor beide Summanden auf gleiche Länge gebracht werden! Dazu muss der kürzere Summand mit führenden Nullen aufgefüllt werden.

**Erweiterungsoption:** Trennen Sie ganze Bytes bei der Ausgabe der Dualzahlen so, dass nach 8 Bits immer ein Leerzeichen folgt.

**Testvorgaben:**

|**Summand 1**  |**Summand 2**   |**Summe**       |
| -             | -              | -              |
|10101010101010 |101010101010101 |111111111111111 |
|1010           |111             |10001           |
|10110101       |10101           |11001010        |
|1010           |0               |1010            |

## Class Diagram

```plantUml
@startuml
Bob -> Alice : hello
@enduml
```

```plantuml
Bob -> Alice : hello
```

```plantuml
@startuml
title Program
 class Program #GhostWhite {
---
---
- {static} void Main(string[] args)
- {static} string FormatBinary(string number, int wide)
- {static} string AddBinaryNumbers(string number1, string number2)
- {static} string ShrinkNumber(string number)
- {static} string ExpandNumber(string number, int numberLength)
- {static} string ReadBinaryNumber(int number)
- {static} bool CheckBinaryNumber(string number)
- {static} bool IsBinaryDigit(char chr)
}
@enduml
```

### Test

![Program (CD)](diagrams/cd_Program.puml)

### Program (CD)

![Program (CD)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/cd_Program.puml)

## Activity Diagrams

### Program.Main (AC)

![Program.Main (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/ac_Program_Main.puml)

### Program.FormatBinary (AC)

![Program.FormatBinary (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/ac_Program_FormatBinary.puml)

### Program.AddBinaryNumbers (AC)

![Program.AddBinaryNumbers (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/ac_Program_AddBinaryNumbers.puml)

### Program.ShrinkNumber (AC)

![Program.ShrinkNumber (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/ac_Program_ShrinkNumber.puml)

### Program.ExpandNumber (AC)

![Program.ExpandNumber (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/ac_Program_ExpandNumber.puml)

### Program.ReadBinaryNumber (AC)

![Program.ReadBinaryNumber (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/ac_Program_ReadBinaryNumber.puml)

### Program.CheckBinaryNumber (AC)

![Program.CheckBinaryNumber (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/ac_Program_CheckBinaryNumber.puml)

### Program.IsBinaryDigit (AC)

![Program.IsBinaryDigit (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/ac_Program_IsBinaryDigit.puml)

## Sequence Diagrams

### Program.Main (SQ)

![Program.Main (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/sq_Program_Main.puml)

### Program.FormatBinary (SQ)

![Program.FormatBinary (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/sq_Program_FormatBinary.puml)

### Program.AddBinaryNumbers (SQ)

![Program.AddBinaryNumbers (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/sq_Program_AddBinaryNumbers.puml)

### Program.ShrinkNumber (SQ)

![Program.ShrinkNumber (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/sq_Program_ShrinkNumber.puml)

### Program.ReadBinaryNumber (SQ)

![Program.ReadBinaryNumber (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/sq_Program_ReadBinaryNumber.puml)

### Program.CheckBinaryNumber (SQ)

![Program.CheckBinaryNumber (SQ)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/BinaryAdder.ConApp/diagrams/sq_Program_CheckBinaryNumber.puml)
