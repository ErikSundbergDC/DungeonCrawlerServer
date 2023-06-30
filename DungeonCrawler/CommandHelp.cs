using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandHelp : BaseCommand
    {
        public override string HelpText
        {
            get
            {
                return "Display help for all commands.";
            }
        }

        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            if(commandString == null || commandString.Count() < 2)
            {
                DisplayAll(playerCharacter);
            }
            else
            {
                DisplaySingle(playerCharacter, commandString[1]);
            }
            return false;
        }

        private void DisplayAll(PlayerCharacter playerCharacter)
        {
            playerCharacter.SendMessage("Help for all commands:");
            playerCharacter.SendMessage("");
            foreach (BaseCommand command in playerCharacter.CommandList)
            {
                playerCharacter.SendMessage(command.Name + ": " + command.HelpText);
            }
            playerCharacter.SendMessage("");
        }
        private void DisplaySingle(PlayerCharacter playerCharacter, string commandName)
        {
            BaseCommand command = playerCharacter.FindCommand(commandName);
            
            playerCharacter.SendMessage(command.Name + ": " + command.HelpText);
            playerCharacter.SendMessage("");
        }
    }
}
