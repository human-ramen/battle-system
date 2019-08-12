namespace BattleSystem.Components
{
    public class TurnComponent
    {
        public enum Turn
        {
            Unknown,
            Player,
            Ai,
        }

        public Turn State { get; set; }
    }
}
