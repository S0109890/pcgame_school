using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toni_PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    Animator anim;
    Rigidbody rbBullet;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position;
            rbBullet = bullet.GetComponent<Rigidbody>();
            rbBullet.velocity = firePosition.transform.forward * 40;
            anim.SetTrigger("doShot");
        }
    }
}
