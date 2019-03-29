using Entitas;
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
        _entity.AddAttackSpeed(2);
    }
}