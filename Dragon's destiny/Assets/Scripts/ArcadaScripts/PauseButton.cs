using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour  //весь скрипт для смены картинки при нажатии на паузу
{
    public Sprite pic1;
    public Sprite pic2;
  

    private Image im;
    void Start()
    {
        im = GetComponent<Image>();
        im.sprite = pic1;
       
    }
    public void Swap()
    {
        if (im.sprite == pic1)
        {
            im.sprite = pic2;
            return;
        }

        if (im.sprite == pic2)
        {
            im.sprite = pic1;
            return;
        }

        
    }
}
