using System.Collections;
using System.Collections.Generic;
using DesperateDevs.Utils;
using UnityEngine;
using Entitas;
using Entitas.Unity;

//public class AttackSystem
// : ReactiveSystem<GameEntity>
//{
//    readonly GameContext _context;
//    public AttackSystem(Contexts context) : base(context.game)
//    {
//        _context = context.game;
//    }

//    protected override void Execute(List<GameEntity> entities)
//    {
//        foreach (var e in entities)
//        {

//            e.isMoving = false;

//            var go = e.view.IViewControllerInstance;
//            go.Attack();
//            go.HelpAttack();
//            e.AddTimer(1);
//            if (e.timer.value < 0)
//            {
//                e.isAttack = false;
//                e.isMoving = true;
//                e.RemoveTimer();
//            }
//            有一部分逻辑进到了下面。如果要修改需要进入下面修改
//            e.isAttack = false;
//            e.isMoving = true;
//        }
//    }

//    protected override bool Filter(GameEntity entity)
//    {
//        return entity.isAttack;
//    }

//    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
//    {
//        return context.CreateCollector(GameMatcher.Attack);
//    }
//}

public class AttackSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _attacks;

    public AttackSystem(Contexts contexts)
    {

        _attacks = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Attack,GameMatcher.AttackSpeed));
    }

    public void Execute()
    {
        foreach (GameEntity e in _attacks.GetEntities())
        {
            
            e.isMoving = false;
             
            var go = e.view.IViewControllerInstance;
            if(!e.hasTimer)
            {
                go.Attack();
                e.AddTimer(e.attackSpeed.value);
            }

            if (e.timer.value < 0)
            {
                
                
                e.isMoving = true;
                e.RemoveTimer();
                e.isAttack = false;
            }

        }
    }
}