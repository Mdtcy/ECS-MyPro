using Entitas;
using UnityEngine;

public class EnemyAiSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _enemys;
    private Contexts _contexts;
    public EnemyAiSystem(Contexts contexts)
    {

        _enemys = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy,GameMatcher.View));
        _contexts = contexts;
    }

    public void Execute()
    {
        var playerGo = GameObject.FindGameObjectWithTag("Player");
        
        if (playerGo != null)
        {
            var go = playerGo.GetComponent<IViewController>();
            foreach (GameEntity e in _enemys.GetEntities())
            {
                //计算该enemy与player的距离  
               var distance= Vector2.Distance(new Vector2(go.Position.x, go.Position.y), new Vector2(e.view.IViewControllerInstance.Position.x, e.view.IViewControllerInstance.Position.y));
                if(distance<=_contexts.meta.enemyFindDistance.findDistance)//小于这个距离则发现
                {
                    if (e.isFindPlayer == false)
                    {
                        Debug.Log("find player");
                    }
                    e.isFindPlayer = true;

                    if (Mathf.Abs((playerGo.transform.position.x - e.view.IViewControllerInstance.Position.x)) < 2)
                    {
                        e.ReplaceDirection(0);
                        if (distance <= _contexts.meta.enemyCanAttackDistance.distance)
                        {
                            if (e.isAttack == false)
                            {
                                e.isAttack = true;
                            }
                        }
                    }
                    else if ((playerGo.transform.position.x - e.view.IViewControllerInstance.Position.x) > 2f)//如果player在右边
                    {
                        e.ReplaceDirection(1);
                    }
                    else if((playerGo.transform.position.x - e.view.IViewControllerInstance.Position.x)< -2f)
                    {
                        e.ReplaceDirection(-1);
                    }
                   

                    
                    if(distance<=1)
                    {
                        if (e.isAttack == false)
                        {
                            e.isAttack = true;
                        }

                    }
                }
                else if(distance>=_contexts.meta.enemyFindDistance.lostFindDistance)//大于这个距离则失去player目标
                {
                    if (e.isFindPlayer)
                    {
                        Debug.Log("lost player");
                    }
                    
                    e.isFindPlayer = false;
                    
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
}