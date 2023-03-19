using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D PlayerInfo;
    public LogicScript logic;
    public float maxSpeed = 50;
    public float direction = 1;
    private float speed = 0;
    public float accelRate = 100;
    private bool grounded;
    private bool doubleJump = false;
    public GameObject Bullet;
    private Animator anim;
    public int playerHP;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(direction * 75, 75, 1);
        if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            accel(accelRate);
            direction = 1;
            anim.SetBool("walk", grounded);
           
        }
        if (Input.GetKey("a"))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            accel(accelRate);
            direction = -1;
            anim.SetBool("walk", grounded);
            
        }
        if (Input.GetKeyDown("w"))
        {
            if (grounded == true)
            {
                jump(50);
                anim.SetBool("walk", false);
            }
            else if (doubleJump == true)
            {
                jump(50);
                doubleJump = false;
                anim.SetBool("walk", grounded);
            }
        }
        if (Input.GetKeyUp("d") || Input.GetKeyUp("a"))
        {
            speed = 0;
            anim.SetBool("walk", false);
        }

        if (Input.GetKeyDown("space"))
        {
            if (grounded == true && logic.bulletsLeft > 0)
            {
                anim.SetTrigger("Shoot");
                logic.reduceBullets();
                Instantiate(Bullet, transform.position, transform.rotation);
                speed = 0;
            }       
            
        }
        else
        {
            anim.SetTrigger("parry");
        }

    }

    //acceleration
    public void accel(float rate)
    {
        if (speed < maxSpeed)
        {
            speed += Time.deltaTime * rate;
        }
    }

    //script for jumping
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
