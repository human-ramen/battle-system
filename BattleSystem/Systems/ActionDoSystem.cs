using BattleSystem.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace BattleSystem.Systems
{
    /// <summary>
    ///   ActionDoSystem do Action to Target with calculations and state changing.
    /// </summary>
    public class ActionDoSystem : EntityUpdateSystem
    {
        private readonly Logger _l;

        private ComponentMapper<ActionDoComponent> _actionDoMapper;
        private ComponentMapper<PropComponent> _propMapper;
        private ComponentMapper<StatusComponent> _statusMapper;

        public ActionDoSystem() : base(Aspect.All(typeof(ActionDoComponent)))
        {
            _l = new Logger("ActionDoSystem");
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _actionDoMapper = mapperService.GetMapper<ActionDoComponent>();
            _propMapper = mapperService.GetMapper<PropComponent>();
            _statusMapper = mapperService.GetMapper<StatusComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var entity in ActiveEntities)
            {
                var actionDo = _actionDoMapper.Get(entity);
                if (actionDo != null)
                {

                    var targetProp = _propMapper.Get(actionDo.Target);
                    var targetStatus = _statusMapper.Get(actionDo.Target);

                    // TODO: Add damage/heal calculations.
                    switch (actionDo.Action.Nature)
                    {
                        case Nature.Coffee:
                            _l.Info("Target was healed");
                            targetStatus.Health += actionDo.Action.Amount;
                            break;
                        default:
                            _l.Info("Target taken damage");
                            targetStatus.Health -= actionDo.Action.Amount;
                            break;
                    }

                }

                _actionDoMapper.Delete(entity);
            }
        }
    }
}
