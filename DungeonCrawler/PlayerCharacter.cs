using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class PlayerCharacter
    {
        public Room Position { get; set; }

        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }


        //TODO: Denna metod är för lång och rörig. Ska lösas på något annat sätt.
        public void PerformCommand()
        {
            Console.Write("Do something: ");
            string commandString = Console.ReadLine().ToLower();

            //TODO: Inget kommando alls tolkas som "north".
            if ("north".StartsWith(commandString))
            {
                if (Position.ExitNorth != null)
                {
                    Position = Position.ExitNorth;
                    Position.DisplayRoom(this);
                }
                else
                {
                    SendMessage("You can't go that way!");
                }
            }
            else if ("east".StartsWith(commandString))
            {
                if (Position.ExitEast != null)
                {
                    Position = Position.ExitEast;
                    Position.DisplayRoom(this);
                }
                else
                {
                    SendMessage("You can't go that way!");
                }
            }
            else if ("south".StartsWith(commandString))
            {
                if (Position.ExitSouth != null)
                {
                    Position = Position.ExitSouth;
                    Position.DisplayRoom(this);
                }
                else
                {
                    SendMessage("You can't go that way!");
                }
            }
            else if ("west".StartsWith(commandString))
            {
                if (Position.ExitWest != null)
                {
                    Position = Position.ExitWest;
                    Position.DisplayRoom(this);
                }
                else
                {
                    SendMessage("You can't go that way!");
                }
            }
            else
            {
                SendMessage("Unknown command.");
            }


        }
    }
}
