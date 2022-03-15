namespace TextGame
{
  public class Weapon:Item
  {
    public int BasePhysicalDamage {get;set;}
    public int BaseMagicalDamage {get;set;}
    public Weapon(string name,int physicaldamage,int magicaldamage)
    {
      Name=name;
      BasePhysicalDamage=physicaldamage;
      BaseMagicalDamage=magicaldamage;
    }
  }
}