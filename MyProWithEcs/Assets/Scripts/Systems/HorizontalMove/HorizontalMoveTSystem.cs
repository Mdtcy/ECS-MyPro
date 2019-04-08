//using Entitas;
//using UnityEngine;
//
//public class HorizontalMoveTSystem : IExecuteSystem
//{
//    readonly IGroup<GameEntity> _moves;
//
//    public HorizontalMoveTSystem(Contexts contexts)
//    {
//        
//        _moves = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Moving,GameMatcher.Direction,GameMatcher.Speed));
//        //_moves = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Direction,GameMatcher.Speed));
//    }
//
//    public void Execute()
//    {
//        ///
//        foreach (GameEntity e in _moves.GetEntities())
//        {
//            var go = e.view.IViewControllerInstance;
//            go.MoveHorizontal(0);
//            
//            go.MoveHorizontal(e.direction.value);
//        }
//    }
//}