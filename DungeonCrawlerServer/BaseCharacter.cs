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

        public void Move(Room room)
        {
            if(Position != null)
            {
                Position.Characters.Remove(this);
            }
            Position = room;
            Position.Characters.Add(this);
        }

    }
}
