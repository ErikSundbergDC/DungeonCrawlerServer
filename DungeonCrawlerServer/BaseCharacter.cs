using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerServer
{
    public abstract class BaseCharacter : GameObject
    {
        public Room? Position { get; set; }

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

        public void Move(Room room)
        {
            if(Position != null)
            {
                Position.Characters.Remove(this);
            }
            Position = room;
            Position.Characters.Add(this);
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
