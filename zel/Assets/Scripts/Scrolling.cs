using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{


    public float speed = 0.1f;



    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x > 8)
        {
            transform.Translate(new Vector3(-16, 0, 0));
        }

    }
}
