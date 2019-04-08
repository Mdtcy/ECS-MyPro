using Entitas;
using UnityEngine;

public class TimerSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _timers;

    public TimerSystem(Contexts contexts)
    {
        
        _timers = contexts.game.GetGroup(GameMatcher.AnyOf(GameMatcher.Timer,GameMatcher.EnemyMoveTimer,GameMatcher.FlipTimer));
    }

    public void Execute()
    {
        foreach (GameEntity e in _timers.GetEntities())
        {
            if (e.hasTimer)
            {
                e.timer.value = e.timer.value - Time.deltaTime;
            }
            else if (e.hasEnemyMoveTimer)
            {
                
                e.enemyMoveTimer.value = e.enemyMoveTimer.value - Time.deltaTime;
            }
            else if(e.hasFlipTimer)
            {
                 e.ReplaceFlipTimer(e.flipTimer.value-Time.deltaTime);
            }
            
        }
    }
}