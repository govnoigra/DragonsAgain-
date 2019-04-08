using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EndOfFirstLevel : MonoBehaviour
{
    public AudioSource EndOfLevel;
//    public GameObject panelOfEnd;

 //   public float delay;
 //   public float timerDelay = 2.0F;
    //   public StaticClassForPanel2 countOfOpen;

    /*public int countOfOpenLevel = 1;
    public int CountOfOpenLevel
    {
        get { return countOfOpenLevel; }
        set { countOfOpenLevel = value; }
    }
    */
    //   public GameObject panel2;
    private void Start()
    {
 //       delay = timerDelay;
  //      panelOfEnd.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterInCampaighController character = other.GetComponent<CharacterInCampaighController>();
        //       if (other.tag=="Player")
        if (character)
        {
 //           delay = delay - Time.deltaTime;
            EndOfLevel.Play();
            //          delay = delay - Time.deltaTime;
            //           Time.timeScale = 0;
    //        Thread.Sleep(2000);
  //          panelOfEnd.SetActive(true);
                  Application.LoadLevel(6);

            //          countOfOpenLevel = 2;
            //          CountOfOpenLevel = 2;
            //           StaticClassForPanel2.panel2.SetActive(true);
        }
    }

}
