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

        //�����ϰ� 3~5 �� ���� ������ �� �ְ�
        int Rand = Random.Range(3, 5);


        Invoke("RandState", Rand);
    }

    public void RandState()
    {
        int Rand = Random.Range(3, 5);

        //�Ȱų� �����ְų� �� �߿� �ϳ��� ���� �̵� ���� �ٲ��.
        state = (State)Random.Range(0, 2);
        Debug.Log((int)state);
        float ran = Random.Range(-0.8f, 0.8f);
        SpeedX = ran;
        SpeedY = ran;

    }


    void Update()
    {
        //���⿡ ���� ��������Ʈ �ٲ��ֱ�
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
