using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ActionManager : MonoBehaviour
{
    [Header("Charon")]
    public Rigidbody2D rbBoat;
    public Transform boat;
    public Vector3 offset;
    public GameObject tele;
    public AudioSource whoosh;
    public void CharonAction()
    {
        whoosh.Play();
        Instantiate(tele, transform.position, Quaternion.identity);
        transform.position = boat.position + offset;
        transform.SetParent(boat);
        transform.Find("Dialogue").gameObject.SetActive(false);
        rbBoat.isKinematic = false;
       
        

    }








}