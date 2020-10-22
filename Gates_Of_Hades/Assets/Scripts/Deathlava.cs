using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathlava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            transform.GetComponentInParent<GameManager>().GameOver();
        }
    }
}
