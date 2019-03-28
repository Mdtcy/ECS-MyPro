﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//提供描述性强的接口来得到view层的数据以及对其进行操作，只设置我们需要的即可
//会通过实现这个接口来得到实际的

public interface IViewController
{
    Vector3 Position { get; set; }
    bool Active { get; set; }
    void InitializeView(Contexts contexts, IEntity Entity);
    void DestroyView();
    void MoveHorizontal(Vector3 newPosition);
    void Jump();
    bool IsGrounded();
}