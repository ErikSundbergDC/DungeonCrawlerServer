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
            CommandList.Add(new CommandHelp());
            CommandList.Add(new CommandInventory());
            CommandList.Add(new CommandGet());
            CommandList.Add(new CommandDrop());
            CommandList.Add(new CommandStatus());
        }

        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }

        private void PromptMessage(string message)
        {
            Console.Write(message);
        }

        // This method waits for user input. Maybe possible to do it asynchronous?
        private string[] GetCommand()
        {
            string? command = Console.ReadLine();
            if (command != null && command.Length > 0)
            {
                return command.ToLower().Split(' ');
            }
            else
            {
                throw new Exception("That is not a valid command!");
            }
        }
        public bool PerformCommand()
        {
            bool stop = false;
            PromptMessage("Do something: ");

            try
            {
                string[] commandString = GetCommand();
                BaseCommand command = FindCommand(commandString[0]);
                stop = command.Perform(this, commandString);
            }
            catch (Exception e)
            {
                SendMessage(e.Message);
            }

            return stop;
        }

        public BaseCommand FindCommand(string commandString)
        {
            foreach (BaseCommand command in CommandList)
            {
                if (command.Name.StartsWith(commandString))
                {
                    return command;
                }
            }
            //No command found
            throw new Exception("That is not a valid command!");
        }

        public new bool Move(Room room)
        {
            base.Move(room);
            
            return FightAggressiveCharacters();
        }

        private bool FightAggressiveCharacters()
        {
            List<BaseCharacter> aggresives = Position.AggressiveCharacters;
            //Loop through all aggressive characters in the room and fight them until they all are killed or the player dies.
            foreach(BaseCharacter character in aggresives)
            {
                bool playerDead = Fight(character);
                if (playerDead)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Fight(BaseCharacter enemy)
        {
            SendMessage("Fight started!");
            Random random = new Random();
            int randomNumber = random.Next(4);
            bool playerDead = false;
            if (randomNumber == 0)
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
