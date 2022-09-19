using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class BaseCommand
    {
		public string Name
		{
			get 
			{
				return GetType().Name.Substring(7).ToLower(); 
			}
		}

		public abstract bool Perform(PlayerCharacter playerCharacter, string[] commandString);
    }
}
