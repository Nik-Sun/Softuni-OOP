namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Knight knight = new Knight("gosho",17);
            MuseElf museElf = new MuseElf("pesho", 13);
            SoulMaster soulMaster = new SoulMaster("Meto",15);
            System.Console.WriteLine($"{knight}, {museElf}, {soulMaster}");
        }
    }
}