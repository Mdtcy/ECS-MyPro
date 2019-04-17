using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class IntializePlayerSystem : IInitializeSystem
{
    private Contexts _contexts;

    public IntializePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var playerEntity = _contexts.game.CreateEntity();

        playerEntity.isPlayer = true;
        //playerEntity.AddResource((GameObject)Resources.Load("Prefabs/Player"));
        playerEntity.AddPosition(new Vector3(-2, 0, 0));
        playerEntity.AddSprite("Player1");
        
        //playerEntity.AddJumpForce(800f);
        playerEntity.AddJumpTimes(3,3);
        playerEntity.AddJumpSpeed(18f);
        playerEntity.AddATK(10);
        //Move
        playerEntity.isFaceRight = true;
        playerEntity.AddDirection(0);
        playerEntity.AddVelocityX(0);
        playerEntity.isMoving = true;
        //playerEntity.AddSpeed(8f);
        playerEntity.ReplaceSpeed(8f);
        playerEntity.AddAttackSpeed(0.5f);
        playerEntity.AddHP(100);
        playerEntity.isCanMove = true;
        playerEntity.isCanAttack = true;

    }
}
