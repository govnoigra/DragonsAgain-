using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDropDown : MonoBehaviour
{
    public GameObject ExitSureOrNot; //выпадающее меню с вопросом, точно ли вы хотите выйти из игры

    //для кнопки "Exit" в сцене main
    public void AskIfYouSureToExit()
    {
        ExitSureOrNot.SetActive(!ExitSureOrNot.activeSelf); //при нажатии на кнопку "выход" выпадающее меню становится активным (видимым), если оно было выключено, и наоборот
    }

    //для кнопки "No" в выпадающем из "Exit" меню
    public void StayInGame ()
    {
        ExitSureOrNot.SetActive(!ExitSureOrNot.activeSelf); //при нажатии на кнопку "нет" выпадающее меню закрывается
    }
}
