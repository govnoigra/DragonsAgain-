using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public float speed;

   public void Start() //функция будет выполнена при активации объекта, к которому принадлежит данный скрипт
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * speed; //движение снаряда вперед с определенной скоростью
    }
}
