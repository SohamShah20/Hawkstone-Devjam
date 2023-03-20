using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
  
    public int bulletsLeft = 6;
    public int skullCount = 0;
    public Text playerHealth;
    public Text bulletCount;
    public Text reloadText;
    public Text skelLeft;
    public int playerHP = 100;

    private float timer = 0;
    public float reloadTime;

    public void damagePlayer(int health)
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

        if (playerHP == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        if (skullCount == 9)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
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

    public void skullPlus()

    {
        skullCount += 1;
        skelLeft.text = (9 - skullCount).ToString();
    }
    public void PlayerDeath()
    {
       
    }
}
