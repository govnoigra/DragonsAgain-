using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble; //переменная скорости вращения
    private Rigidbody rb;

    void Start() //код выполняется один раз при запуске сцены
    {
        rb = GetComponent<Rigidbody>(); //описали, что переменая является компонентом риджитбоди
        rb.angularVelocity = new Vector3(1, 1, 1) * tumble; //задает вектор угловой скорости вращения объекта
        rb.angularVelocity = Random.insideUnitSphere * tumble; //рандомизация углов вращения камня
    }
}
