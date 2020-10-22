using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GatesOfHades.Parallax
{

    public class Parallax : MonoBehaviour
{
        #region Variables
        Material material;  
        Vector2 offset;

        public float xVelocity, yVelocity;
		#endregion

		private void Awake ( )
        {
            material = GetComponent<Renderer>().material;
        }
		private void Start ( )
		{
            offset = new Vector2(xVelocity, yVelocity);
		}

		void Update()
        {
            material.mainTextureOffset += offset * Time.deltaTime;
        }
  
    }

}