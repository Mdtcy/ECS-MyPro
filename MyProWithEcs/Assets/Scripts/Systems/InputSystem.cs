//using Entitas;
//using UnityEngine;

//public class InputSystem : IExecuteSystem
//{
//    readonly IGroup<InputEntity> _inputs;

//    public InputSystem(Contexts contexts)
//    {

//        _inputs = contexts.input.GetGroup(InputMatcher.Input);
//    }

//    public void Execute()
//    {
//        var inputSercice = Contexts.sharedInstance.meta.inputService;
//        foreach (InputEntity e in _inputs.GetEntities())
//        {
//            e.ReplaceInput(inputSercice.instance.GetHorizontal(), inputSercice.instance.GetVertical());
//        }
//    }
//}