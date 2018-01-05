using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float hpStart; // 캐릭터 시작 체력
    public float hpMax; // 캐릭터 최대 체력
    public float hpHealSec; // 초당 캐릭터 체력 회복력
    public float def; // 캐릭터 방어력
    public float spd; // 캐릭터 스피드

    public float rotateSpeed;

    Rigidbody rig;

    Vector3 movement;
    float horizontalMove;
    float verticalMove;

    Animator ani;

    public bool DontMove = false;

    public Text hp_Text = null;

    public GameManager gm;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        ani = gameObject.GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        hpStart = hpMax;
        StartCoroutine(HPHeal());
    }

    IEnumerator HPHeal() // 1초마다 hp회복
    {
        if (!DontMove)
        {
            if (hpStart < hpMax)
            {
                if(hpStart != 0)
                {
                    hpStart += hpHealSec;
                }
                if (hpStart > hpMax)
                {
                    hpStart = hpMax;
                }
            }
            yield return new WaitForSeconds(1);
            StartCoroutine(HPHeal());
        }
    }


    void Update()
    { // 키 입력은 여기서

        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

       
        if (horizontalMove == 0 && verticalMove == 0)
        {
            ani.SetBool("isMoving", false);
        }
        else
        {
            ani.SetBool("isMoving", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gm.ChangeCamera();
        }


        hp_Text.text = "HP : " + hpStart;

    }

    void FixedUpdate()
    {
        if (!DontMove)
        {
            Run();
            Die();
        }

    }

    //----------------------------------------------------------

    void OnCollisionEnter(Collision other)
    {
       if(other.transform.tag == "Enemy")
        {
            hpStart -= other.gameObject.GetComponent<EnemyState>().damage;

            Destroy(other.gameObject);
        }
    }

    //----------------------------------------------------------

    void Run()
    {
      
        movement.Set(horizontalMove, 0, verticalMove);
        movement = movement.normalized * spd * Time.deltaTime;

        rig.MovePosition(transform.position + movement);

        Turn();

    }


    void Turn()
    {
        if (horizontalMove == 0 && verticalMove == 0)
        {
            return;
        }

        Quaternion newRotation = Quaternion.LookRotation(movement);

        rig.rotation = Quaternion.Slerp(rig.rotation, newRotation, rotateSpeed * Time.deltaTime);
   }

    void Die()
    {
        if(hpStart <= 0)
        {
            hpStart = 0;
            ani.SetBool("Die", true);
            DontMove = true;
        }
    }
}