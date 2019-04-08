using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public void PlayFighting() //для кнопки "Fighting" в PlayMenu в сцене main
    {
        Application.LoadLevel(2); //открываем боевую сцену (сетевая игра)
    }

    public void SkipIntro() //для пропуска интро и перехода в меню
    {
        Application.LoadLevel(1); //открываем меню
    }

    public void PlaCampaign() //для кнопки "Level1" в сцене ChoiceOfLevel
    {
        Application.LoadLevel(3); //открываем сцену уровня 1 кампании (платформер)
    }

    public void PlayArcada() //для кнопки "OnePlayer" в PlayMenu в сцене main
    {
        Application.LoadLevel(4); //открываем сцену кампании (платформер)
    }

    public void ChoiceLevelInCampaign() //для кнопки "Campaign" в PlayMenu в сцене main
    {
        Application.LoadLevel(6); //открываем сцену выбора уровня кампании (платформер)
    }

    public void PlayCampaign2() //для кнопки "Level2" в сцене ChoiceOfLevel
    {
        Application.LoadLevel(7); //открываем сцену уровня 2 кампании (платформер)
    }

    public void Exit() //для кнопки крестик (exit) в сцене main
    {
        Application.Quit(); //выход из приложения
    }
}
