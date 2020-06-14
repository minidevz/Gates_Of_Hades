using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleGive : MonoBehaviour
{
    public Vector3 orgPos;
    public Animator anim;
   public bool onBoat;
    public LayerMask water;
    private Collider2D CurrFector;
    public AudioSource PaddleSound;
    private void Start()
    {
        orgPos = transform.position;
       
    }
    public void Update()
    {
        if (Input.GetButtonDown("Attack") && onBoat == true)
        {
            anim.SetBool("Paddling", true);
            CurrFector.GetComponent<BuoyancyEffector2D>().flowMagnitude = 20;
            if (!PaddleSound.isPlaying)
            {
                PaddleSound.volume = Random.Range(0.8f,1f);
                PaddleSound.pitch = Random.Range(0.8f,1f);
                PaddleSound.Play();

            }

        }  else if (Input.GetButtonUp("Attack") && onBoat == true)
        {
            anim.SetBool("Paddling", false);
            CurrFector.GetComponent<BuoyancyEffector2D>().flowMagnitude = 0;
        }

        if(!onBoat)
        {
            PaddleSound.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.Find("Body").Find("Spear").gameObject.SetActive(false);
            collision.GetComponent<PalyerMove>().enabled = false;
            onBoat = true;
        }

        }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
       if (collision.tag == "Player")
        {
            anim.transform.position = collision.transform.Find("Hand").position;
            Collider2D currFector = Physics2D.OverlapCircle(transform.position, 4.5f, water);
            CurrFector = currFector;

            if (onBoat == false)
            {
                collision.GetComponent<PalyerMove>().enabled = true;
            }
            else
            {
                collision.GetComponent<PalyerMove>().enabled = false;
            }
         }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            transform.position = orgPos;
            collision.transform.Find("Body").Find("Spear").gameObject.SetActive(true);
            collision.GetComponent<PalyerMove>().enabled = true;
            onBoat = false;
        }
    }
}
