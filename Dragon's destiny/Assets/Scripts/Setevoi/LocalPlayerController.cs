using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable] //нужен для того, чтобы переменные из класса Boundary отображались в инспекторе юнити
public class BoundaryLocal //класс, во котором находятся переменные, определяющие границы поля
{
    public float xMin, xMax, zMin, zMax; //переменные, которые являются ограничением игрового поля, чтобы не вылететь за ее пределы. y нам не нужен, потому что значения y в нашей игры не меняется при передвижениях дракона
}

public class LocalPlayerController : NetworkBehaviour
{
    public float Speed = 10;//публичная переменная скорости дракона
    public BoundaryLocal boundary;
    
   public Quaternion calibrationQuaternion;

    public void Start()
    {
        CalibrateAccelerometr();
        if (target)
        {
            Vector3 position = target.position;
            z = position.z;

        }
    }
    
    public void CalibrateAccelerometr()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

   public Vector3 FixAcceleration(Vector3 acceration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceration;
        return fixedAcceleration;

    }

    public GameObject shot; //перетянем на него наш Bolt
    public Transform shotSpawn; //позиция снаряда
    public float fireRate = 0.5f; //отвечает, как часто будут вылетать пули
    public float nextFire = 0.0f;//регулирует разрешение на стрельбу

    private float z;
    [SerializeField]
    private Transform target;

    /*void Start()
    {
        if (target)
        {
            Vector3 position = target.position;
            z = position.z;
            
        }
    }*/

    public void Update() //выполняется перед обновлением кадра, каждый кадр
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) //настроим стрельбу с определенной частотой
        {
            nextFire = Time.time + fireRate; //nextFire = время прошедшее от начала игры + частота выстрела
            CmdFire();

        }
    }

    [Command]
    void CmdFire()
    {
        GameObject bullet = (GameObject)Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 14.0f;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 3);
    }

    private void FixedUpdate() //расчитывает физику, а потом отрисовывает изображение
    {

       /* float moveHorizontal = Input.GetAxis("Horizontal"); //возвращает значение от -1 до 1 при нажатии на устройстве ввода
        float moveVertical = Input.GetAxis("Vertical");     //возвращает значение от -1 до 1 при нажатии на устройстве ввода  */

        Vector3 accelerationRaw = Input.acceleration;
        Vector3 acceleration = FixAcceleration(accelerationRaw);

        /*if (target)
        {
            if (z > 0)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(-moveHorizontal, 0f, -moveVertical) * Speed;
            }

            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal, 0f, moveVertical) * Speed;
            }
        }*/
       

        /* GetComponent<Rigidbody>().position = new Vector3 //обращение к позиции дракона
              (
                  Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную х от xMin до xMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
                  0.0f, //y = 0, т.к. нам не надо двигаться по этой координате
                  Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax) //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную z от zMin до zMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
              );*/

       if (target)
        {
            if (z > 0)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(-acceleration.x, 0f, -acceleration.y) * Speed;
            }

            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(acceleration.x, 0f, acceleration.y) * Speed;
            }
        }
       

        GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную х от xMin до xMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax) //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную z от zMin до zMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
            );
    }

    /*private void OnTriggerEnter(Collider other)//описываем триггер
    {
        if (other.tag == "Bullet") //тег(нужен для правильной работы)
        {
            Destroy(other.gameObject); //удаление снаряда
            Destroy(gameObject); //удаление камня
        }
    }*/
}
