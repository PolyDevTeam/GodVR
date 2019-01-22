using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    Animator anim;
    private float timeToChangeDirection;
    float Speed = 0.0f;

    public static bool first = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ChangeDirection();

        if(first)
        {
            Orc.first = false;
            for (int i = 0; i < 10; i++)
            {
                //Instantiate(this, new Vector3(i * 4.0F, 0, 0), Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        timeToChangeDirection -= Time.deltaTime;

        if (timeToChangeDirection <= 0)
        {
            ChangeDirection();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Speed = 0.6f;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Speed = 0.0f;
        }

        anim.SetFloat("Speed", Speed);

        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal"); // get result of AD keys in X
        moveDir.z = Input.GetAxis("Vertical"); // get result of WS keys in Z
                                               // move this object at frame rate independent speed:

        transform.position += moveDir * Speed * Time.deltaTime;
        //GetComponent<Rigidbody>().velocity = transform.up * 2;
    }

    private void ChangeDirection()
    {
        /*
        float angle = Random.Range(0f, 360f);
        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 newUp = quat * Vector3.up;
        newUp.z = 0;
        newUp.Normalize();
        transform.up = newUp;
        timeToChangeDirection = 1.5f;
        */
    }
}
