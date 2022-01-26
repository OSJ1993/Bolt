using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    enum State
    {
        Idle,
        Walk,
        Clicker,
        Pick
    }

    Animator anim;
    SpriteRenderer sp;

    float SpeedX;
    float SpeedY;

    State state = State.Idle;


    void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();

        //랜덤하게 3~5 초 정도 움직일 수 있게
        int Rand = Random.Range(3, 5);


        Invoke("RandState", Rand);
    }

    public void RandState()
    {
        int Rand = Random.Range(3, 5);

        //걷거나 멈춰있거나 둘 중에 하나에 따라서 이동 값이 바뀐다.
        state = (State)Random.Range(0, 2);
        Debug.Log((int)state);
        float ran = Random.Range(-0.8f, 0.8f);
        SpeedX = ran;
        SpeedY = ran;

    }


    void Update()
    {
        //방향에 따라서 스프라이트 바꿔주기
        if (SpeedX < 0)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }

        switch (state)
        {
            case State.Idle:
                anim.SetBool("isWalk", false);
                break;
            case State.Walk:
                anim.SetBool("isWalk", true);
                transform.Translate(SpeedX * Time.deltaTime, SpeedY * Time.deltaTime, SpeedY * Time.deltaTime);
                break;
        }
    }
}
