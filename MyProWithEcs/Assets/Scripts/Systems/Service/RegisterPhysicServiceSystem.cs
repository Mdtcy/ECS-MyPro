using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class RegisterPhysicServiceSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IPhysicService _physicService;

    public RegisterPhysicServiceSystem(Contexts contexts, IPhysicService physicService)
    {
        _metaContext = contexts.meta;
        _physicService = physicService;
        
    }

    public void Initialize()
    {
        _metaContext.ReplacePhysicService(_physicService);
    }
}