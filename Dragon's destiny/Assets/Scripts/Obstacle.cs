using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
  //  public AudioSource damageSound;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is CharacterInCampaighController)
        {
            unit.ReceiveDamage();  //damageSound.Play();
        }
    }
}
