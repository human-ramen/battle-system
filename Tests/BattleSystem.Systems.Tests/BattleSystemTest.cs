using System;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using Xunit;

namespace BattleSystem.Systems.Tests
{
    public class BattleSystemTest : IDisposable
    {
        private World _world;

        public BattleSystemTest()
        {
            _world = new WorldBuilder()
                .AddSystem(new BattleSystem())
                .Build();
        }

        [Fact]
        public void Scenario()
        {
            // TODO: BattleSystem scenario
            for (var i = 0; i < 900; ++i)
            {
                _world.Update(new GameTime());
            }

        }

        void IDisposable.Dispose()
        {
            _world.Dispose();
        }
    }
}
