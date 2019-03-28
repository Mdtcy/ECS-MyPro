using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class AddViewSystem
 : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    public AddViewSystem(Contexts context) : base(context.game)
    {
        _context = context.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            Contexts.sharedInstance.meta.viewService.instance.LoadAsset(Contexts.sharedInstance, e, e.sprite.SpriteName);
            
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && !entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }
}
