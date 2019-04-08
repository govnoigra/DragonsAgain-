using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealPoint : MonoBehaviour
{
    public int HP;  //публичная переменная здоровья
    
    public Text hpbar;
   

    public GameObject explosionPlayer; //содержит ссылку на визуальный эффект взрываа дракона
    private GameObject cloneExplosion;

    void Start()
    {
        HP = 5;
        
        hpbar.gameObject.SetActive(true);
    
    }

    private void OnTriggerEnter(Collider other) //отвечает вход в триггер
    {
        if (other.tag == "Bullet") //если объект имеет тег Enemy
        {
            HP = HP - 1; //то при сокприкосновении с объектом наше здоровье уменьшается на 25
            cloneExplosion = Instantiate(explosionPlayer, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject; //клонирование. Удаляем камни и дракона + удаление оставшейся визуальной части(клона)

            Destroy(other.gameObject); //удаление снаряда 
            Destroy(cloneExplosion, 1f);
        }
    }

    void Update()
    {
        hpbar.text = "Жизни: " + HP;
        
        if (HP < 1) //если наше здоровье меньше 1
        {
            cloneExplosion = Instantiate(explosionPlayer, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject; //клонирование. Удаляем камни и дракона + удаление оставшейся визуальной части(клона)
           
            Destroy(gameObject); //удаление дракона
            
            Destroy(cloneExplosion, 1f);
        }

        
    }
}
