﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class MovementComponent: IComponent
{
    public float horizontalValue;
    public float verticalValue;
    
}
