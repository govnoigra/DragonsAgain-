using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HPBar : MonoBehaviour
{
    public int HP; //публичная переменная здоровья
    public int maxHP = 100;
    public Slider slide; //ccылка на слайд
    public GameObject explosionPlayer; //содержит ссылку на визуальный эффект взрываа дракона
    private GameObject cloneExplosion;
    public Text gameOverText;//содержит ссылку на наш текстовый объект
    private bool gameover; //логическая переменная для отслеживания конца игры
    private bool restart; //логическая переменная для отслеживания рестарта игры
    public GameObject restartButton; //ссылка на кнопку рестарта

    private void Start()
    {
        restart = false;
        restartButton.SetActive(false); //чтобы кнопка вначале игры была невидна
        gameOverText.text = "";//начальные значения для текстовых объектов

    }

    private void OnTriggerEnter(Collider other) //отвечает вход в триггер
    {
        if(other.tag == "Enemy") //если объект имеет тег Enemy
        {
            HP = HP - 20; //то при сокприкосновении с объектом наше здоровье уменьшается на 25
            Destroy(other.gameObject); //удаление снаряда или врага дракона
        }

        if (other.tag == "Boss") //если объект имеет тег Boss
        {
            HP = HP - 50; //то при сокприкосновении с объектом наше здоровье уменьшается на 50
            cloneExplosion = Instantiate(explosionPlayer, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject; //клонирование. Удаляем камни и дракона + удаление оставшейся визуальной части(клона)
            Destroy(cloneExplosion, 1f); ////удаление через определенный промежуток времени
        }

        if (other.tag == "Apteka") //если объект имеет тег Аптека
        {
            HP = HP + 40; //то при соприкосновении с ним будет пополнено здоровье дракона
            Destroy(other.gameObject); //удаление аптечки
        }
    }

    void Update()
    {
        slide.value = HP; //слайд равен 100
        

        if (HP < 1) //если наше здоровье меньше 1
        {
            Destroy(gameObject); //удаление дракона
            GameOver();
            restartButton.SetActive(true); //метод сетактив делает объект активным и видимым, если передаваемое значение тру
            restart = true;
        }

        if(HP > maxHP) //чтобы здоровье дракона не переваливало за 100
        {
            HP = maxHP;
        }
    }

    public void GameOver() //код для надписи конец игры
    {
        gameOverText.text = "Конец игры!"; //выводим на экран текст
    }

}
