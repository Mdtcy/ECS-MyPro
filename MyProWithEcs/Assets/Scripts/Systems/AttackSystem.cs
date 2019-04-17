using System.Collections;
using System.Collections.Generic;
using DesperateDevs.Utils;
using UnityEngine;
using Entitas;
using Entitas.Unity;



public class AttackSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _attacks;

    public AttackSystem(Contexts contexts)
    {

        _attacks = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.AttackComand,GameMatcher.AttackSpeed));
    }

    public void Execute()
    {
        foreach (GameEntity e in _attacks.GetEntities())
        {
//            if (e.isAttackComand)//有攻击指令
//            {
//
//                if (e.hasAttackTimer)//说明已经在攻击中了
//                {
//                    if (e.attackTimer.value < 0)
//                    {
//                        e.RemoveAttackTimer();
//                        e.isAttack = false;
//                            
//                    }
//                    else
//                    {
//                        e.ReplaceAttackTimer(e.attackTimer.value-Time.deltaTime);
//                    }
//                }
//                else if (!e.hasAttackTimer)//给了攻击指令还没开始攻击
//                {
//                    //判定是否可以开始攻击，之后每次有影响可以攻击的状态都从被影响的系统改
//                    if (e.isFreeze)//if can't attack
//                    {
//                        e.isAttack = false;
//                    }
//                    else
//                    {
//                        var go = e.view.IViewControllerInstance;
//                        go.Attack();
//                        e.AddAttackTimer(e.attackSpeed.value);
//                    }
//                }
//            }

            if (!e.isAttacking && !e.isFreeze)
            {
                e.isAttacking = true;
                e.AddAttackTimer(e.attackSpeed.value);
                var go = e.view.IViewControllerInstance;
                go.Attack();
            }
        }
            
    }
}