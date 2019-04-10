using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class RegisterHudServiceServiceSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IHudTextService _hudTextService;

    public RegisterHudServiceServiceSystem(Contexts contexts, IHudTextService hudTextService)
    {
        _metaContext = contexts.meta;
        _hudTextService = hudTextService;
    }

    public void Initialize()
    {
        _metaContext.ReplaceHudTextService(_hudTextService);
    }
}