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
            CommandList.Add(new CommandExit());
            CommandList.Add(new CommandCommands());
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

            try
            {
                BaseCommand command = FindCommand(commandString[0]);
                stop = command.Perform(this, commandString);
            }
            catch(Exception e)
            {
                SendMessage(e.Message);
            }

                       
            return stop;
        }

        private BaseCommand FindCommand(string commandString)
        {
            if (commandString.Length > 0)
            {
                foreach (BaseCommand command in CommandList)
                {
                    if (command.Name.StartsWith(commandString))
                    {
                        return command;
                    }
                }
            }
            //No command found
            throw new Exception("That is not a valid command!");
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
