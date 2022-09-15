using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class PlayerCharacter : BaseCharacter
    {
        public List<BaseCommand> CommandList { get; private set; }

        public PlayerCharacter(string name) : base(name)
        {
            CommandList = new List<BaseCommand>();
            CommandList.Add(new CommandNorth());
            CommandList.Add(new CommandEast());
            CommandList.Add(new CommandSouth());
            CommandList.Add(new CommandWest());
            CommandList.Add(new CommandLook());
            CommandList.Add(new CommandQuit());
            CommandList.Add(new CommandAttack());
        }

        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }


        public bool PerformCommand()
        {
            bool stop = false;
            Console.Write("Do something: ");
            string[] commandString = Console.ReadLine().ToLower().Split(' ');
            
            foreach(BaseCommand command in CommandList)
            {
                if(command.GetType().Name.Substring(7).ToLower().StartsWith(commandString[0]))
                {
                    stop = command.Perform(this, commandString);
                }
                
            }

            return stop;
        }

        public bool Fight(BaseCharacter enemy)
        {
            SendMessage("Fight started!");
            Random random = new Random();
            int randomNumber = random.Next(4);
            bool playerDead = false;
            if(randomNumber == 0)
            {
                playerDead = true;
                SendMessage("You are dead!");
                SendMessage("GAME OVER");
            }
            else
            {
                Position.Characters.Remove(enemy);
                SendMessage(enemy.Name + " is dead!");
            }
            return playerDead;
        }
    }
}
