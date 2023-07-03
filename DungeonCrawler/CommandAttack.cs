using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandAttack : BaseCommand
    {
        public override string HelpText
        {
            get
            {
                return "Attack someone. Type: attack <character name>";
            }
        }
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {

            bool stop = false;
            if (commandString.Length > 1)
            {
                for (int i = 0; i < playerCharacter.Position.Characters.Count; i++)
                {
                    if (playerCharacter.Position.Characters[i].Name.ToLower().StartsWith(commandString[1]))
                    {
                        stop = playerCharacter.Fight(playerCharacter.Position.Characters[i]);
                        return stop;
                    }
                }

                playerCharacter.SendMessage("You don't see " + commandString[1] + " here.");

            }
            else
            {
                playerCharacter.SendMessage("Who do you want to attack?");
            }
            return stop;
        }
    }
}
