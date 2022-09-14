using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class PlayerCharacter : BaseCharacter
    {
        public PlayerCharacter(string name) : base(name)
        {
        }

        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }


        //TODO: Denna metod är för lång och rörig. Ska lösas på något annat sätt.
        public bool PerformCommand()
        {
            bool stop = false;
            Console.Write("Do something: ");
            string[] commandString = Console.ReadLine().ToLower().Split(' ');
            
           
            if ("north".StartsWith(commandString[0]))
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
            else if ("east".StartsWith(commandString[0]))
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
            else if ("south".StartsWith(commandString[0]))
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
            else if ("west".StartsWith(commandString[0]))
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
            else if ("quit".StartsWith(commandString[0]))
            {
                stop = true;
                SendMessage("Hejdå!");
            }
            else if ("attack".StartsWith(commandString[0]))
            {
                if(commandString.Length > 1)
                {
                    for (int i = 0; i < Position.Characters.Count; i++)
                    {
                        if (Position.Characters[i].Name.ToLower().StartsWith(commandString[1]))
                        {
                            stop = Fight(Position.Characters[i]);

                        }
                    }
                    
                }
                else
                {
                    SendMessage("Who do you want to attack?");
                }
            }
            else
            {
                SendMessage("Unknown command.");
            }


            return stop;
        }

        private bool Fight(BaseCharacter enemy)
        {
            SendMessage("Fight started!");
            return false;
        }
    }
}
