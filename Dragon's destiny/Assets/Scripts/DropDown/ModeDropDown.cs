using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//для выпадающего меню с режимами
public class ModeDropDown : MonoBehaviour
{
    public GameObject PlayMenu; //выпадающее меню с кнопками для выбора режима

    //для кнопки "Play" в сцене main
    public void Play()
    {
        PlayMenu.SetActive(!PlayMenu.activeSelf); //при нажатии на кнопку выпадающее меню становится активным (видимым), если оно было выключено, и наоборот
    }
}
