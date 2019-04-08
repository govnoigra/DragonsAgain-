using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //нужен для того, чтобы переменные из класса Boundary отображались в инспекторе юнити
public class Boundary2 //класс, во котором находятся переменные, определяющие границы поля
{
    public float xMin, xMax, zMin, zMax; //переменные, которые являются ограничением игрового поля, чтобы не вылететь за ее пределы. y нам не нужен, потому что значения y в нашей игры не меняется при передвижениях дракона
}

public class MoverBoss : MonoBehaviour
{
    public float speed;
    public Boundary2 boundary; // переменная boundary принадлежит типу Boundary. Хоть и публичная, но не отображается в юинит, смотри перед классом боундари, там систем сериализэйбл



    public void Start() //функция будет выполнена при активации объекта, к которому принадлежит данный скрипт
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * speed; //движение снаряда вперед с определенной скоростью
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().position = new Vector3 //обращение к позиции дракона
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную х от xMin до xMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
                0.0f, //y = 0, т.к. нам не надо двигаться по этой координате
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax) //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную z от zMin до zMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
            );
    }
}
