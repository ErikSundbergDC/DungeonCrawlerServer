using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class BaseCharacter
    {
        public Room? Position { get; set; }

        public string Name { get; set; }

        public int HealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }

        public BaseCharacter(string name)
        {
            Name = name;
        }

        public void Move(Room room)
        {
            Position = room;
        }
    }
}
