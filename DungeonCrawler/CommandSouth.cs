using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandSouth : BaseCommand
    {
        public override string HelpText
        {
            get
            {
                return "Move south.";
            }
        }
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            bool playerDead = false;
            if (playerCharacter.Position.ExitSouth != null)
            {
                playerCharacter.Position.ExitSouth.DisplayRoom(playerCharacter);
                playerDead = playerCharacter.Move(playerCharacter.Position.ExitSouth);
            }
            else
            {
                playerCharacter.SendMessage("You can't go that way!");
            }
            return playerDead;
        }
    }
}
