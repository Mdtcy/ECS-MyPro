using Entitas;
using UnityEngine;

public class EnemyAiSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _enemys;

    public EnemyAiSystem(Contexts contexts)
    {

        _enemys = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy,GameMatcher.View));
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
                if(distance<=10)//小于这个距离则发现
                {
                    e.isFindPlayer = true;
                    if(distance<=1)
                    {
                        if (e.isAttack == false)
                        {
                            e.isAttack = true;
                        }

                    }
                }
                else if(distance>=20)
                {
                    e.isFindPlayer = false;
                }
            }
        }
        
    }
}