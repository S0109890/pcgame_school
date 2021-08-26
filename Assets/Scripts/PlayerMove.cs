using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    float hAxis; //이동함수 업데이트
    float vAxis;
    float currentHealth = 100;
    float maxHealth = 100;
    float collisionDamage;
    
    


    Vector3 moveVec;

    //이동 -> 속력
    public float speed = 5;
    public GameObject weapon;
    public Camera followCamera;
    public AudioSource audioJump;
    public Slider healthBar;
   


    Rigidbody rb;
    Sword equipWeapon;
    Animator anim;
    MeshRenderer[] meshs;

    bool wDown;
    bool fDown; //get input 함수에서 사용
    bool jDown;
    bool isDamage;
    bool isFireReady;
    bool isAttack;
    float fireDelay;
    bool isJump;

    

    private void Awake()
    {
       anim = GetComponentInChildren<Animator>();
       meshs = GetComponentsInChildren<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        audioJump = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        //사용자가 누르면

        GetInput();
        Jump();
        
        
        hAxis = Input.GetAxis("Horizontal");//가로축만 가져옴
        vAxis = Input.GetAxis("Vertical");
        //엑스 제트 방향으로
        moveVec = new Vector3(hAxis, 0, vAxis);
        moveVec.Normalize();
        

      if (isAttack)
        { 
            moveVec = Vector3.zero;
        
        }
            transform.position += moveVec * speed * (wDown ? 1.5f : speed) * Time.deltaTime;        //이동한다 P0=V*T
                                                                                                    //rb.MovePosition(rb.transform.position + moveVec * speed* (wDown ? 1.5f : speed) * Time.deltaTime);

            //rb.MovePosition(rb.transform.position + moveVec * speed * Time.deltaTime);

            transform.LookAt(transform.position + moveVec); //회전시키는 코드
            anim.SetBool("isRun", moveVec != Vector3.zero);
            anim.SetBool("isWalk", wDown);
            //마우스에 의한 회전 총쏘기

            Ray ray = followCamera.ScreenPointToRay(Input.mousePosition);
            // input으로 마우스 위치값 넣는다 카메라 오브젝트느느 스크린포인트레이값을 가져올수있다
            RaycastHit rayHit; //쏴야한다
            if (Physics.Raycast(ray, out rayHit, 100))//out은 ray값을 hit으로 반환해준다 100은 길이크기
            {
                Vector3 nextVec = rayHit.point - transform.position; //함수의 빼기 이동
                nextVec.y = 0; // 높이 값을 없앤다.
                transform.LookAt(transform.position + nextVec);
            }
        

        Attack();
        NotAttack();


        healthBar.value = currentHealth / maxHealth;
        
    
    }
       
    

    void GetInput()
    {
        fDown = Input.GetButtonDown("Fire1");
       
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rb.AddForce(Vector3.up*7,ForceMode.Impulse);
            anim.SetTrigger("doJump");
            audioJump.enabled = true;
            isJump = true;

        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            TakeDamage(5);
            print(currentHealth);
        }
        else if (other.gameObject.tag == "Wind")
        {
            TakeDamage(10);
            print( currentHealth);
        }
        else if (other.gameObject.tag == "Floor")
        {
            isJump = false;
            audioJump.enabled = false;

        }

    }
  

    void Attack()
    {
        equipWeapon = weapon.GetComponent<Sword>();

        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDelay;

        if (fDown && isFireReady)
        {
            equipWeapon.Use();
            anim.SetTrigger("doSwing");
            fireDelay = 0;
            isAttack = true;

        }

    }
    void NotAttack()
    {
        if (!fDown)
        {
            isAttack = false;
        }
    }
    void FreezeRotation()
    {
        rb.angularVelocity = Vector3.zero;
    }
     void FixedUpdate()
    {
        FreezeRotation();
    }

    public void TakeDamage(int a)
       
    {
        currentHealth -= a;
        healthBar.value = currentHealth;
        if (currentHealth <=0)
        {
            Death();

        }
        else if (currentHealth <= 20)
        {
            speed = 1.5f;
        }
        else if (currentHealth <= 60)
        {
            speed = 2.7f;
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

    //IEnumerator OnDamage()
    //    {
    //        isDamage = true;
    //        foreach (MeshRenderer mesh in meshs)
    //        {
    //            mesh.material.color = Color.yellow;

    //        }
    //        yield return new WaitForSeconds(1f);

    //        isDamage = false;
    //        foreach (MeshRenderer mesh in meshs)
    //        {
    //            mesh.material.color = Color.white;
    //        }

    //    }


}
