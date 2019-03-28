using Entitas;
using UnityEngine;

public class HorizontalInputSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _player;
    Contexts _contexts;
    public HorizontalInputSystem(Contexts contexts)
    {
        _contexts = contexts;
        _player = contexts.game.GetGroup(GameMatcher.Player);
    }

    public void Execute()
    {
        ///
        foreach (GameEntity e in _player.GetEntities())
        {
            var _inputService = _contexts.meta.inputService.instance;
            e.AddHorizontal(_inputService.GetHorizontal());
        }
    }
}