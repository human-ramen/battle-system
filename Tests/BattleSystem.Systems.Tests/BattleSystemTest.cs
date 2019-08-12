using System;
using Xunit;
using MonoGame.Extended.Entities;
using Microsoft.Xna.Framework;
using BattleSystem.Components;
using System.Collections.Generic;
using static BattleSystem.Components.TurnComponent;

namespace BattleSystem.Systems.Tests
{
    public class BattleSystemTest : IDisposable
    {
        private World _world;

        public BattleSystemTest()
        {
            _world = new WorldBuilder()
                .AddSystem(new AiSystem())
                .AddSystem(new ActionDoSystem())
                .AddSystem(new TurnSystem())
                .AddSystem(new BattleSystem())
                .Build();
        }

        [Fact]
        public void Scenario()
        {
            var player = _world.CreateEntity();
            player.Attach(new PlayerComponent());
            player.Attach(new StatusComponent());
            player.Attach(new PropComponent());

            var playerActions = new SlugActionsComponent();

            player.Attach(playerActions);


            var enemies = new List<Entity>();

            for (var i = 0; i < 10; ++i)
            {
                var enemy = _world.CreateEntity();
                enemy.Attach(new StatusComponent());
                enemy.Attach(new PropComponent());
                enemy.Attach(new SlugActionsComponent());

                enemies.Add(enemy);
            }

            var battle = _world.CreateEntity();
            battle.Attach(new BattleComponent(enemies, player));

            // TODO: BattleSystem scenario
            for (var i = 0; i < 20; ++i)
            {
                _world.Update(new GameTime());

                var turn = battle.Get<TurnComponent>();
                if (turn != null && turn.State == Turn.Player)
                {
                    battle.Attach(new ActionDoComponent(playerActions.DrinkCoffee, player));
                    battle.Attach(new TurnEndComponent());
                }
            }

        }

        void IDisposable.Dispose()
        {
            _world.Dispose();
        }
    }
}
