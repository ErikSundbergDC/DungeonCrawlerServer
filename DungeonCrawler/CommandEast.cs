using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandEast : BaseCommand
    {
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            if (playerCharacter.Position.ExitEast != null)
            {
                playerCharacter.Position = playerCharacter.Position.ExitEast;
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
