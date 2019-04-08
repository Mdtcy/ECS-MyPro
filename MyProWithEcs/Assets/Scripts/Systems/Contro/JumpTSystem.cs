using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class JumpTSystem
 : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    public JumpTSystem(Contexts context) : base(context.game)
    {
        _context = context.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            e.view.IViewControllerInstance.Jump();
            e.isJump = false;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isJump;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Jump);
    }
}
