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
//            if (!e.isAttacking &&!e.isFreeze)
//            {
//                e.view.IViewControllerInstance.Jump();
//            }
//            e.isJump = false;

            if (!e.isAttacking && !e.isFreeze)
            {
                if (e.isGround)
                {
                    e.ReplaceJumpTimes(e.jumpTimes.MaxJumpTimes,e.jumpTimes.MaxJumpTimes);
                    e.view.IViewControllerInstance.Jump();
                    e.ReplaceJumpTimes(e.jumpTimes.MaxJumpTimes,e.jumpTimes.JumpTimes-1);
                }
                else if(e.isAir)
                {
                    if (e.jumpTimes.JumpTimes > 0)
                    {
                        e.view.IViewControllerInstance.Jump();
                        e.ReplaceJumpTimes(e.jumpTimes.MaxJumpTimes,e.jumpTimes.JumpTimes-1);
                       
                    }
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isJumpCommand;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.JumpCommand);
    }
}
