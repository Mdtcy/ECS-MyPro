using Entitas;
using UnityEngine;

public class AttackInputSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _shoots;
    Contexts _contexts;
    public AttackInputSystem(Contexts contexts)
    {
        _contexts = contexts;
        _shoots = contexts.game.GetGroup(GameMatcher.Player);
    }

    public void Execute()
    {

        foreach (GameEntity e in _shoots.GetEntities())
        {
            if (_contexts.meta.inputService.instance.GetFireButtonDown())
            {
                e.isAttack = true;
;            }
        }
    }
}