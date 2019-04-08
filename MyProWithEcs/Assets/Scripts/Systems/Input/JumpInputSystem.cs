//using Entitas;
   //using UnityEngine;
   //
   //public class JumpInputSystem : IExecuteSystem
   //{
   //    readonly IGroup<GameEntity> _jumps;
   //    Contexts _contexts;
   //    public JumpInputSystem(Contexts contexts)
   //    {
   //        _contexts = contexts;
   //           _jumps = contexts.game.GetGroup(GameMatcher.Player);
   //    }
   //
   //    public void Execute()
   //    {
   //    
   //        foreach (GameEntity e in _jumps.GetEntities())
   //        {
   //            if(_contexts.meta.inputService.instance.GetJumpButtonDown())
   //            {
   //                e.isJump = true;
   //            }
   //        }
   //    }
   //}