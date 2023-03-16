using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D PlayerInfo;
    public float maxSpeed = 50;
    public float direction = 1;
    private float speed = 0;
    public float accelRate = 100;
    private bool grounded;
    private bool doubleJump = false;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(direction, 1, 1);
        if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            accel(accelRate);
            direction = 1;
        }
        if (Input.GetKey("a"))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            accel(accelRate);
            direction = -1;
        }
        if (Input.GetKeyDown("w"))
        {
            if (grounded == true)
            {
                jump(40);
            }
            else if (doubleJump == true)
            {
                jump(40);
                doubleJump = false;
            }
        }
        if (Input.GetKeyUp("d") || Input.GetKeyUp("a"))
        {
            speed = 0;
        }
        if (Input.GetKeyDown("space"))
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }
    }

    public void accel(float rate)
    {
        if (speed < maxSpeed)
        {
            speed += Time.deltaTime * rate;
        }
    }

    void jump(float Jpower)
    {
        if (PlayerInfo.velocity.y <= 0)
        {
            PlayerInfo.velocity = Vector2.zero;
        }
        PlayerInfo.velocity += Vector2.up * Jpower;
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            doubleJump = true;
        }
    }
}
