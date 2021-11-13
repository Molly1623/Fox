using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;//public会生成一个变量，出现在unity界面
    public float speed;
    private Animator anim;
    public Collider2D coll;
    public float jumpforce;
    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        SwitchAnim();
    }
    void Movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");     
        float facedirection = Input.GetAxisRaw("Horizontal");

        //水平移动  
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove*speed* Time.deltaTime, rb.velocity.y);
            anim.SetBool("Run", true);
        }
        else if(horizontalmove == 0)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Run", false);
        }
        //判断面向左还是右
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
        }
        //角色跳跃
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
            anim.SetBool("IsJump", true);
        }
    }
    void SwitchAnim()
    {
        anim.SetBool("Idle", true);
        if(anim.GetBool("IsJump"))
        {
            if(rb.velocity.y < 0)
            {
                anim.SetBool("Falling", true);
                anim.SetBool("IsJump", false);
            }
        }
        else if(coll.IsTouchingLayers(ground))
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Idle", true);
            
        }
    }
}
