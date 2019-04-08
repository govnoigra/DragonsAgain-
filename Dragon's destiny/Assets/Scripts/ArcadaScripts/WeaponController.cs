using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject shot; //cсылка на префаб снаряда
    public Transform shotSpawn; //ссылка на обьект, в координатах которого будет создаваться снаряд
    public float fireRate; //частота, с которой будут вылетать снаряды
    public float delay; //задержка перед вызовом функции InvokeRepeating
    private AudioSource audioS; //ссылка на звуковой файл вылета снаряда врага

    private void Start()
    {
        audioS = GetComponent<AudioSource>(); //получаем ссылку на компонент аудиосоурс и сохраянем ее в эту переменную
        InvokeRepeating("Fire", delay, fireRate); //вызывает указанный в кавычках метод, через определенное кол-во секунд с момента ее запуска, которое указано во втором параметре и повторяет вызов метода через промежуток, указанный в третьем параметре. В секундах
    }

    private void Fire() //функция, в которой клонируются снаряды и проигрывается звуковой эффект
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //клонируется снаряд
        audioS.Play(); //проигрывание звукового файла при выстреле
    }
}
