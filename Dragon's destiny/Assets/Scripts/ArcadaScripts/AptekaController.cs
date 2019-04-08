using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AptekaController : MonoBehaviour //комментарий под гэйм контроллер. Тут все про аптечку имеется ввиду
{
    public GameObject[] hazards; //публичная переменная, куда закидывается префаб камней. hazards стал массивом из-за []
    public Vector3 spawnValues; //переменная для указания стартовой позиции камней
    public int hazardCount; //переменная, для создания нескольких камней
    public float spawnWait; //переменная, для создания промежтука времени появления камней(если будет значение 1, то 1 камень каждую секунду, если 2, то 1 камень каждые 2 секунды)
    public float startWait; //переменная времени начала генерации волны(пауза в секундах)
    public float waveWait; //пауза между волнами камней( в секундах)

    private void Start()
    {
        StartCoroutine(SpawnWaves());//вызов функции при старте сцены. StartCoroutine потому что используем функцию IEnumerator
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
}
