using Entitas;
using UnityEngine;

public class TimerSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _timers;

    public TimerSystem(Contexts contexts)
    {
        
        _timers = contexts.game.GetGroup(GameMatcher.Timer);
    }

    public void Execute()
    {
        foreach (GameEntity e in _timers.GetEntities())
        {
            e.timer.value = e.timer.value - Time.deltaTime;
        }
    }
}