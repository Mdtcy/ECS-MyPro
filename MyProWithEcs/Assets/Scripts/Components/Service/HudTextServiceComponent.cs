using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Meta,Unique]
public class HudTextServiceComponent: IComponent
{
    public IHudTextService instance;
}
