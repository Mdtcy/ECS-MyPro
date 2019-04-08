using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class DamageSystem
 : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    public DamageSystem(Contexts context) : base(context.game)
    {
        _context = context.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            e.hP.value = e.hP.value - e.damage.value;
            //受到伤害时的动画效果
            
            e.RemoveDamage();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDamage && entity.hasHP;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Damage,GameMatcher.HP));
    }
}
