﻿using Entitas;
using UnityEngine;

public class InputSystems : Feature
{
    //can change base inside string 
    public InputSystems(Contexts contexts) : base("InputSystems Systems")
    {
        Add(new DirectionInputSystem(contexts));
        //Add(new JumpInputSystem(contexts));
        Add(new AttackInputSystem(contexts));
    }
}