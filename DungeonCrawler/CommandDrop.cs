using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandDrop : BaseCommand
    {
        public override string HelpText
        {
            get
            {
                return "Drop an item in your inventory to the ground. Type: drop <item name>";
            }
        }
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {

            if (commandString.Length > 1)
            {
                for (int i = 0; i < playerCharacter.Inventory.Count; i++)
                {
                    Item item = playerCharacter.Inventory[i];
                    if (item.Name.ToLower().StartsWith(commandString[1]))
                    {
                        playerCharacter.DropItem(item);
                        playerCharacter.SendMessage("You drop " + item.Name + ".");
                        return false;
                    }
                }

                playerCharacter.SendMessage("You don't have " + commandString[1] + " in your inventory.");
            }
            else
            {
                playerCharacter.SendMessage("What do you want to drop?");
            }
            return false;
        }
    }
}
