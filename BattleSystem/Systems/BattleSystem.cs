using BattleSystem.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace BattleSystem.Systems
{
    public class BattleSystem : EntityUpdateSystem
    {
        private enum turn
        {
            unknown,
            player,
            enemy,
        }

        private turn _turn;

        private ComponentMapper<PlayerComponent> _playerMapper;
        private ComponentMapper<PropComponent> _propMapper;
        private ComponentMapper<StatusComponent> _statusMapper;

        public BattleSystem() : base(Aspect.All(typeof(BattleComponent)))
        {

        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _playerMapper = mapperService.GetMapper<PlayerComponent>();
            _propMapper = mapperService.GetMapper<PropComponent>();
            _statusMapper = mapperService.GetMapper<StatusComponent>();

            // TODO: turn logic.

            _turn = turn.player;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var entity in ActiveEntities)
            {
                if (isPlayer(entity) && isPlayerTurn())
                {
                    playerBehavior(entity);
                }
                else if (!isPlayer(entity) && isEnemyTurn())
                {
                    enemyBehavior(entity);
                }
            }

        }

        private void playerBehavior(int entity)
        {
            // TODO: player doing something
        }

        private void enemyBehavior(int entity)
        {
            // TODO: enemy doing something
        }

        private bool isPlayer(int entity)
        {
            return _playerMapper.Has(entity);
        }

        private bool isPlayerTurn()
        {
            return _turn == turn.player;
        }

        private bool isEnemyTurn()
        {
            return _turn == turn.enemy;
        }
    }
}
