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
        float horizontalmove = Input.GetAxis("Horizontal");//获取其移动方向，horizontal指的是横向,然后赋值给horizontalmove，当玩家往左它的值为-1，不动0，右1;
        float facedirection = Input.GetAxisRaw("Horizontal");//GetAxisRaw的意思是只获取-1，0，1而不是（-1，1）的任何数，在scale中x的正和负可以改变人物方向
        if(horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);//velocity刚体速度变化,vector2:2d平面上xy轴的变化，横向移动y轴不动

        }
        if(facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);//transform是缩放比例所在的函数栏，因为scale是三维的，所以vector3，只改变x变量
        }
    }
}
