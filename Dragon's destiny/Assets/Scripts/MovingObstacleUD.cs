using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacleUD : MonoBehaviour
{
    public float delay;
    public float timerDelay = 4.0F;
    public bool flag = true;
    public float xObstacle, yObstacle;

    private void Start()
    {
        delay = timerDelay;
        Vector3 position = gameObject.transform.position;
        xObstacle = position.x;
        yObstacle = position.y;
    }

    private void Update()
    {
        delay = delay - Time.deltaTime;
 //       Vector3 position = gameObject.transform.position;
        if (delay<=0)
        {
            if (flag)
            {
                yObstacle -= 0.8F;
                flag = false;

            } else
            {
                yObstacle += 0.8F;
                flag = true;
            }
            transform.position = new Vector3(xObstacle, yObstacle, 0);
            delay = timerDelay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is CharacterInCampaighController)
        {
            unit.ReceiveDamage();  //damageSound.Play();
        }
    }
}
