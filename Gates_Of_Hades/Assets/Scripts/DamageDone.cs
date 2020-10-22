using GatesOfHades.Shake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDone : MonoBehaviour
{
    //Ibrahim Hisham, Copyright Minidevs. 2019

    #region Variables
    public float health;
    public float maxHealth = 20f;
    public GameManager game;
    public AudioSource wolfy;
        #endregion
    void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().GameWin();
        }
    }
    public void TakeDamage()
    {
        health -= 1f;
        CameraShake.ShakeOnce();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            wolfy.Play();
        }
    }
}
