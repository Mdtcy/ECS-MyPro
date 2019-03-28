using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

// [Game, Event(true)] (Event(true) DEPRECATED as of Entitas 1.6.0) 
[Game, Event(EventTarget.Self)] // generates events that are bound to the entities that raise them
public sealed class PositionComponent : IComponent
{
    public Vector3 PositionValue;
}