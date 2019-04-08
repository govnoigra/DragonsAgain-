using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyBuContact : MonoBehaviour
{
    public GameObject explosion; //публичная переменная, которая будет ссылаться на визуальный объект взрыва
    public GameObject explosionPlayer; //содержит ссылку на визуальный эффект взрываа дракона

    private GameObject cloneExplosion;

    public int scoreValue; //будет передать установленное кол-во очков за каждый уничтоженный камень
    private GameController gameController; //создаем ссылку на другой скрипт

    private void Start()
    {
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

     private void OnTriggerEnter(Collider other)//описываем триггер
      {

          if (other.tag == "Player") //тег(нужен для правильной работы)
          {
              cloneExplosion = Instantiate(explosionPlayer, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject; //клонирование. Удаляем камни и дракона + удаление оставшейся визуальной части(клона)
              Destroy(cloneExplosion, 1f); ////удаление через определенный промежуток времени
          }

          if (other.tag == "Bolt") //тег(нужен для правильной работы)
          {
              cloneExplosion = Instantiate(explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject; //клонирование. Удаляем камни и дракона + удаление оставшейся визуальной части(клона)
              Destroy(other.gameObject); //удаление снаряда
              Destroy(gameObject); //удаление камня
              Destroy(cloneExplosion, 1f); //удаление через определенный промежуток времени
              gameController.AddScore(scoreValue);
          }
      }

}
        


