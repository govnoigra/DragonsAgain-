using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//для выпадающего меню с настройками
public class SettingsDropDown : MonoBehaviour
{
    public GameObject SettingsMenu; //выпадающее меню с кнопками для настроек

    //для кнопки "Settings" в сцене main
    public void ShowSettings()
    {
        SettingsMenu.SetActive(!SettingsMenu.activeSelf); ////при нажатии на кнопку "настройки" выпадающее меню становится активным (видимым), если оно было выключено, и наоборот
    }
}
