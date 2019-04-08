using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinToGet : MonoBehaviour
{
 /*   private CharacterInCampaighController character;
    public int AllCoins = 0; //переменная, которая хранит общее количество монет
    public Text coinsNumber; //ссылка на текст монет
    [SerializeField]
    private int CurrentCoins; //количество монет, набранных за этот уровень
    */
  //  public AudioClip GotSomething;
    public AudioSource audioGot;
    public CoinsBar coinsBar;

 /*   private void Awake()
    {
        character = FindObjectOfType<CharacterInCampaighController>();
        UpdateCoins(); //вызов кол-ва монет на экран в начале игры, чтобы видеть, что монет 0
    }
    */
    private void Start()
    {
      //  CurrentCoinsFromCointToGet.CurrentCoins = 0;
       audioGot = GetComponent<AudioSource>();
    }

  /*  private void Update()
    {
        coinsBar = getCurrentCoins;
    }
*/
    /*  private void OnTriggerEnter2D(Collider2D collider)
      {
          CharacterInCampaighController character = collider.GetComponent<CharacterInCampaighController>();

          if (character)
          {
      //        audioGot.Play();
              CurrentCoins += 10;
              UpdateCoins();
              Destroy(gameObject);
          }
      }

  */

    private void OnTriggerEnter2D(Collider2D collider)
    {
        CharacterInCampaighController character = collider.GetComponent<CharacterInCampaighController>();

        if (character)
        {
            coinsBar.CurrentCoins += 10; ;
            //           audioGot.PlayOneShot(GotSomething, 1.0F);
            audioGot.Play();
            Destroy(gameObject);
        }
    }

  /*  void UpdateCoins() //функция, работающая с монетами
    {
        coinsNumber.text = "" + CurrentCoins; //передача значения монет на экран
    }
    */
}
