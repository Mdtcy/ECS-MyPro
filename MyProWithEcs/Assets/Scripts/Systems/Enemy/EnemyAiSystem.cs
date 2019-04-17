using System.Runtime.Serialization;
using System.Security.Policy;
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
        
        //var playerGo = GameObject.FindGameObjectWithTag("Player");
        
//        if (playerGo != null)
//        {
            //var go = playerGo.GetComponent<IViewController>();
            foreach (GameEntity e in _enemys.GetEntities())
            {
                
                //画出四条线
                var bounds = e.view.IViewControllerInstance.collider2D.bounds;

                #region Debug.DrawRay

                    Debug.DrawRay(e.view.IViewControllerInstance.Position, new Vector2(bounds.extents.x, 0),
                        Color.blue);
                    Debug.DrawRay(e.view.IViewControllerInstance.Position, new Vector2(-bounds.extents.x, 0),
                        Color.blue);

                    Debug.DrawRay(new Vector2(bounds.center.x + bounds.extents.x,
                        bounds.center.y), Vector2.down, Color.red);
                 
                    
                    Debug.DrawRay(new Vector2(
                        bounds.center.x - bounds.extents.x,
                        bounds.center.y), Vector2.down, Color.red);
                    #endregion
                    Debug.DrawRay(new Vector2(bounds.center.x, bounds.center.y - bounds.extents.y),Vector2.down,Color.yellow);
                var rightWall = Physics2D.Raycast(new Vector2(bounds.center.x + bounds.extents.x+.2F,
                        bounds.center.y), Vector2.right, 1f,
                    _contexts.meta.gameSetup.value.Ground);

                var leftWall = Physics2D.Raycast(new Vector2(bounds.center.x - bounds.extents.x-.2F,
                        bounds.center.y), Vector2.left, 1f,
                    _contexts.meta.gameSetup.value.Ground);
                var rightLedges = Physics2D.Raycast(
                    new Vector2(bounds.center.x + bounds.extents.x,
                        bounds.center.y-bounds.extents.y),
                    Vector2.down, .1f, _contexts.meta.gameSetup.value.Ground);
                
                var leftLedges = Physics2D.Raycast(
                    new Vector2(
                        bounds.center.x -
                        bounds.extents.x,
                        bounds.center.y-bounds.extents.y),
                    Vector2.down, .1f, _contexts.meta.gameSetup.value.Ground);

                bool playerIsRight;
                IViewController go;
                
 
                //Debug.Log(rightLedges.collider.gameObject+"let "+leftLedges.collider.gameObject);
                
                
                if (!e.hasPointToPlayer)
                {
                    var playerGo = GameObject.FindGameObjectWithTag("Player");
                    e.AddPointToPlayer(playerGo);
                    go=e.pointToPlayer.player.GetComponent<IViewController>();
                }
                else
                {
                    go = e.pointToPlayer.player.GetComponent<IViewController>();
                }

                if((go.Position.x - e.view.IViewControllerInstance.Position.x)>0)
                {
                    playerIsRight = true;
                }
                else
                {
                    playerIsRight = false;
                }
                
//                //如果有player存在
//                if (go != null)
//                {
//                     //计算该enemy与player的距离  
//                    var playerGo = e.pointToPlayer.player;
//                    var distance= Vector2.Distance(new Vector2(go.Position.x, go.Position.y), new Vector2(e.view.IViewControllerInstance.Position.x, e.view.IViewControllerInstance.Position.y));
//                    
//                    //小于这个距离则发现
//                    if(distance<=_contexts.meta.enemyFindDistance.findDistance)
//                {
//                    if (e.isFindPlayer == false)
//                    {
//                        Debug.Log("find player");
//                    }
//                    e.isFindPlayer = true;
//
//                    //发现时攻击或者追逐至攻击范围
//                    if (Mathf.Abs((playerGo.transform.position.x - e.view.IViewControllerInstance.Position.x)) < e.attackRange.value)
//                    {
//                        e.ReplaceDirection(0);
//                        
//                        e.isAttack = true;
//                    }
//                    else if ((playerGo.transform.position.x - e.view.IViewControllerInstance.Position.x) > e.attackRange.value)//如果player在右边
//                    {
//                        e.ReplaceDirection(1);
//                    }
//                    else if((playerGo.transform.position.x - e.view.IViewControllerInstance.Position.x)< -e.attackRange.value)
//                    {
//                        e.ReplaceDirection(-1);
//                    }
//                   
//
//                    
//                }
//                    //大于这个距离则失去player目标
//                else if(distance>=_contexts.meta.enemyFindDistance.lostFindDistance)
//                {
//                    if (e.isFindPlayer)
//                    {
//                        Debug.Log("lost player");
//                    }
//                    
//                    e.isFindPlayer = false;
//
//                    
//                   
//
//
//                    if (!e.hasEnemyMoveTimer)
//                    {
//                        
//                        
//
//                            if (leftWall.collider == null && rightWall.collider == null)
//                            {
//                            
//                                if (Random.Range(-10, 10) > 3)
//                                {
//                                    e.ReplaceDirection(1);
//                                }
//                                else if(Random.Range(-10, 10) <-3)
//                                {
//                                    e.ReplaceDirection(-1);
//                                }
//                                else
//                                {
//                                    e.ReplaceDirection(0);
//                                }
//
//                                e.AddEnemyMoveTimer(1f);
//                            }
//                            else if (rightWall.collider != null)
//                            {
//                                e.ReplaceDirection(-1);
//                                e.AddEnemyMoveTimer(1f);
//                            }
//                            else if(leftWall.collider!=null)
//                            {
//                                e.ReplaceDirection(1);
//                                e.AddEnemyMoveTimer(1f);
//                            }
//                        }
//                        
//
//                }
//                }

                if (go != null)
                {
                    //var playerGo = e.pointToPlayer.player;
                    var distance= Vector2.Distance(new Vector2(go.Position.x, go.Position.y), new Vector2(e.view.IViewControllerInstance.Position.x, e.view.IViewControllerInstance.Position.y));

                    //确定isfindPlayer
                    if (distance <= _contexts.meta.enemyFindDistance.findDistance)
                    {
                        if (e.isFindPlayer == false)
                        {
                            Debug.Log("find player");
                        }
                        e.isFindPlayer = true;

                    }
                    else if(distance >= _contexts.meta.enemyFindDistance.lostFindDistance)
                    {
                        if (e.isFindPlayer)
                        {
                            Debug.Log("lost player");
                        }
                    
                        e.isFindPlayer = false;

                    }

                    //不接触地面时
                    if (leftLedges.collider == null && rightLedges.collider == null) 
                    {
                        if (e.isFindPlayer)
                        {
                            
                            if (e.view.IViewControllerInstance.VelocityY > 0)
                            {
                                var raycast=Physics2D.Raycast(new Vector2(bounds.center.x, bounds.center.y - bounds.extents.y), Vector2.down, 1f,
                                    _contexts.meta.gameSetup.value.Ground);
                                
                                if (raycast.collider != null)
                                {
                                    e.ReplaceDirection(0);
                                }
                                else
                                {
                                    if (go.Position.x - e.view.IViewControllerInstance.Position.x > 0)
                                    {
                                        e.ReplaceDirection(1);
                                    }
                                    else
                                    {
                                        e.ReplaceDirection(-1);
                                    }
                                }
                                
                            }
                            else
                            {
                                e.ReplaceDirection(0);
                            }
                        }
                       
                            
                    }
                    //右边为空时
                    else if (rightLedges.collider == null)
                    {
                        Debug.Log("1");
                        
                        if (!e.isFindPlayer)
                        {
                            e.ReplaceDirection(-1);
                        }
                        else
                        {
                            Debug.Log("12");
                            if (e.isCanJumpDown)
                            {
                                
                                if (playerIsRight)
                                {
                                    e.ReplaceDirection(1);
                                }
                                else
                                {
                                    e.ReplaceDirection(-1);
                                }
                            }
                            else
                            {
                                Debug.Log("123");
                                e.ReplaceDirection(-1);
                            }

                        }
                        
                    }
                    else if (leftLedges.collider == null)
                    {
                        if(!e.isFindPlayer)
                        {
                            e.ReplaceDirection(1);
                        }
                        else 
                        {
                            if (e.isCanJumpDown)
                            {
                                if (playerIsRight)
                                {
                                    e.ReplaceDirection(1);
                                }
                                else
                                {
                                    e.ReplaceDirection(-1);
                                }
                            }
                            else
                            {
                                
                                e.ReplaceDirection(1);
                            }
                        }

                    }
                    else //在地面上时
                    {
                        if (e.isFindPlayer)
                        {

                            if (Mathf.Abs((go.Position.x - e.view.IViewControllerInstance.Position.x)) <
                                e.attackRange.value)
                            {
                                e.ReplaceDirection(0);
                                e.isAttackComand = true;
                            }
                            else if((go.Position.x - e.view.IViewControllerInstance.Position.x)<-e.attackRange.value)
                            {
                                if (leftWall.collider != null)
                                {
                                    e.isJumpCommand = true;
                                    e.ReplaceDirection(0);
                                }
                                else 
                                    e.ReplaceDirection(-1);
                            }
                            else if((go.Position.x - e.view.IViewControllerInstance.Position.x)>e.attackRange.value)
                            {
                                if (rightWall.collider != null)
                                {
                                    e.ReplaceDirection(0);
                                    e.isJumpCommand= true;
                                }
                                else
                                    e.ReplaceDirection(1);
                                
                            }
                                
                        }
                        else
                        {
                            if (e.hasEnemyMoveTimer)
                            {
                                
                            }
                            else
                            {
                                if(Random.Range(-10, 10) > 3)
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

                                e.AddEnemyMoveTimer(1f);
                            }
                        }

                        }

                        }
                    }
                    
                }
                
            }
        
        
    
