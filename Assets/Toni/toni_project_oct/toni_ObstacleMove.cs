using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//장애물이 플레이어에 닿으면 플레이어 데미지가 손상된다.
//장애물은 플레이어를 랜덤으로 따라다닌다.
//-랜덤으로 따라다닌다: tail
//만약 장애물이 플레이어에 닿으면(공격), 플레이어 데미지를 손상시킴 & 충돌 
public class toni_ObstacleMove : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //플레이어를 찾아라
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.Find("Player");

        dir = target.transform.position - transform.position;
        dir.Normalize();
        rb.MovePosition(rb.transform.position + dir * speed * Time.deltaTime);

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}

