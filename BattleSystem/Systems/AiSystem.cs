using BattleSystem.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using static BattleSystem.Components.TurnComponent;

namespace BattleSystem.Systems
{
    /// <summary>
    ///   AiSystem controls enemies Ai.
    /// </summary>
    public class AiSystem : EntityUpdateSystem
    {
        private readonly Logger _l;

        private ComponentMapper<AiComponent> _aiMapper;
        private ComponentMapper<TurnComponent> _turnMapper;
        private ComponentMapper<BattleComponent> _battleMapper;
        private ComponentMapper<SlugActionsComponent> _slugManager;
        private ComponentMapper<StatusComponent> _statusManager;

        public AiSystem() : base(Aspect.One(typeof(AiComponent)))
        {
            _l = new Logger("AiSystem");
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _aiMapper = mapperService.GetMapper<AiComponent>();
            _turnMapper = mapperService.GetMapper<TurnComponent>();
            _battleMapper = mapperService.GetMapper<BattleComponent>();
            _slugManager = mapperService.GetMapper<SlugActionsComponent>();
            _statusManager = mapperService.GetMapper<StatusComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var entity in ActiveEntities)
            {
                var turn = _turnMapper.Get(entity);

                if (turn.State == Turn.Ai) { doTurn(entity); return; }
            }
        }

        private void doTurn(int entityId)
        {
            var entity = GetEntity(entityId);
            var battle = _battleMapper.Get(entity);

            // TODO: adv ai with bunch of ifelses, oh yeah
            foreach (var enemy in battle.Enemies)
            {
                _l.Info("Enemy decides what to do");

                var status = _statusManager.Get(enemy);
                var slug = _slugManager.Get(enemy);
                if (slug != null)
                {
                    if (status.Health >= 3)
                    {
                        _l.Info("Enemy throwing a stepler");
                        entity.Attach(new ActionDoComponent(slug.ThrowStapler, battle.Player));
                    }
                    else
                    {
                        _l.Info("Enemy health is low, time to drink some COFFEE");
                        entity.Attach(new ActionDoComponent(slug.DrinkCoffee, enemy));
                    }
                }
            }

            entity.Attach(new TurnEndComponent());
        }
    }
}
