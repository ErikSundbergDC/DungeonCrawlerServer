using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandGet : BaseCommand
    {
        public override string HelpText
        {
            get
            {
                return "Pick up an item that lies in the room. Type: get <item name>";
            }
        }
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {

            if (commandString.Length > 1)
            {
                for (int i = 0; i < playerCharacter.Position.Items.Count; i++)
                {
                    Item item = playerCharacter.Position.Items[i];
                    if (item.Name.ToLower().StartsWith(commandString[1]))
                    {
                        playerCharacter.GetItemFromRoom(playerCharacter.Position.Items[i]);
                        playerCharacter.SendMessage("You pick up " + item.Name + ".");
                        return false;
                    }
                }

                playerCharacter.SendMessage("You don't see " + commandString[1] +  " here.");
            }
            else
            {
                playerCharacter.SendMessage("What do you want to get?");
            }
            return false;
        }
    }
}
