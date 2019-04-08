using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace : MonoBehaviour
{
    public GameObject Respawn;


    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterInCampaighController character = other.GetComponent<CharacterInCampaighController>();
 //       if (other.tag=="Player")
           if (character)
        {
            other.transform.position = Respawn.transform.position;
            character.Lives--;
        }
     //      if  (character.Lives == 0)
    }
}
