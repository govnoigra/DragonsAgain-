using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
  //  public AudioSource damageSound; 

    protected virtual void Awake() { }
    protected virtual void Start() { }
    protected virtual void Update() { }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Fire fire = collider.GetComponent<Fire>();

        if (fire)
        {
            ReceiveDamage();
   //         damageSound.Play();
        }

        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is CharacterInCampaighController)
        {
            unit.ReceiveDamage();
   //         damageSound.Play();
        }
    }
}
