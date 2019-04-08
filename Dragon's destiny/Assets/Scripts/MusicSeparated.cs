using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//отдельно для кнопки "музыка" в выпадающем меню настроек
public class MusicSeparated : MonoBehaviour
{
    public Sprite mus_on, mus_off; //картинки, которые будут передаваться в кнопку в зависимости от того, включена или выключена музыка
    public Button Music; //сама кнопка, в которую мы будем подавать спрайты и в зависимости от которой включать/выключать музыку
    public AudioSource music; //наша музыка
   // public AudioClip mainMusic;

    void Start()
     {
    //    Music = Button.FindObjectOfType("Music");
        music = GetComponent<AudioSource>(); //устанавливаем нынешнее состояние музыки (?) (не могу лучше объяснить)
        if (AudioListener.volume == 0)
        {
            Music.GetComponent<Image>().sprite = mus_off;
        }
    } 

   /* public void MusicStay ()
    {
          DontDestroyOnLoad(music);
    }
    */

     public void MusicActions() //для кнопки "музыка"
     {
        
        if (!music.isPlaying) //если в данный момент музыка отключена
        {
            
          Music.GetComponent<Image>().sprite = mus_on; //отправляем спрайт, что музыка включена (т.к. если мы нажали на кнопку с выкл музыкой, мы хотим её включить)
            music.Play(); //запускаем музыку
            AudioListener.volume = 1;
        } else //если в данный момент музыка включена
        {
           Music.GetComponent<Image>().sprite = mus_off; //отправляем спрайт, что музыка выключена
            music.Pause(); //приостанавливаем музыку
            AudioListener.volume = 0;
        }
        

    }
     
}
