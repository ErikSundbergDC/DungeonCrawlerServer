using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandWest : BaseCommand
    {
        public override string HelpText
        {
            get
            {
                return "Move west.";
            }
        }
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            bool playerDead = false;
            if (playerCharacter.Position.ExitWest != null)
            {
                playerCharacter.Position.ExitWest.DisplayRoom(playerCharacter);
                playerDead = playerCharacter.Move(playerCharacter.Position.ExitWest);
            }
            else
            {
                playerCharacter.SendMessage("You can't go that way!");
            }
            return playerDead;
        }
    }
}
