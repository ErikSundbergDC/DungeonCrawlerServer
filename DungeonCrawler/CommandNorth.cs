using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandNorth : BaseCommand
    {
        public override string HelpText
        {
            get
            {
                return "Move north.";
            }
        }
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            bool playerDead = false;
            if (playerCharacter.Position.ExitNorth != null)
            {
                playerCharacter.Position.ExitNorth.DisplayRoom(playerCharacter);
                playerDead = playerCharacter.Move(playerCharacter.Position.ExitNorth);
            }
            else
            {
                playerCharacter.SendMessage("You can't go that way!");
            }
            return playerDead;
        }
    }
}
