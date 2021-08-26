using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//젤리처럼 위아래로 꾸물대다가 총알을 맞으면 파편이 튀면서 죽는다.
//공격성 없음

public class toni_JellyMove : MonoBehaviour
{
    public float speed = 0.1f;


    //폭발 공장 주소
    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.back;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            //print("OnCollisionEnter");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        //else if (other.gameObject.tag == "Melee")
        //{
        //GameObject explosion = Instantiate(explosionFactory);
        //explosion.transform.position = transform.position;
        ////print("OnCollisionEnter");
        //    Destroy(gameObject);
        //}
    }
}
