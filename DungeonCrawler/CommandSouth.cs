using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandSouth : BaseCommand
    {
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            if (playerCharacter.Position.ExitSouth != null)
            {
                playerCharacter.Position = playerCharacter.Position.ExitSouth;
                playerCharacter.Position.DisplayRoom(playerCharacter);
            }
            else
            {
                playerCharacter.SendMessage("You can't go that way!");
            }

            return false;
        }
    }
}
