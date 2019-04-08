﻿using Entitas;
using UnityEngine;

public class IntializeSnakeSystem : IInitializeSystem
{
    private Contexts _contexts;

    public IntializeSnakeSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var _entity = _contexts.game.CreateEntity();
        _entity.isEnemy = true;
        _entity.AddSprite("Snake");
        _entity.AddHP(100);
        _entity.isFaceRight = true;
        _entity.AddAttackSpeed(2);
        _entity.AddVelocityX(0);
        _entity.AddDirection(0);
        _entity.isMoving = true;
        _entity.AddSpeed(10);
        
    }
}