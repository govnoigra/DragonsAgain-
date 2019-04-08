using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersForDragonsEnemies : MonoBehaviour
{
    public GameObject PanelWithDragon;


    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterInCampaighController character = other.GetComponent<CharacterInCampaighController>();
        //       if (other.tag=="Player")
        if (character)
        {
            PanelWithDragon.SetActive(true);
        }
    }
}
