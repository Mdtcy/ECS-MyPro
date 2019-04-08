using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input,Unique]
public class HorizontalComponent: IComponent
{
    public float value;
}
