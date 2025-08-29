using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerServer
{
    public class PlayerCharacter : BaseCharacter
    {
        public List<BaseCommand> CommandList { get; private set; }

        public PlayerCharacter(string name) : base(name)
        {
            LoadCommandList();
        }
        public PlayerCharacter(int id, string name) : base(id, name)
        {
            LoadCommandList();
        }

        private void LoadCommandList()
        {
            CommandList = new List<BaseCommand>();
            CommandList.Add(new CommandEast());
            CommandList.Add(new CommandLook());
            CommandList.Add(new CommandAttack());

        }
        public override void SendMessage(string message)
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
            return false;
        }

    }
}
