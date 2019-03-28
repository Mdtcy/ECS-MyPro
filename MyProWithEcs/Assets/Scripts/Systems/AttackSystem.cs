using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class AttackSystem
 : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    public AttackSystem(Contexts context) : base(context.game)
    {
        _context = context.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //调用每个拥有attack的entity的Attack方法
            if (e.isPlayer)
            {
                //var go = e.view.IViewControllerInstance;
                //var bullet = _context.CreateEntity();
                Debug.Log("Attack");
                //bullet.AddSprite("Bullet");
               // bullet.AddPosition(go.Position + new Vector3(2, 0, 0));
               // bullet.AddHorizontal(10f);
            }

            e.isAttack = false;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isAttack;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Attack);
    }
}
