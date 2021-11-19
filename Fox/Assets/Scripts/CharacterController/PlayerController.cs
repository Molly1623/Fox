using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;//public会生成一个变量，出现在unity界面
    public float speed;
    private Animator anim;
    public Collider2D coll;
    public float jumpforce;
    public LayerMask ground;
    public int Cherry =0;
    public Text CherryNum;
    private bool isHurt;//布尔值默认是false
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isHurt)
        {
            Movement();
        }
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
        if(Input.GetButtonDown("Jump"))//&&coll.IsTouchingLayers(ground)
        {
            if (coll.IsTouchingLayers(ground))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
                anim.SetBool("IsJump", true);
            }
        }
    }
    //切换动画效果
    void SwitchAnim()
    {
        anim.SetBool("Idle", true);
        if (isHurt)
        {
            anim.SetBool("Hurt", true);
            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anim.SetBool("Hurt", false);
                anim.SetBool("Idle", true);
                isHurt = false;
            }
        }
        else if (anim.GetBool("IsJump"))
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            Cherry += 1;
            CherryNum.text = Cherry.ToString();
        }
    }
    //消灭敌人
    private void OnCollisionEnter2D(Collision2D collision)//OnCollisonEnter2D效果发生时
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            if (anim.GetBool("Falling"))
            {
                Destroy(collision.gameObject);
                rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
                anim.SetBool("IsJump", true);
            }
            else if(transform.position.x<collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-5, rb.velocity.y);
                isHurt = true;
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(5, rb.velocity.y);
                isHurt = true;
            }
        }
    }
}
