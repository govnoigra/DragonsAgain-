using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AptekaOff : MonoBehaviour
{
    public void AptekaBoxOff() //функция включает работу скрипта, отвечающего за спавн аптечки(нужен, если выбран сложный режим, где жизнь равна 1)
    {
        GameObject Apteka = GameObject.Find("AptekaController");
        AptekaController scripts1 = Apteka.GetComponent<AptekaController>();
        scripts1.enabled = true;
        //GetComponent<AptekaController>().enabled = false;
    }
}
