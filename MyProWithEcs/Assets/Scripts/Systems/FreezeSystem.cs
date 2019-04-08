using Entitas;
using UnityEngine;

public class FreezeSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _freezes;

    public FreezeSystem(Contexts contexts)
    {
        
        _freezes = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Freeze,GameMatcher.FreezeTimer));
    }

    public void Execute()
    {
        
        foreach (GameEntity e in _freezes.GetEntities())
        {
            if (e.isFreeze)
            {
               
                if (e.freezeTimer.value > 0)
                {
                     
                    //动画停止
                    e.view.IViewControllerInstance.animator.speed = 0;
                    
                    e.ReplaceFreezeTimer(e.freezeTimer.value - Time.deltaTime);
                    
                }
                else if(e.freezeTimer.value <=0)
                {
                    e.RemoveFreezeTimer();
                    e.isFreeze = false;
                    e.view.IViewControllerInstance.animator.speed = 1;
                    
                }
            }
        }
    }
}