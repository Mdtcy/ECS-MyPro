using Entitas;
using UnityEditor.Build;
using UnityEngine;

public class VelocityXSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _velocityX;
    private Contexts _contexts;
    public VelocityXSystem(Contexts contexts)
    {
        _contexts = contexts;
        _velocityX = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.VelocityX));
    }

    public void Execute()
    {
        
        foreach (GameEntity e in _velocityX.GetEntities())
        {
            //暂停
            e.velocityX.value = 0;
            
            //判定是否可以运动，需要再加入新的影响移动的系统之后更新
            if(!e.isFreeze && e.hasSpeed && !e.isAttack)
            {
                e.velocityX.value = e.direction.value;
            }
            //转向
//            if (e.isPlayer)
//            {
//                if ((e.isFaceRight && e.velocityX.value < 0) || (!e.isFaceRight && e.velocityX.value > 0))
//                {
//                    e.isFaceRight = !e.isFaceRight;
//                    e.view.IViewControllerInstance.Flip();
//                }
//            }
            
            
            //动画
            e.view.IViewControllerInstance.animator.SetFloat("HorizontalSpeed",Mathf.Abs(e.velocityX.value));
            
            //x轴移动
            e.view.IViewControllerInstance.VelocityX = e.velocityX.value * e.speed.speed;
        }
    }
}