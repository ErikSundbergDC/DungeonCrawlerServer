using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerServer
{
    public class Room : GameObject
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        //Frågetecknet efter Room gör att propertyn blir "nullable", dvs den kan vara null utan att vi får varningar i programkoden.
        public Room? ExitNorth { get; set; }
        public Room? ExitEast { get; set; }
        public Room? ExitSouth { get; set; }
        public Room? ExitWest { get; set; }

        public List<BaseCharacter> Characters { get; }

        public Room(string name, string description) : base()
        {
            Name = name;
            Description = description;
            Characters = new List<BaseCharacter>();
        }
        public Room(int id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
            Characters = new List<BaseCharacter>();
        }

        //TODO: Dela upp DisplayRoom i mindre metoder.
        public void DisplayRoom(PlayerCharacter playerCharacter)
        {
            playerCharacter.SendMessage("");
            playerCharacter.SendMessage(Name);

            string underLine = "";
            for (int i = 0; i < Name.Length; i++)
            {
                underLine += "~";
            }
            playerCharacter.SendMessage(underLine);
            playerCharacter.SendMessage("");
            playerCharacter.SendMessage(Description);
            playerCharacter.SendMessage("");

            foreach(BaseCharacter character in Characters)
            {
                if (character != playerCharacter)
                {
                    string charStr = character.Name + " is here.";
                    playerCharacter.SendMessage(charStr);
                }
            }

            playerCharacter.SendMessage("");
            playerCharacter.SendMessage("Exits:");

            string exits = "";
            if(ExitNorth != null)
            {
                exits += "North ";
            }
            if (ExitEast != null)
            {
                exits += "East ";
            }
            if (ExitSouth != null)
            {
                exits += "South ";
            }
            if (ExitWest != null)
            {
                exits += "West ";
            }

            playerCharacter.SendMessage(exits);
            playerCharacter.SendMessage("");
            
        }
    }
}
