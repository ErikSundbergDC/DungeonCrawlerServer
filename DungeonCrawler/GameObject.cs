using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class GameObject
    {
        public static int nextId = 0;
        public int Id { get; }

        public GameObject(int id)
        {
            Id = id;
            if(Id >= nextId)
            {
                nextId = Id + 1;
            }
        }

        public GameObject()
        {
            Id = nextId;
            nextId++;
        }
    }
}
