namespace TextGame
{
    public class PossibleAction
    {
        public string ActionDescription {get;set;}
        public Action Action {get;set;}
        public PossibleAction(Action action)
        {
            Action=action;
        }
        public PossibleAction(string desc,Action action)
        {
            Action=action;
            ActionDescription=desc;
        }
    }
}