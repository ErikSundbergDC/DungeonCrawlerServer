using DungeonCrawler;

internal class Program
{
    private static void Main(string[] args)
    {
        World world = new World();

        Room startingRoom = world.StartingRoom;

        PlayerCharacter playerCharacter = new PlayerCharacter("Erik");
        playerCharacter.Position = startingRoom;
        playerCharacter.HealthPoints = 100;
        playerCharacter.MaxHealthPoints = 200;

        playerCharacter.Position.DisplayRoom(playerCharacter);

        bool stop = false;
        while (!stop)
        {
            stop = playerCharacter.PerformCommand();
        }
        
    }

}