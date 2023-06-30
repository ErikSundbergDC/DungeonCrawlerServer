using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandQuit : BaseCommand
    {
        public override string HelpText
        {
            get
            {
                return "Quit the game.";
            }
        }
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            playerCharacter.SendMessage("Hejdå!");
            return true;
        }
    }

    public class CommandExit : CommandQuit
    {

    }
}
