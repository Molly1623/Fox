using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;//public������һ��������������unity����
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
        horizontalmove = Input.GetAxis("Horizontal");//��ȡ���ƶ�����horizontalָ���Ǻ���,Ȼ��ֵ��horizontalmove���������������ֵΪ-1������0����1
        if(horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);//velocity�����ٶȱ仯,vector2:2dƽ����xy��ı仯�������ƶ�y�᲻��

        }
    }
}
