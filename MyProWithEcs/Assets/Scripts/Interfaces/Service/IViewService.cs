using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;


public interface IViewService 
{
    // create a view from a premade asset (e.g. a prefab)
    void LoadAsset(
        Contexts contexts,
        GameEntity entity,
        string assetName);
}
