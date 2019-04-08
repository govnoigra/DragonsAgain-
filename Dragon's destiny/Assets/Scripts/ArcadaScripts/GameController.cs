using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //доступ к компонентам юай
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards; //публичная переменная, куда закидывается префаб камней. hazards стал массивом из-за []
    public Vector3 spawnValues; //переменная для указания стартовой позиции камней
    public int hazardCount; //переменная, для создания нескольких камней
    public float spawnWait; //переменная, для создания промежтука времени появления камней(если будет значение 1, то 1 камень каждую секунду, если 2, то 1 камень каждые 2 секунды)
    public float startWait; //переменная времени начала генерации волны(пауза в секундах)
    public float waveWait; //пауза между волнами камней( в секундах)
    public Text scoreText; //содержит ссылку на наш текстовый объект, содержащий счет
    public int record; //переменная, которая хранит рекорд
    public Text recordtext; //ссылка на текст рекорда
    private int score; //переменная, которая хранит наши очки
    public GameObject restartButton; //ссылка на кнопку рестарта

    private void Start()
    {
        score = 0; //вначала игры кол-во очков 0
        UpdateScore(); //вызов кол-ва очков на экран в начале игры, чтобы видеть, что очков 0
        StartCoroutine(SpawnWaves()); //вызов функции при старте сцены. StartCoroutine потому что используем функцию IEnumerator
    }

    void Update()
    {
        if (score > record)
        {
            PlayerPrefs.SetInt("savescore", score);
            PlayerPrefs.Save();
            Debug.Log("Save");
        }

        record = PlayerPrefs.GetInt("savescore");
        recordtext.text = "Рекорд: " + record;
    }

    public void DeleteRecord()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Delete");
    }

    IEnumerator SpawnWaves() //функция, отвечающая за волну камней. Возвращает не значения, а код выполнения. Тип возвращаемого значения интерфейс
    {
        yield return new WaitForSeconds(startWait); //для создания задержек появления кода. Каждый раз, когда код доходит до yield return осуществляется выход из функции и программа продолжает свою работу, а когда проходит время, программа возвращается к следующей строке после yield return

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); //рандомизация появления летящих камней
                Quaternion spawnRotation = Quaternion.identity; //означает, что у объекта отсутвует вращение

                GameObject hazard = hazards[Random.Range(0, hazards.Length)]; //Из массива случайным образом будет выбираться одна из 3 ссылок. Будем выбрано число между 0 и длинной массива hazards
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(Random.Range(0.5f, spawnWait)); //рандомизация появления камней. для создания задержек появления кода. Каждый раз, когда код доходит до yield return осуществляется выход из функции и программа продолжает свою работу, а когда проходит время, программа возвращается к следующей строке после yield return
            }
            yield return new WaitForSeconds(waveWait); //для создания задержек появления кода. Каждый раз, когда код доходит до yield return осуществляется выход из функции и программа продолжает свою работу, а когда проходит время, программа возвращается к следующей строке после yield return

        }

    }

    void UpdateScore() //функция, работающая с очками
    {
        scoreText.text = "Счет: " + score; //передача значения очков на экран
    }

    public void AddScore(int newScoreValue) //код для обновления значений очков
    {
        score += newScoreValue; //код для обновления значений очков
        UpdateScore(); //вывод кол-ва очков на экран
    }

    
}