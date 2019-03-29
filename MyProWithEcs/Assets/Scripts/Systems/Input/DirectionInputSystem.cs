using Entitas;
using UnityEngine;

public class DirectionInputSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _player;
    Contexts _contexts;

    public DirectionInputSystem(Contexts contexts)
    {
        _contexts = contexts;
        _player = contexts.game.GetGroup(GameMatcher.Player);
    }

    public void Execute()
    {
        
        foreach (GameEntity e in _player.GetEntities())
        {
            var _inputService = _contexts.meta.inputService.instance;
            e.ReplaceDirection(_inputService.GetHorizontal());
        }
    }
}