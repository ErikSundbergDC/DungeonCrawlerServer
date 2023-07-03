using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandInventory : BaseCommand
    {
        public override string HelpText
        {
            get
            {
                return "Display all items that you are carrying.";
            }
        }

        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            playerCharacter.SendMessage("Inventory:");
            playerCharacter.SendMessage("");
            foreach (Item item in playerCharacter.Inventory)
            {
                playerCharacter.SendMessage(item.Name);
            }
            playerCharacter.SendMessage("");
            return false;
        }
    }
}
