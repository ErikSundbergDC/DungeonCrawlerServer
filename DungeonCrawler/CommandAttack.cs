using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandAttack : BaseCommand
    {

        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {

            bool stop = false;
            if (commandString.Length > 1)
            {
                foreach (BaseCharacter opponent in playerCharacter.Position.Characters)
                {
                    if (opponent.Name.ToLower().StartsWith(commandString[1]))
                    {
                        stop = playerCharacter.Fight(opponent);
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
