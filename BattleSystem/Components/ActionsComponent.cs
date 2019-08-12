using MonoGame.Extended.Entities;

namespace BattleSystem.Components
{
    public enum Nature
    {
        Attack,
        Damage,
        Wet,
        Heat,
        Poison,
        Coffee,
    }

    public class Action
    {
        public int Amount { get; set; }
        public Nature Nature { get; set; }

        public Action() { }

        public Action(int amount)
        {
            Amount = amount;
            Nature = Nature.Damage;
        }

        public Action(int amount, Nature nature)
        {
            Amount = amount;
            Nature = nature;
        }
    }

    public class ActionDoComponent
    {
        public Entity Target { get; set; }
        public Action Action { get; set; }

        public ActionDoComponent(Action action, Entity target)
        {
            Action = action;
            Target = target;
        }
    }

    public class BaseActionsComponent
    {
        public Action StartBattle = new Action();
    }

    public class SlugActionsComponent : BaseActionsComponent
    {
        public Action ThrowStapler = new Action(3);
        public Action DrinkCoffee = new Action(2, Nature.Coffee);
    }
}
