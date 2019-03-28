using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
[CreateAssetMenu]
[Game, Unique]
public class GameSetup : ScriptableObject
{
    public GameObject playerGameobject;
}
