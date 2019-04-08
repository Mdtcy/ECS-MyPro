using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEditor.Build;

//通过实现Iviewcontroller接口来为view 层与模拟层提供连接 ，模拟层通过操作这个来实际操作view
public class UnityGameViewController : MonoBehaviour, IViewController
{
    public Contexts _contexts;
    public GameEntity _entity;
    public Vector3 Position { get { return transform.position; } set { transform.position = value; } }
    public bool Active { get { return gameObject.activeSelf; } set { gameObject.SetActive(value); } }
    public Animator animator
    {get { return this.gameObject.GetComponent<Animator>();}}

    public float VelocityX
    {
        get { return this.GetComponent<Rigidbody2D>().velocity.x; }
        set { _rigBody.velocity=new Vector2(value,_rigBody.velocity.y); }
    }

    

    //public Transform transform { get { return this.transform; } }
    public Animator _animator { get { return gameObject.GetComponent<Animator>(); } }

    public Transform HpUiTransform
    {
        get
        {
            if (this.transform.Find("HPUITransform") != null)
            {
                return this.transform.Find("HPUITransform").transform;
            }


            return null;
        }
    }
    //为了实现一些函数而设置的变量，对entity的使用屏蔽
    
    private Transform GroundCheck;
    private const float GROUND_CHECK_RADIUS = 0.02f;
    private LayerMask WhatIsGround;
    private Rigidbody2D _groundRigidBody;
    private Rigidbody2D _rigBody;
    private bool faceRight=true;
    
    private void Awake()
    {
        WhatIsGround = LayerMask.GetMask("Ground");
        GroundCheck = transform.Find("GroundCheck");
        _rigBody = gameObject.GetComponent<Rigidbody2D>();
        

    }

    public void Attack()
    {
        if(gameObject.GetComponent<IAttack>()!=null)
        {
            gameObject.GetComponent<IAttack>().Attack();
        }
    }
    public void MoveHorizontal(float direction)
    {
        //辅助跳跃判断
        if (GroundCheck!=null)
        {
           
            if (IsGrounded())
            {

                _entity.ReplaceJumpTimes(_entity.jumpTimes.MaxJumpTimes, _entity.jumpTimes.MaxJumpTimes);
            }
        }
        


       
        //Rigidbody2D _rigBody = this.gameObject.GetComponent<Rigidbody2D>();
        _rigBody.velocity= new Vector2(direction * _entity.speed.speed, _rigBody.velocity.y);
       
        if(faceRight && _rigBody.velocity.x<0) //向左转
        {
            Flip();
        }
        else if(!faceRight&&_rigBody.velocity.x>0)
        {
            Flip();
            
        }

        if(_animator!=null)
        {
            if(_animator.GetFloat("HorizontalSpeed")!=null)
                _animator.SetFloat("HorizontalSpeed", Mathf.Abs(_rigBody.velocity.x));
        }
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
    public void Flip()
    {
        //faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        if (_entity.hasHPUi)
        {
            Vector3 scale1 = transform.Find(("HPUITransform")).gameObject.transform.localScale;
            scale1.x *= -1;
            transform.Find(("HPUITransform")).gameObject.transform.localScale = scale1;
        }
    }

    /// <summary>
    /// 用于创造一个物体并将创造出这个物体的物体传进被创造的物体，通常是技能，在每个特定的技能释放方法里调用
    /// </summary>
    /// <param name="name"></param>
    public void CreatGameObject(string name)
    {    
        CreatedObject go = GameObject.Instantiate(_contexts.meta.gameSetup.value.AttackObject);
        go._gameObject = this.gameObject;
    }
}
