# POSE

## MobilePhone

Lehrziele:

- Einfache Klassen
- Properties
- Konstruktoren mit Überladung

Realisieren Sie eine einfache Klasse MobilePhone, die folgende wichtige Daten und das Verhalten eines Mobiltelefons abbildet:

Folgende **private Felder** sind zu verwalten:

```csharp
string _phoneNumber       // eigene Telefonnummer
string _name              // Name
string _lastCalledNumber  // zuletzt gewählte Rufnummer
int _secondsActive        // Summe der Gesprächssekunden als Anrufer
int _secondsPassive       // Summe der Gesprächssekunden als Angerufener
int _centsToPay           // Aktueller Stand der Telefonrechnung, wenn die Minute 8 Cent kostet, 
                          // und jede halbe begonnene Minute verrechnet wird
```

Der **Konstruktor** ist wie folgt zu überladen, ohne Codeverdopplung (Verkettung) zu erzeugen:

```csharp
Mobile(string phoneNumber)
Mobile(string phoneNumber, string name)
```

Über **Properties** wird wie folgt zugegriffen:

```csharp
string PhoneNumber        // eigene Telefonnummer (nur lesend)
string LastCalledNumber   // zuletzt gewählte Rufnummer (nur lesend)
string Name               // Lesend und schreibend (Name muss mindestens zwei Zeichen lang sein 
                          // und mit einem Buchstaben beginnen, sonst wird im Namen ERROR gespeichert)
int SecondsActive         // Berechnetes Property, das ausgibt, wie viele Sekunden in Summe als Anrufer telefoniert wurde
int SecondsPassive        // Berechnetes Property, das ausgibt, wie viele Sekunden in Summe als Angerufener telefoniert wurde
int CentsToPay            // aktuelle Telefonkosten
```

Als einfaches Basisverhalten soll es möglich sein, dass ein MobilePhone zu einem anderen MobilePhone ein Gespräch aufbaut (anruft). Damit beginnt die Gesprächszeit beim Anrufer und beim Angerufenen zu laufen (ausgehend von DateTime.Now wird die Gesprächsdauer in Sekunden, mit 20 multipliziert, damit längere Zeiten entstehen). Nach Beendigung des Gesprächs wird die Gesprächsdauer ermittelt 

```csharp
int seconds = (int)((DateTime.Now-lastStartTime).TotalSeconds * 20);
```

dann beim Anrufer und beim Angerufenen verbucht. Beim Anrufer sind auch noch die Kosten für das Gespräch zu verbuchen.

Dafür sind folgende **Methoden** zu realisieren:

```csharp
public bool StartCallTo(Mobile passive) // Anruf zu MobilePhone passive starten. Ab jetzt läuft die Gesprächszeit für beide
                                        // Seiten (aktive und passive Gesprächszeit). 
                                        // Wenn sich einer der beiden Gesprächspartner bereits in einem Gespräch befindet, 
                                        // kann kein neues Gespräch aufgebaut werden und es wird **false** zurückgeliefert. 
                                        // Bei erfolgreichem Gesprächsaufbau wird **true** zurückgeliefert.
public bool StopCall()                  // beendet das Gespräch (egal ob ankommend oder abgehend) und zählt die Sekunden hoch. 
                                        // Die Methode gibt im Fehlerfall (wenn derzeit kein Gespräch besteht) false zurück, 
                                        // sonst true.
```

Ihre Aufgabe ist es, die Methoden so zu implementieren, dass **alle Testfälle positiv** beurteilt werden.

## Activity Diagrams

### MobilePhone.StartCallTo (AC)

![MobilePhone.StartCallTo (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/MobilePhone.Logic/diagrams/ac_MobilePhone_StartCallTo.puml)

### MobilePhone.StartCallFrom (AC)

![MobilePhone.StartCallFrom (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/MobilePhone.Logic/diagrams/ac_MobilePhone_StartCallFrom.puml)

### MobilePhone.StopCall (AC)

![MobilePhone.StopCall (AC)](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/leoggehrer/2324-34_ABIF_ACIF_POSE/master/MobilePhone.Logic/diagrams/ac_MobilePhone_StopCall.puml)
