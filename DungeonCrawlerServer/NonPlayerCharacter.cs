using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerServer
{
    public class NonPlayerCharacter : BaseCharacter
    {
        public NonPlayerCharacter(string name) : base(name)
        {
        }
        public NonPlayerCharacter(int id, string name) : base(id, name)
        {
        }
    }
}
