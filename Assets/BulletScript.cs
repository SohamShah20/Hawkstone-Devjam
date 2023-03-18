using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject player;
    public float bulletSpeed = 50;
    public float direction;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        direction = player.transform.localScale.x / 75;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * bulletSpeed * Time.deltaTime * direction;
        if ((transform.position.x - camera.transform.position.x) > 100 || (transform.position.x - camera.transform.position.x) < -100)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "player")
        {
            Destroy(gameObject);
        }
    }
}
