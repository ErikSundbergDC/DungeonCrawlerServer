using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerServer
{
    public abstract class BaseCharacter : GameObject
    {
        private Room? position;
        public Room? Position
        {
            get
            {
                return position;
            }
            set
            {
                if (position != null)
                {
                    position.Characters.Remove(this);
                }
                position = value;
                position.Characters.Add(this);
            }
        }
        public string Name { get; set; }


        public int HealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }

        public BaseCharacter(string name) : base()
        {
            Name = name;
        }
        public BaseCharacter(int id, string name) : base(id)
        {
            Name = name;
        }

        public virtual void SendMessage(string message)
        {
            //Default is do nothing when a character gets a message.
        }

     

        public bool Fight(BaseCharacter enemy)
        {
            SendMessage("You attack " + enemy.Name + "!");
            enemy.SendMessage("You have been attacked by " + this.Name + "!");

            Random random = new Random();
            int randomNumber = random.Next(4);
            bool playerDead = false;
            if (randomNumber == 0)
            {
                SendMessage(enemy.Name + " hits you very hard!");
                enemy.SendMessage("You hit " + this.Name + " very hard!");
                playerDead = true;
                SendMessage("You are dead!");
                enemy.SendMessage(this.Name + " is dead!");
                SendMessage("GAME OVER");

            }
            else
            {
                SendMessage("You hit " + enemy.Name + " very hard!");
                enemy.SendMessage(this.Name + " hits you very hard!");
                enemy.SendMessage("You are dead!");
                SendMessage(enemy.Name + " is dead!");
                enemy.SendMessage("GAME OVER");
                Position.Characters.Remove(enemy);
            }
            return playerDead;
        }


    }
}
