using Entitas;
using UnityEngine;

public class FlipSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _moves;

    public FlipSystem(Contexts contexts)
    {
        
        _moves = contexts.game.GetGroup(GameMatcher.Direction);
    }

    public void Execute()
    {
        
        foreach (GameEntity e in _moves.GetEntities())
        {
            
            if (e.isPlayer)
            {
                if ((e.isFaceRight && e.velocityX.value < 0) || (!e.isFaceRight && e.velocityX.value > 0))
                {
                    e.isFaceRight = !e.isFaceRight;
                    e.view.IViewControllerInstance.Flip();
                }
            }
            else if (e.isEnemy && !e.isFreeze && !e.isAttacking)//需要更新的条件
            {
                if (e.isFindPlayer)
                {
                    if (!e.hasPointToPlayer)
                    {
                        var playerGo=GameObject.FindGameObjectWithTag("Player");
                        e.AddPointToPlayer(playerGo);
                    }
                
                    if (e.hasPointToPlayer)
                    {
                        if ((e.pointToPlayer.player.GetComponent<IViewController>().Position.x -
                             e.view.IViewControllerInstance.Position.x < 0 && e.isFaceRight) || 
                            (e.pointToPlayer.player.GetComponent<IViewController>().Position.x -
                             e.view.IViewControllerInstance.Position.x > 0 && !e.isFaceRight) )//
                        {
                            e.isFaceRight = !e.isFaceRight;
                            e.view.IViewControllerInstance.Flip();
                        }
                    }
                }
                else if(!e.isFindPlayer)
                {
                    if ((e.direction.value == 1 && !e.isFaceRight) || (e.direction.value == -1 && e.isFaceRight))
                    {
                        e.isFaceRight = !e.isFaceRight;
                        e.view.IViewControllerInstance.Flip();
                    }
                }
            }
                
            
        }
    }
}