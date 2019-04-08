using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStop : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private float z, y, x;
    
    void Start()
    {
        if (target)
        {
            Vector3 position = target.position;
            z = position.z;
            y = position.y;
            x = position.x;
        }
    }
    
    private void Update()
    {
        if (target)
        {
            if (z > 0)
            {
                transform.position = new Vector3(x, y + 4.0f, z - 3.0f); //были -
            }

            if (z < 0)
            {
                transform.position = new Vector3(x, y + 4.0f, z + 3.0f);
            }
        }
    }

    

}
