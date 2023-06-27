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
            bool playerDead = false;
            if (playerCharacter.Position.ExitEast != null)
            {
                playerCharacter.Position.ExitEast.DisplayRoom(playerCharacter);
                playerDead = playerCharacter.Move(playerCharacter.Position.ExitEast);
            }
            else
            {
                playerCharacter.SendMessage("You can't go that way!");
            }
            return playerDead;
        }
    }
}
