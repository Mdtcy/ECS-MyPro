using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Meta,Unique]
public class PhysicServiceComponent: IComponent
{
    public IPhysicService PhysicService;
}
