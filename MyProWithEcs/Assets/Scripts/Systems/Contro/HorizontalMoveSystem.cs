using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class HorizontalMoveSystem
 : ReactiveSystem<GameEntity>
{
     Contexts _contexts;

    public HorizontalMoveSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            var go = e.view.IViewControllerInstance;
            var _input = _contexts.meta.inputService.instance;      
            go.MoveHorizontal(_input.GetHorizontal());

            e.RemoveHorizontal();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHorizontal && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
       return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Horizontal,GameMatcher.View));
    }
}
