using TextGame.Factory.IFactory;
namespace TextGame
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterCreation();
            Adventure();
        }
        static void CharacterCreation()
        {
            NameTyping(SingletonObjects.Player);
            RaceSelecting(SingletonObjects.Player);
        }
        static void RaceSelecting(Player player)
        {
            bool raceselected=false;
            while (!raceselected)
            {
                Console.Clear();
                Console.WriteLine("Choose Your Race");
                Console.WriteLine("1-) Elf");
                Console.WriteLine("2-) Dwarf");
                char select=Console.ReadKey().KeyChar;
                switch (select)
                {
                    case '1':
                        player.Race=Race.Elf;
                        player.Strength=3;
                        player.Intelligence=7;
                        player.Weapon=(Weapon)SingletonObjects.Items.Single(X=>X.Name=="Starting Wand");
                        player.Armor=(Armor)SingletonObjects.Items.Single(X=>X.Name=="Starting Robe");
                        raceselected=true;
                        break;
                    case '2':
                        player.Race=Race.Dwarf;
                        player.Strength=7;
                        player.Intelligence=3;
                        player.Weapon=(Weapon)SingletonObjects.Items.Single(X=>X.Name=="Starting Sword");
                        player.Armor=(Armor)SingletonObjects.Items.Single(X=>X.Name=="Starting Armor");
                        raceselected=true;
                        break;
                    case '3':
                        player.Race=Race.Dwarf;
                        break;
                    default:
                        break;
                }
            }
        }
        static void NameTyping(Player player){

            string name;
            Console.WriteLine("Welcome To The Character Creation");
            while (player.Name==null)
            {
                Console.WriteLine("First Of Enter Your Name:");
                name=Console.ReadLine();
                if(name.Count()==0)
                {
                    Console.WriteLine("Enter A Name!");
                    continue;
                }
                Console.WriteLine(name+" Are you sure this is the name you want to choose press 1 for yes:");
                if(Console.ReadKey().KeyChar=='1'){
                    player.Name=name;
                }
                else{}
            }
        }
        static void Adventure()
        {
            SingletonObjects.Locations.ElementAt(new Random().Next(0,SingletonObjects.Locations.Count-1)).TriggerText();
        }
    }
}
