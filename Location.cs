namespace TextGame
{
    public class Location
    {
        Random random=new Random();
        public Location(string choosingdesc,string desc)
        {
            this.ChoosingDescription=choosingdesc;
            this.Description=desc;
            this.PossibleActions=new List<PossibleAction>();
            this.Characters=new List<Character>();
            this.Items=new List<Item>();
        }
        private List<Location> possiblelocations;
        public List<Location> PossibleLocations
        {
            get
            {
                if (possiblelocations==null)
                {
                    
                    possiblelocations=SingletonObjects.Locations.OrderBy(c=>random.Next()).Take(random.Next(2,3)).ToList();
                }
                return possiblelocations;
            }
        }
        public string Description {get;set;}
        public string ChoosingDescription {get;set;}
        public List<Character> Characters {get;set;}
        public List<Item> Items {get;set;}
        public List<PossibleAction> PossibleActions {get;set;} 
        public void TriggerText()
        {
            List<Enemy> enemies=new List<Enemy>();
            Characters.Where(x=>x.GetType().Name=="Enemy").ToList().ForEach(x=>{
                enemies.Add((Enemy)x);
            });
            this.PossibleLocations.ForEach(x=>{
                PossibleAction action=new PossibleAction(x.ChoosingDescription,()=>{
                    x.TriggerText();
                });
                PossibleActions.Add(action);
            });
            Console.WriteLine(Description);
            //Automatic combat Code begin
            if (enemies.Count()!=0)
            {
                while (SingletonObjects.Player.Health>0&&enemies.Any(x=>x.Health>0))
                {
                    int enemyindex=random.Next(0,enemies.Count-1);
                    SingletonObjects.Player.DeliverDamage(enemies[enemyindex],random.Next(1,6));
                    foreach (Enemy enemy in enemies.Where(x=>x.Health>0))
                    {
                        if (SingletonObjects.Player.Health>0)
                        {
                            enemy.DeliverDamage(SingletonObjects.Player,random.Next(1,6));
                        }
                    }
                    Console.ReadKey();
                }
                Console.ReadKey();
            }
            //end
            if (SingletonObjects.Player.Health<=0) {Environment.Exit(0);}
            for (int i = 0; i < PossibleActions.Count; i++)
            {
                Console.WriteLine((i+1)+"-) go towards"+PossibleActions[i].ActionDescription);
            }
            int selectedint;
            bool parse=int.TryParse(Console.ReadLine(),out selectedint);
            if (parse&&(selectedint>=1||selectedint<=PossibleActions.Count))
            {
                PossibleActions[selectedint-1].Action();
                this.PossibleActions.Clear();
            }
        }
    }
}