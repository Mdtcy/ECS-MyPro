using System.Collections;
using System.Collections.Generic;
using Entitas.VisualDebugging.Unity;
using UnityEngine;

public class PlayerAttackTest : MonoBehaviour,IAttack
{
    private Animator _animator;

    public AttackObject go;
    //private Transform atkPosition;
    //public LayerMask whatIsEnemy;
    private void Start()
    {
        _animator = this.gameObject.GetComponent<Animator>();
        //atkPosition = this.gameObject.transform.Find("attackposition");
    }

    public void Attack()
    {
        
       _animator.SetTrigger("Attack");
       //this.gameObject.GetComponent<IViewController>().CreatGameObject("AttackObject");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.gameObject.transform.Find("attackposition").position,0.1f);
        //Debug.Log(this.gameObject.transform.Find("attackposition"));
        
    }

    public void an1()
    {
        go=(AttackObject)GameObject.Instantiate(Contexts.sharedInstance.meta.gameSetup.value.AttackObject);
        go._gameObject = this.gameObject;
    }

    public void destroyNi()
    {
        
        Destroy((GameObject)go.gameObject);
        
        
    }
}
