using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject : CreatedObject
{

    // Update is called once per frame
    void Update()
    {
        this.transform.position = _gameObject.transform.Find("attackposition").position;

    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
    }
    
    //增加一个自毁
}