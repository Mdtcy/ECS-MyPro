using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using UnityEngine.UI;

public class DamageSystem
 : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    private GameObject damageCanvas;
    public DamageSystem(Contexts context) : base(context.game)
    {
        _context = context.game;
        damageCanvas = GameObject.Find("DamageCanvas");
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            e.hP.value = e.hP.value - e.damage.value;
            

            Contexts.sharedInstance.meta.hudTextService.instance.floatText(e.view.IViewControllerInstance.animator.gameObject.transform,"-"+e.damage.value);
//            HUDTextInfo info=new HUDTextInfo(e.view.IViewControllerInstance.animator.gameObject.transform,"-"+e.damage.value);
//            info.Side = bl_Guidance.Up;
//            info.Size = 30;
//            bl_UHTUtils.GetHUDText.NewText(info);
            
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
