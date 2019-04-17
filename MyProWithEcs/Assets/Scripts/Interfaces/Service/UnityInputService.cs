using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInputService : IInputService
{
    public bool GetFireButtonDown()
    {
        return Input.GetKeyDown(KeyCode.J);
    }

    public float GetHorizontal()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public bool GetJumpButtonDown()
    {
        return Input.GetButtonDown("Jump");
    }

    public float GetVertical()
    {
        return Input.GetAxisRaw("Vertical");
    }
}
