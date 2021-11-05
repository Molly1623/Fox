using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;//public会生成一个变量，出现在unity界面
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float horizontalmove;
        horizontalmove = Input.GetAxis("Horizontal");//获取其移动方向，horizontal指的是横向,然后赋值给horizontalmove，当玩家往左它的值为-1，不动0，右1
        if(horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);//velocity刚体速度变化,vector2:2d平面上xy轴的变化，横向移动y轴不动

        }
    }
}
