using Entitas;
using UnityEngine;

public class InputSystem : IInitializeSystem,IExecuteSystem
{
    Contexts _contexts;
    IInputService _inputService; 
    InputEntity _inputEntity;
    
    readonly IGroup<InputEntity> _inputs;

    
    public InputSystem(Contexts contexts, IInputService inputService)
    {

        _contexts = contexts;
        _inputService= inputService;
    }
    public void Initialize()
    {
        _contexts.input.isInputManager = true;
        _inputEntity = _contexts.input.inputManagerEntity;
        
        
    }

    public void Execute()
    {
        _inputEntity.ReplaceHorizontal(_inputService.GetHorizontal());
        _inputEntity.isJumpInput=_inputService.GetJumpButtonDown();
        _inputEntity.isFireInput= _inputService.GetFireButtonDown();
        _inputEntity.ReplaceVertical(_inputService.GetVertical());
    }

    
}