namespace TextGame
{
  public class Armor:Item
  {
    public int PhysicalProtection {get;set;}
    public int MagicalProtection {get;set;}
    public Armor(string name,int physicalprotection,int magicalprotection)
    {
      Name=name;
      PhysicalProtection=physicalprotection;
      MagicalProtection=magicalprotection;
    }
  }
}