using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject); //в переменную other передается объект, который вышел из области триггер коллайдера. далее функция destroy уничтожает данный объект
    }
}
