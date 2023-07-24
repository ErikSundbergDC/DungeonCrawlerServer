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

        public List<Item> Inventory { get; }
        public int InventoryWeight
        {
            get
            {
                int weight = 0;
                foreach (Item item in Inventory)
                {
                    weight += item.Weight;
                }
                return weight;
            }
        }
        public int MaxInventoryWeight { get; set; }

        public int HealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }

        public BaseCharacter(string name)
        {
            Name = name;
            Inventory = new List<Item>();
        }

        public void Move(Room room)
        {
            Position = room;
        }

        public void GetItemFromRoom(Item item)
        {
            if(Position.Items.Contains(item))
            {
                if(InventoryWeight + item.Weight > MaxInventoryWeight)
                {
                    throw new Exception("That is too heavy for you to carry.");
                }
                Inventory.Add(item);
                Position.Items.Remove(item);
            }
            else
            {
                throw new Exception("Room does not contain item.");
            }
        }

        public void DropItem(Item item)
        {
            if (Inventory.Contains(item))
            {
                Position.Items.Add(item);
                Inventory.Remove(item);
            }
            else
            {
                throw new Exception("Inventory does not contain item.");
            }
        }
    }
}
