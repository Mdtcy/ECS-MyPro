//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class PositionEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IPositionListener> _listenerBuffer;

    public PositionEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IPositionListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.Position)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasPosition && entity.hasPositionListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.position;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.positionListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnPosition(e, component.PositionValue);
            }
        }
    }
}
