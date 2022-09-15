using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandWest : BaseCommand
    {
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            if (playerCharacter.Position.ExitWest != null)
            {
                playerCharacter.Position = playerCharacter.Position.ExitWest;
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
