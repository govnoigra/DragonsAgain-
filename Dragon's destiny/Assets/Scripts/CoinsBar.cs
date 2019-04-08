using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsBar : MonoBehaviour
{
    private CharacterInCampaighController character;
    public int AllCoins = 0; //переменная, которая хранит общее количество монет
    public Text coinsNumber; //ссылка на текст монет
   // [SerializeField]
 //   public int CurrentCoins; //количество монет, набранных за этот уровень
    [SerializeField]   //чтобы приватные отображались в инспекторе
    private int currentCoins = 0; //жизни

    public int CurrentCoins
    {
        get { return currentCoins; }
        set
        {
            currentCoins = value;

            UpdateCoins();
        }
    }

    private LivesBar livesBar;


    private void Awake()
    {
        character = FindObjectOfType<CharacterInCampaighController>();
        UpdateCoins(); //вызов кол-ва монет на экран в начале игры, чтобы видеть, что монет 0
    }

    private void Start()
    {
        CurrentCoins = 0;
    }


/*    private void OnTriggerEnter2D(Collider2D collider)
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
    void UpdateCoins() //функция, работающая с монетами
    {
        coinsNumber.text = "" + CurrentCoins; //передача значения монет на экран
    }
}
