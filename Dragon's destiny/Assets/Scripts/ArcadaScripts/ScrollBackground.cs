using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed; //отвечает за скорость скролла фона
    public float tileSize; //содержит высоту фона

    private Transform currentObject; //содержит ссылку на текущий объект

    void Start()
    {
        currentObject = GetComponent<Transform>(); //мы обращаеся к компонтенту трансформ текущего объекта
    }

    void Update()
    {
        currentObject.position = new Vector3
            (
            currentObject.position.x,
            currentObject.position.y,
            Mathf.Repeat(Time.time * scrollSpeed, tileSize) //в качестве первого значения у функции repeat мы подставили Time.time, который возвращает время в секундха от начала игры и сразу умножаем на скролспеед, с помощью которой задаем скорость прокрутки фона. repat возрващает остаток деления первого значения на второе. tileSize содержит значения о высоте прокручиваемого фона
            );
    }
}
