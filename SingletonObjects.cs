using TextGame.Factory.IFactory;
namespace TextGame
{
    public class SingletonObjects
    {
        private static IEnumerable<Character> GetEnemyGroup()
        {
            List<Character> characters=new List<Character>();
            characters.Add(EnemyCharacterFactory.CreateCharacter(Race.Elf,true));
            characters.Add(EnemyCharacterFactory.CreateCharacter(Race.Elf,true));
            characters.Add(EnemyCharacterFactory.CreateCharacter(Race.Elf,false));
            return characters;
        }
        private static List<Location> locations;
        public static List<Location> Locations
        {
            get
            {
                if (locations==null)
                {
                    locations=new List<Location>();
                    locations.Add(new Location("Choosing Desc","Desc"));
                    locations.Add(new Location("Choosing Desc","Desc"));
                    locations.Add(new Location("Choosing Desc","Desc"));
                    locations.Add(new Location("Choosing Desc","Desc"));
                    locations.Add(new Location("Choosing Desc","Desc"));
                    locations.Add(new Location("Choosing Desc","Desc"));
                    locations.Add(new Location("Choosing Desc","Desc"));
                    locations.Add(new Location("Choosing Desc","Desc"));
                    locations.ForEach(x=>{
                        x.Characters.AddRange(GetEnemyGroup());
                    });
                }
                return locations;
            }
        }
        private static List<Item> ıtems;
        public static List<Item> Items
        {
            get
            {
                if (ıtems==null)
                {
                    ıtems=new List<Item>();
                    ıtems.Add(new Weapon("Starting Wand",2,4));
                    ıtems.Add(new Armor("Starting Robe",2,3));
                    ıtems.Add(new Weapon("Average Wand",2,5));
                    ıtems.Add(new Armor("Average Robe",2,4));
                    ıtems.Add(new Weapon("Starting Sword",4,2));
                    ıtems.Add(new Armor("Starting Armor",3,2));
                    ıtems.Add(new Weapon("Average Sword",5,2));
                    ıtems.Add(new Armor("Average Armor",4,2));
                }
                return ıtems;
            }
        }
        private static Player player;
        public static Player Player
        {
            get
            {
                if (player==null)
                {
                    player=new Player();
                }
                return player;
            }
        }
        private static EnemyCharacterFactory enemycharacterfactory;
        public static EnemyCharacterFactory EnemyCharacterFactory
        {
            get
            {
                if (enemycharacterfactory==null)
                {
                    enemycharacterfactory=new EnemyCharacterFactory();
                }
                return enemycharacterfactory;
            }
        }
    }
}