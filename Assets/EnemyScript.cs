using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public LogicScript logic;

    public float skelSpeed = 20;
    public float skelHealth = 100;
    public float playerDistanceX;
    public float playerDistanceY;
    public float attackDelay;
    public float attackCooldown;

    private float delayTimer;
    private float cooldownTimer;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk", false);
        playerDistanceX = transform.position.x - player.transform.position.x;
        playerDistanceY = transform.position.y - player.transform.position.y;

        if (playerDistanceX > 20 && playerDistanceX > -130)
        {
            transform.position += Vector3.left * skelSpeed * Time.deltaTime;
            anim.SetBool("walk", true);
        }
        if (playerDistanceX < -20 && playerDistanceX < 130)
        {
            transform.position += Vector3.right * skelSpeed * Time.deltaTime;
            anim.SetBool("walk", true);
        }
        if (playerDistanceX > 0)
        {
            transform.localScale = new Vector3(-50, 50, 50);
        }
        else
        {
            transform.localScale = new Vector3(50, 50, 50);
        }

        if (playerDistanceX <= 20 && playerDistanceX >= -20)
        {
            Attack();
            
            if (cooldownTimer > 1.25)
             {
                anim.SetTrigger("attck");
                cooldownTimer = 0;

             }
             else
             {
                cooldownTimer += Time.deltaTime;

             }     
        }
        else
        {
            anim.SetTrigger("sheathe");
        }
    }
    
    
    //Launch an attack
    public void Attack()
    {
        
        delayTimer += Time.deltaTime;
        if (delayTimer >= 0.75)
        {
            if (playerDistanceX <= 25 && playerDistanceX >= -25 && playerDistanceY >= -20 && playerDistanceY <= 20)
            {
                logic.damagePlayer(10);
                delayTimer = 0;
               
            }
            
        }       
    }
}
