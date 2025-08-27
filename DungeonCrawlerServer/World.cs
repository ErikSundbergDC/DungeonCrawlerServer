using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerServer
{
    public class World
    {
        public Room StartingRoom { get; private set; }
        public List<Room> rooms { get; }
        public World()
        {
            rooms = new List<Room>();
            Create();
        }

        private void Create()
        {
            rooms.Add(new Room("Trappuppgången", "En kall trappuppgång med en spiraltrappa som leder både upp och ner."));
            rooms.Add(new Room("Tamburen", "Det här är rummet direkt innanför ytterdörren. Det står en del möbler och skohyllor här. I den öppna spisen har någon slängt en elscooter."));
            rooms.Add(new Room("Korridoren", "En ganska vanlig skolkorridor."));
            rooms.Add(new Room("Korridoren utanför toaletterna", "En ganska vanlig skolkorridor."));
            rooms.Add(new Room("Korridoren utanför toaletterna", "En ganska vanlig skolkorridor."));
            rooms.Add(new Room("En toalett", "En vanlig offentlig toalett. Det är ganska trångt här inne."));
            rooms.Add(new Room("En toalett", "En vanlig offentlig toalett. Det är ganska trångt här inne."));
            rooms.Add(new Room("En handikapptoalett", "En vanlig offentlig toalett som är anpassad för funktionsvariationer. Det är gott om plats här inne."));
            rooms.Add(new Room("Hjärnkontoret höger", "Det här är normalt sett den främre delen av klassrummet. Fast ibland är det den bakre delen."));
            rooms.Add(new Room("Hjärnkontoret vänster", "Det här är normalt sett den bakre delen av klassrummet. Fast ibland är det den främre delen."));
            rooms.Add(new Room("Korridoren", "En ganska vanlig skolkorridor. Det finns elevskåp här."));
            rooms.Add(new Room("Korridoren", "En ganska vanlig skolkorridor. Det finns elevskåp här."));
            rooms.Add(new Room("Korridoren", "En ganska vanlig skolkorridor. Det finns elevskåp här."));
            rooms.Add(new Room("Ett grupprum", "Här kan elever stänga in sig för att utföra viktigt skolarbete i lugn och ro."));
            rooms.Add(new Room("Ett grupprum", "Här kan elever stänga in sig för att utföra viktigt skolarbete i lugn och ro."));
            rooms.Add(new Room("Ett arbetsrum", "Här sitter lärarna och softar i lugn och ro."));
            rooms.Add(new Room("Inre delen av arbetsrummet", "Här sitter lärarna och softar i lugn och ro."));
            rooms.Add(new Room("Ett förråd", "Här förvaras datorprylar."));
            rooms.Add(new Room("Ett förråd", "Här förvaras reklammaterial och andra grejer."));

            rooms[1].ExitEast = rooms[2];
            rooms[2].ExitWest = rooms[1];
            rooms[2].ExitEast = rooms[8];
            rooms[2].ExitSouth = rooms[3];
            rooms[2].ExitNorth = rooms[10];
            rooms[3].ExitNorth = rooms[2];
            rooms[3].ExitEast = rooms[5];
            rooms[3].ExitSouth = rooms[4];
            rooms[4].ExitNorth = rooms[3];
            rooms[4].ExitEast = rooms[6];
            rooms[4].ExitWest = rooms[7];
            rooms[5].ExitWest = rooms[3];
            rooms[6].ExitWest = rooms[4];
            rooms[7].ExitEast = rooms[4];
            rooms[8].ExitNorth = rooms[9];
            rooms[8].ExitWest = rooms[2];
            rooms[9].ExitWest = rooms[12];
            rooms[9].ExitSouth = rooms[8];
            rooms[10].ExitNorth = rooms[11];
            rooms[10].ExitSouth = rooms[2];
            rooms[10].ExitWest = rooms[13];
            rooms[11].ExitNorth = rooms[12];
            rooms[11].ExitSouth = rooms[10];
            rooms[11].ExitWest = rooms[14];
            rooms[12].ExitEast = rooms[9];
            rooms[12].ExitSouth = rooms[11];
            rooms[12].ExitWest = rooms[15];
            rooms[13].ExitEast = rooms[10];
            rooms[14].ExitEast = rooms[11];
            rooms[15].ExitNorth = rooms[17];
            rooms[15].ExitEast = rooms[12];
            rooms[15].ExitWest = rooms[16];
            rooms[16].ExitNorth = rooms[18];
            rooms[16].ExitEast = rooms[15];
            rooms[17].ExitSouth = rooms[15];
            rooms[18].ExitSouth = rooms[16];

            NonPlayerCharacter npc1 = new NonPlayerCharacter("Zombien Bob");
            npc1.HealthPoints = 25;
            npc1.MaxHealthPoints = 25;
            NonPlayerCharacter npc2 = new NonPlayerCharacter("Spöket Laban");
            npc2.HealthPoints = 3;
            npc2.MaxHealthPoints = 3;
            NonPlayerCharacter npc3 = new NonPlayerCharacter("Trollet Göran");
            npc3.HealthPoints = 10;
            npc3.MaxHealthPoints = 10;

            npc1.Move(rooms[1]);
            npc2.Move(rooms[5]);
            npc3.Move(rooms[7]);
            

            StartingRoom = rooms[1];
        }
    }
}
