using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//사용자의 입력에 따라 오른쪽,왼쪽, 앞, 뒤 이동하고자 함

public class toni_PlayerMove : MonoBehaviour
{
    //플레이어 체력
    public int hp = 20;

    //최대 체력 변수
    int maxHp = 20;

    //hp슬라이더 변수
    public Slider hpSlider;

    public float speed = 5;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //사용자의 입력에 따라 

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //오른쪽,왼쪽, 앞, 뒤 이동하고자 함
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        rb.MovePosition(rb.transform.position + dir * speed * Time.deltaTime);

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        //현재 플레이어 hp를 hp슬라이더의 value에 반영
        hpSlider.value = (float)hp / (float)maxHp;
    }
}
