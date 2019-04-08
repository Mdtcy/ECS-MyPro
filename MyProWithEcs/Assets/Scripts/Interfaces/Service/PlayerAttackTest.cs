using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTest : MonoBehaviour,IAttack
{
    private Animator _animator;
    //private Transform atkPosition;
    //public LayerMask whatIsEnemy;
    private void Start()
    {
        _animator = this.gameObject.GetComponent<Animator>();
        //atkPosition = this.gameObject.transform.Find("attackposition");
    }

    public void Attack()
    {
        //Debug.Log("atk");
       _animator.SetTrigger("Attack");
       this.gameObject.GetComponent<IViewController>().CreatGameObject("AttackObject");
       //Debug.Log(this.gameObject.transform.Find("attackposition"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.gameObject.transform.Find("attackposition").position,0.1f);
        //Debug.Log(this.gameObject.transform.Find("attackposition"));
        
    }
}
