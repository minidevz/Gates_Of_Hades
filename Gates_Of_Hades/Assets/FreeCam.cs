using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public bool isEnabled;
    public float sensitivityX = 8F;
    public float sensitivityY = 8F;
    float mHdg = 0F;
    float mPitch = 0F;
   
  
    void Update ( )
    {
        if(isEnabled)
        { 
        float deltaX = Input.GetAxis("Horizontal") * sensitivityX * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * sensitivityY * Time.deltaTime;
        transform.Translate(deltaX, deltaY , 0);
        }
    }

}
