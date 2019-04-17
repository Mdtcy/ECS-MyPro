using Entitas;
using UnityEngine;

public class CommandCleanSystem : ICleanupSystem
{
    readonly IGroup<GameEntity> _cleans;

    public CommandCleanSystem(Contexts contexts)
    {
        
        _cleans = contexts.game.GetGroup(GameMatcher.AnyOf(GameMatcher.AttackComand,GameMatcher.JumpCommand));
    }

    
    public void Cleanup()
    {
        foreach (var e in _cleans.GetEntities())
        {
            if (e.isAttackComand)
            {
                e.isAttackComand = false;
            }

            if (e.isJumpCommand)
            {
                e.isJumpCommand = false;
            }
        }
    }
}