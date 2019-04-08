using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(AudioSource))]
public class HeartToGet : MonoBehaviour
{
  //   public AudioClip GotSomething;
     public AudioSource audioGot;

    private void Start()
    {
        audioGot = GetComponent<AudioSource>();
    }

    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        CharacterInCampaighController character = collider.GetComponent<CharacterInCampaighController>();

        if (character)
        {
            character.Lives++;
            //           audioGot.PlayOneShot(GotSomething, 1.0F);
            audioGot.Play();
            Destroy(gameObject);
        }
    }
}
