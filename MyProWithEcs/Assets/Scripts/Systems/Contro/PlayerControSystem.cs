using Entitas;
using UnityEngine;

public class PlayerControSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _players;
    private Contexts _contexts;
    
    public PlayerControSystem(Contexts contexts)
    {
        _contexts = contexts;
        _players = contexts.game.GetGroup(GameMatcher.Player);
        
    }

    public void Execute()
    {
        
        foreach (GameEntity e in _players.GetEntities())
        {
            e.direction.value = _contexts.input.horizontal.value;
            e.isJump = _contexts.input.isJumpInput;
            if (_contexts.input.isFireInput)
            {
                e.isAttack = true;
            }
        }
    }
}