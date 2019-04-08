using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficult : MonoBehaviour
{
    public HPBar hpBar;//ссылка на класс
    public GameObject panel; //панель

    void Start()
    {
        Time.timeScale = 0; //пауза в игре перед началом выбора сложности
        panel.SetActive(true); //панель с кнопками выключена
    }

    public void PanelActive()
    {
        panel.SetActive(true); //панель с кнопками включена
    }

    public void FirstDifficult() //первый уровень сложности
    {
        hpBar.HP = 100; //100 хп
        hpBar.maxHP = 100; //лимит, чтобы аптечка не давала больше 100 хп
        hpBar.slide.maxValue = 100; //слайдер имеет 100 хп
        Time.timeScale = 1; //игра выйдет из паузы при выборе сложности
        panel.SetActive(false); //панель закроется после выбора сложности
        GetComponent<AudioSource>().Play(); //проигрывание фоновой музыки
    } 

    public void TwoDifficult()//второй уровень сложности
    {
        hpBar.HP = 60;//60 хп
        hpBar.maxHP = 60;//лимит, чтобы аптечка не давала больше 60 хп
        hpBar.slide.maxValue = 60;//слайдер имеет 60 хп
        Time.timeScale = 1;//игра выйдет из паузы при выборе сложности
        panel.SetActive(false);//панель закроется после выбора сложности
        GetComponent<AudioSource>().Play();//проигрывание фоновой музыки
    }

    public void ThreeDifficult()//третий уровень сложности
    {
        hpBar.HP = 20;//20 хп
        hpBar.maxHP = 20;//лимит, чтобы аптечка не давала больше 20 хп
        hpBar.slide.maxValue = 20;//слайдер имеет 20 хп
        Time.timeScale = 1;//игра выйдет из паузы при выборе сложности
        panel.SetActive(false);//панель закроется после выбора сложности
        GetComponent<AudioSource>().Play();//проигрывание фоновой музыки
    }
}
