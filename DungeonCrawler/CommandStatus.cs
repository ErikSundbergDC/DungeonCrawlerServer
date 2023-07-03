using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandStatus : BaseCommand
    {
        public override string HelpText
        {
            get
            {
                return "Display your health and inventory status.";
            }
        }

        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            playerCharacter.SendMessage("");
            string healthStatus = "Health: " + playerCharacter.HealthPoints + "/" + playerCharacter.MaxHealthPoints;
            playerCharacter.SendMessage(healthStatus);
            string inventoryStatus = "Inventory: " + playerCharacter.InventoryWeight + "/" + playerCharacter.MaxInventoryWeight;
            playerCharacter.SendMessage(inventoryStatus);
            playerCharacter.SendMessage("");
            return false;
        }

    }
}
