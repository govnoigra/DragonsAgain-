using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebsiteDropDown : MonoBehaviour
{
    public GameObject WebsiteSureOrNot; //выпадающее меню с вопросом, точно ли вы хотите перейти на сайт игры

    //для кнопки "Website" в выпадающем меню настроек в сцене main
    public void AskIfYouSureToWebsite()
    {
        WebsiteSureOrNot.SetActive(!WebsiteSureOrNot.activeSelf); //при нажатии на кнопку "веб-сайт" выпадающее меню становится активным (видимым), если оно было выключено, и наоборот
    }

    //для кнопки "No" в выпадающем из "Website" меню
    public void StayInGameWithoutWebsite()
    {
        WebsiteSureOrNot.SetActive(!WebsiteSureOrNot.activeSelf); //при нажатии на кнопку "нет" выпадающее меню закрывается
    }
}
