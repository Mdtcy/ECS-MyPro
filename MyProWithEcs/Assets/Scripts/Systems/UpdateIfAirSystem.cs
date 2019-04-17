using Entitas;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class UpdateIfAirSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _group;

    public UpdateIfAirSystem(Contexts contexts)
    {
        
        _group = contexts.game.GetGroup(GameMatcher.AnyOf(GameMatcher.Enemy,GameMatcher.Player));
    }

    public void Execute()
    {
        
        foreach (GameEntity e in _group.GetEntities())
        {
            if (e.view.IViewControllerInstance.IsGrounded())
            {
                e.isGround = true;
                e.isAir = false;
            }
            else
            {
                e.isGround = false;
                e.isAir = true;
            }
        }
    }
}