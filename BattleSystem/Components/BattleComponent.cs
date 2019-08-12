using System.Collections.Generic;
using MonoGame.Extended.Entities;

namespace BattleSystem.Components
{
    public class BattleComponent
    {
        public List<Entity> Enemies { get; set; }
        public Entity Player { get; set; }

        public BattleComponent(List<Entity> enemies, Entity player)
        {
            Enemies = enemies;
            Player = player;
        }
    }
}
