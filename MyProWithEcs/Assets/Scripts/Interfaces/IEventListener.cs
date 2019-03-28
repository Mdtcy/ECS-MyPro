using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public interface IEventListener
{
    void RegisterListeners(IEntity entity);
}
