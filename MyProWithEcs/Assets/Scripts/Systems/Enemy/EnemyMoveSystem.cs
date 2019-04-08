using System.Runtime.Serialization;
using Entitas;
using UnityEngine;

public class EnemyMoveSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _enemys;

    public EnemyMoveSystem(Contexts contexts)
    {
        
        _enemys= contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute()
    {
       
        foreach (GameEntity e in _enemys.GetEntities())
        {
            //发现player和没发现主角的情况
            if (e.isFindPlayer)
            {
                var playerGo = GameObject.FindGameObjectWithTag("Player");
                if ((playerGo.transform.position.x - e.view.IViewControllerInstance.Position.x) > 1)//如果player在右边
                {
                    e.ReplaceDirection(1);
                }
                else if((playerGo.transform.position.x - e.view.IViewControllerInstance.Position.x)< -1)
                {
                    e.ReplaceDirection(-1);
                }
                else
                {
                    e.ReplaceDirection(0);
                }
            }
            else if(!e.isFindPlayer)
            {
                
                if (!e.hasEnemyMoveTimer)
                {
                    e.AddEnemyMoveTimer(1);
                }
                
                if (e.enemyMoveTimer.value <0)
                {
                    if (Random.Range(-10, 10) > 3)
                    {
                        e.ReplaceDirection(1);
                    }
                    else if(Random.Range(-10, 10) <-3)
                    {
                        e.ReplaceDirection(-1);
                    }
                    else
                    {
                        e.ReplaceDirection(0);
                    }
                    e.RemoveEnemyMoveTimer();
                }
                    
            }
        }
    }
}