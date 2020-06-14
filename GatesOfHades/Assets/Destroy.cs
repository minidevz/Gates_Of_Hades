using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float tiem = 5f;

    void Start()
    {
        Destroy(gameObject, tiem);
    }

  
}
