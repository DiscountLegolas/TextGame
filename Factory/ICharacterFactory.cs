using TextGame;
namespace TextGame.Factory.IFactory
{
    public interface ICharacterFactory
    {
        public Character CreateCharacter(Race race,bool warrior);
        public Character CreateCharacter(string name,Race race,int Health,int strength,int intelligence,Armor armor,Weapon weapon);
        public void TextOnCreate(Character character);
    }
    public class EnemyCharacterFactory:ICharacterFactory
    {
        private void CreateMageCharacter(Enemy enemy)
        {
            List<Item> possiblearmors=SingletonObjects.Items.Where(x=>x.GetType().Name=="Armor").Where(x=>{
                var b=(Armor)x;
                return (b.MagicalProtection-b.PhysicalProtection)>=1;
            }).ToList();
            List<Item> possibleweapons=SingletonObjects.Items.Where(x=>x.GetType().Name=="Weapon").Where(x=>{
                var b=(Weapon)x;
                return (b.BaseMagicalDamage-b.BasePhysicalDamage)>=1;
            }).ToList();
            enemy.Armor=(Armor)possiblearmors.ElementAt(new Random().Next(0,possiblearmors.Count-1));
            enemy.Weapon=(Weapon)possibleweapons.ElementAt(new Random().Next(0,possiblearmors.Count-1));
            enemy.Health=20;
            enemy.Strength=2;
            enemy.Intelligence=6;
        }
        private void CreateWarriorCharacter(Enemy enemy)
        {
            List<Item> possiblearmors=SingletonObjects.Items.Where(x=>x.GetType().Name=="Armor").Where(x=>{
                var b=(Armor)x;
                return (b.PhysicalProtection-b.MagicalProtection)>=1;
            }).ToList();
            List<Item> possibleweapons=SingletonObjects.Items.Where(x=>x.GetType().Name=="Weapon").Where(x=>{
                var b=(Weapon)x;
                return (b.BasePhysicalDamage-b.BaseMagicalDamage)>=1;
            }).ToList();
            enemy.Armor=(Armor)possiblearmors.ElementAt(new Random().Next(0,possiblearmors.Count-1));
            enemy.Weapon=(Weapon)possibleweapons.ElementAt(new Random().Next(0,possiblearmors.Count-1));
            enemy.Health=20;
            enemy.Strength=6;
            enemy.Intelligence=2;
        }
        public Character CreateCharacter(Race race,bool warrior)
        {
            Enemy enemy=new Enemy(race);
            if (warrior)
            {
                CreateWarriorCharacter(enemy);
                enemy.Name=(race.ToString()+" Warrior");
                return enemy;
            }
            else
            {
                CreateMageCharacter(enemy);
                enemy.Name=(race.ToString()+" Mage");
                return enemy;
            }
        }
        public Character CreateCharacter(string name,Race race,int Health,int strength,int intelligence,Armor armor,Weapon weapon)
        {
            Character character=new Enemy(race,Health,name,strength,intelligence);
            character.Armor=armor;
            character.Weapon=weapon;
            return character;
        }
        public void TextOnCreate(Character character){
            Console.WriteLine(character.Name);
        }
    }
}