using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForMenu : MonoBehaviour
{
    private Fire fire;

    private void Awake()
    {
        fire = Resources.Load<Fire>("Fire"); //подгружаем префаб огня для выстрела
        Time.timeScale = 1;
    }

    public void Shoot()
    {
        Vector3 position = transform.position;
        position.x = 5.0F;
        position.y = 2.1F;
        position.z = 1.2F;
        fire.transform.rotation = Quaternion.Euler(180, 90, 0);
        Fire newFire = Instantiate(fire, position, fire.transform.rotation) as Fire;

        newFire.Direction = - newFire.transform.right;
    }
}
