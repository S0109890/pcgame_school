using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//근접공격 원거리 공격 타입을 정하고
//속력을 부여하여 플레이어에 데미지를 입힌다

public class Sword : MonoBehaviour
{
    //근접공격 원거리 공격 타입을 정하고
    public enum Type { Melee, Range };
    public Type type;
    //속력을 부여하여 플레이어에 데미지를 입힌다
    public int damage;
    public float rate;
    //범위지정
    public BoxCollider meleeArea;
    //이펙트 넣는거
    public TrailRenderer trailEffect;
    public AudioSource audioEffect;
    //플레이어가 무기 사용 함수
    public Rigidbody rb;
    public GameObject explosionFactory;

    private void Start()
    {
    }


    public void Use()
    {
        if (type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");

        }
    }

    IEnumerator Swing()
    {
        //1
        yield return new WaitForSeconds(0.1f);
        meleeArea.enabled = true;
        trailEffect.enabled = true;
        audioEffect.enabled = true;
        
        Rigidbody swordRb = GetComponent<Rigidbody>();
        Vector3 caseVec = transform.forward * 20;

        //swordRb.AddTorque(Vector3.up * 10);


        yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        trailEffect.enabled = false;
        audioEffect.enabled = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Melee")
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            //print("OnCollisionEnter");
            Destroy(other.gameObject);
            print("Melee");
        }
    }
}
