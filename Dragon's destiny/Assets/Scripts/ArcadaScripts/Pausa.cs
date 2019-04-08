using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    bool paused; //логическая переменная паузы
    public GameObject panelpausa; // ссылка на панель паузы с текстом
    void Start()
    {
        //panelpausa.SetActive(false); //панель неактивна при старте игры
        paused = false; //значение паузы 0
    }

    public void Pausebutton() //функция для вызова через кнопку
    {
        panelpausa.SetActive(!panelpausa.activeSelf);

        if (!paused) //если не пауза равна 1
        {
            Time.timeScale = 0; //то ставим паузу
                                //         GetComponent<AudioSource>().Stop(); // звук фона выключаем
    //        panelpausa.SetActive(true); //панель паузы активируем
            paused = true; //значение паузы равно 1
        } else //иначе
        {
            Time.timeScale = 1; //убираем паузу
  //          GetComponent<AudioSource>().Play(); //включаем фоновую музыку
      //      panelpausa.SetActive(false); //панель паузы убираем
            paused = false; //значение паузы равно 0
        }
    }

    public void PauseButtonInPAnel()
    {
        Time.timeScale = 1;
        paused = false;
        panelpausa.SetActive(false);
    }
}
