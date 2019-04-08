using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPBoss : MonoBehaviour
{
    public int HP = 200; //публичная переменная здоровья
    public Slider slideBoss; //ccылка на слайд
    public GameObject explosionPlayer; //содержит ссылку на визуальный эффект взрываа дракона
    private GameObject cloneExplosion;
    public GameObject explosion;
    public int scoreValue;
    private GameController gameController; //создаем ссылку на другой скрипт

    private void Start()
    {
        slideBoss.gameObject.SetActive(false); //по идее, должна деактивировать слайд жизей, но не работает

        GameObject GameControllerObject = GameObject.FindWithTag("GameController"); //код для поиска объекта геймконтроллер. Данная фнукция позволит найти первый объект в сцене, у которого присутвует тэг геймконтроллер. В игре он только один
        if (GameControllerObject != null) //проверка, является ли найденный объект ссылкой 
        {
            gameController = GameControllerObject.GetComponent<GameController>(); //присвает gameController ссылку на компонент гэймконтроллер

            if (GameControllerObject == null) //если после поиска ссылка равна null, то будет выводить сообщение в консоль об ошибке
            {
                Debug.Log("Скрипт 'GameController' не найден"); //вывод сообщения в консоль
            }
        }
    }

    private void OnTriggerEnter(Collider other) //отвечает вход в триггер
    {
        if (other.tag == "Bolt") //если объект имеет тег Bolt
        {
            HP = HP - 10; //то при сокприкосновении с объектом наше здоровье уменьшается на 25
            cloneExplosion = Instantiate(explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject; //клонирование. Удаляем камни и дракона + удаление оставшейся визуальной части(клона)
            Destroy(other.gameObject); //удаление снаряда
            Destroy(cloneExplosion, 1f); //удаление через определенный промежуток времени
            gameController.AddScore(scoreValue);
        }


        if (other.tag == "Player") //тег(нужен для правильной работы)
        {
            HP = HP - 10;
        }
    }

    public void Update()
    {
        slideBoss.value = HP; //слайд равен 200

        if (HP < 1) //если наше здоровье меньше 1
        {
            Destroy(gameObject); //удаление дракона
        }

        if(HP < 200)
        {
            slideBoss.gameObject.SetActive(true); //в теории активирует слайд жизней босса, но не работает
        }
    }
}
