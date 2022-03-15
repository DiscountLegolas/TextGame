namespace TextGame
{
    public enum Race
    {
        Elf,
        Dwarf
    }
    public class Player:Character
    { 
        public Player()
        {
            ItemBag=new List<Item>();
            Money=20;
            Health=new Random().Next(25,50);
        }
        public float Money{get;set;}
        List<Item> ItemBag{get;set;}
        public void ChangeItem(Item currentıtem,Item newItem)
        {
            ItemBag.Add(currentıtem);
            ItemBag.Remove(newItem);
            currentıtem=newItem;
        }
        public void BuyItem(Item buyedıtem)
        {
            if (buyedıtem.BuyPrice<=Money)
            {
                Money-=buyedıtem.BuyPrice;
                ItemBag.Add(buyedıtem);
            }
            else
            {
                
            }
        }
        public void SellItem(Item selledıtem)
        {
            Money+=selledıtem.SellPrice;
            ItemBag.Remove(selledıtem);
        }
    }
    public abstract class Character
    {
        public Race Race {get;set;}
        public int Health {get;set;}
        public int Strength{get;set;}
        public int Intelligence{get;set;}
        public string Name{get;set;}
        public float DeliverDamage(Character enemy,int roll)
        {
            var damage=(((Weapon.BasePhysicalDamage*Strength)-enemy.Armor.PhysicalProtection)+((Weapon.BaseMagicalDamage*Intelligence)-enemy.Armor.MagicalProtection))*roll/6.0F;
            Console.WriteLine(Name+" delivered "+damage+" damage to "+enemy.Name);
            enemy.Health-=((int)damage);
            if (enemy.Health<=0)
            {
                Console.WriteLine(enemy.Name+" is dead");
            }
            return damage;
        }
        public Armor Armor {get;set;}
        public Weapon Weapon {get;set;}
    }
    public class Enemy:Character
    {
        public Enemy(Race race)
        {
            this.Race=race;
        }
        public Enemy(Race race,int health,string name,int strength,int ıntelligence)
        {
            Race=race;
            Health=health;
            Name=name;
            Strength=strength;
            Intelligence=ıntelligence;
        }
    }
}