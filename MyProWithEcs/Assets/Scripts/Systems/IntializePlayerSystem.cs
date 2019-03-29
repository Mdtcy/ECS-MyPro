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
        playerEntity.AddSprite("Player");
        
        playerEntity.AddJumpForce(800f);
        playerEntity.AddJumpTimes(2,2);
        playerEntity.AddJumpSpeed(18f);
        playerEntity.AddATK(10);
        //Move
        playerEntity.AddDirection(0);
        playerEntity.isMoving = true;
        playerEntity.AddSpeed(8f);
        playerEntity.AddAttackSpeed(1f);

    }
}
