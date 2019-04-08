using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private Transform target;

    private void Awake()
    {
        if (!target) target = FindObjectOfType<CharacterInCampaighController>().transform; //если забыли перенести в инспекторе, то переносится программно
    }

    private void Update()
    {
        if (target)
        {
            Vector3 position = target.position;
            position.z = -10.0F;
            position.x += 3.5F;
            position.y = 2.5F;
            transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
        }
    }
}
