using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandCommands : BaseCommand
    {
        public override string HelpText
        {
            get
            {
                return "Display a list of all commands.";
            }
        }
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            playerCharacter.SendMessage("Available commands:");
            playerCharacter.SendMessage("");
            foreach (BaseCommand command in playerCharacter.CommandList)
            {
                playerCharacter.SendMessage(command.Name);
            }
            playerCharacter.SendMessage("");
            return false;
        }
    }

}
