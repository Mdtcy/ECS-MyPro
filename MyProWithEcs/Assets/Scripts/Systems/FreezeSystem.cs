using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class FreezeSystem
 : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    public FreezeSystem(Contexts context) : base(context.game)
    {
        _context = context.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            e.isCanMove = false;
            e.isCanAttack = false;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isFreeze;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
       return context.CreateCollector(GameMatcher.Freeze);
    }
}
