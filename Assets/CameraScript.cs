using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float maxSpeed = 50;
    public float speed = 0;
    public GameObject player;
    private float accelRate = 100;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            if ((player.transform.position.x - transform.position.x) > 15)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                accel(accelRate);
            }
        }
        if (Input.GetKey("a"))
        {
            if ((player.transform.position.x - transform.position.x) < -15)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                accel(accelRate);
            }
        }
        if (Input.GetKeyUp("d") || Input.GetKeyUp("a"))
        {
            speed = 0;
        }
    }

    public void accel(float rate)
    {
        if (speed < maxSpeed)
        {
            speed += Time.deltaTime * rate;
        }
    }
 }