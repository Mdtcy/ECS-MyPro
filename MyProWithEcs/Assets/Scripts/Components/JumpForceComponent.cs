using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class JumpForceComponent: IComponent
{
    public float jumpForceValue;
}
