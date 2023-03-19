using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerHP = 100;
    public int bulletsLeft = 6;
    public Text playerHealth;
    public Text bulletCount;
    public Text reloadText;

    private float timer = 0;
    public float reloadTime;

    public void damageplayer(int health)
    {
        playerHP -= health;
        playerHealth.text = playerHP.ToString();
    }

    public void reduceBullets()
    {
        bulletsLeft -= 1;
        bulletCount.text = bulletsLeft.ToString();
    }

    void Update()
    {
        if (bulletsLeft <= 0)
        {
            reload(true);
            timer += Time.deltaTime;
            if (timer >= reloadTime)
            {
                bulletsLeft = 6;
                timer = 0;
                reload(false);
                bulletCount.text = bulletsLeft.ToString();
            }
        }
        else
        {
            reload(false);
        }
    }

    public void reload(bool show)
    {
        if (show == true)
        {
            reloadText.text = "RELOADING...";
        }
        else
        {
            reloadText.text = "";
        }
    }
}
