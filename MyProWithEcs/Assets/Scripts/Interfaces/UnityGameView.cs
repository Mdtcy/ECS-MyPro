using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//通过实现Iviewcontroller接口来为view 层与模拟层提供连接 ，模拟层通过操作这个来实际操作view
public class UnityGameView : MonoBehaviour, IViewController
{
    public Contexts _contexts;
    public GameEntity _entity;
    public Vector3 Position { get { return transform.position; } set { transform.position = value; } }
    public bool Active { get { return gameObject.activeSelf; } set { gameObject.SetActive(value); } }
    public Animator _animator { get { return gameObject.GetComponent<Animator>(); } }


    //为了实现一些函数而设置的变量，对entity的使用屏蔽
    private Transform GroundCheck;
    private const float GROUND_CHECK_RADIUS = 0.02f;
    private LayerMask WhatIsGround;
    private Rigidbody2D _groundRigidBody;
    private Rigidbody2D _rigBody;
    private bool  faceRight=true;
    private void Awake()
    {
        WhatIsGround = LayerMask.GetMask("Ground");
        GroundCheck = transform.Find("GroundCheck");
        _rigBody = gameObject.GetComponent<Rigidbody2D>();
    }
    public void MoveHorizontal(Vector3 newPosition)
    {
        //辅助跳跃判断
        if(IsGrounded())
        {

            _entity.ReplaceJumpTimes(_entity.jumpTimes.MaxJumpTimes, _entity.jumpTimes.MaxJumpTimes);
        }
        //this.gameObject.transform.Translate(newPosition * Time.deltaTime*_entity.speed.speed);
        Rigidbody2D _rigBody = this.gameObject.GetComponent<Rigidbody2D>();
        _rigBody.velocity= new Vector3(newPosition.x*_entity.speed.speed, _rigBody.velocity.y, 0);
       
        if(faceRight && _rigBody.velocity.x<0)
        {
            Flip();
        }
        else if(!faceRight&&_rigBody.velocity.x>0)
        {
            Flip();
        }

        _animator.SetFloat("HorizontalSpeed", Mathf.Abs(_rigBody.velocity.x));
    }
    

    public void DestroyView()
    {
        Object.Destroy(this);
    }

    public void InitializeView(Contexts contexts, IEntity entity)
    {
        _contexts = contexts;
        _entity = (GameEntity)entity;
    }
    /// <summary>
    /// Jump
    /// </summary>
    public void Jump()
    {
        
        if(IsGrounded())
        {
            _entity.ReplaceJumpTimes(_entity.jumpTimes.MaxJumpTimes, _entity.jumpTimes.MaxJumpTimes);
            //_rigBody.AddForce(Vector2.up * _entity.jumpForce.jumpForceValue);
            _rigBody.velocity = new Vector2(_rigBody.velocity.x, _entity.jumpSpeed.value);
            _entity.ReplaceJumpTimes(_entity.jumpTimes.MaxJumpTimes,_entity.jumpTimes.JumpTimes - 1);
        }
        else if(_entity.jumpTimes.JumpTimes>0)
        {
            //_rigBody.AddForce(Vector2.up * _entity.jumpForce.jumpForceValue);
            _rigBody.velocity = new Vector2(_rigBody.velocity.x, _entity.jumpSpeed.value);
            _entity.ReplaceJumpTimes(_entity.jumpTimes.MaxJumpTimes,_entity.jumpTimes.JumpTimes - 1);
        }
        
    }

    public bool IsGrounded()
    {
        
        var _collider = Physics2D.OverlapCircle(GroundCheck.position, GROUND_CHECK_RADIUS, WhatIsGround);
        if (_collider != null)
        {
            _groundRigidBody = _collider.gameObject.GetComponent<Rigidbody2D>();
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
