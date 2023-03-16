using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject player;
    public float bulletSpeed = 50;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<GameObject>();
        direction = player.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * bulletSpeed * Time.deltaTime * direction;
    }
}
