using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //нужен для того, чтобы переменные из класса Boundary отображались в инспекторе юнити
public class Boundary //класс, во котором находятся переменные, определяющие границы поля
{
    public float xMin, xMax, zMin, zMax; //переменные, которые являются ограничением игрового поля, чтобы не вылететь за ее пределы. y нам не нужен, потому что значения y в нашей игры не меняется при передвижениях дракона
}

public class PlayerController : MonoBehaviour
{
    public float Speed = 10;//публичная переменная скорости дракона
    public Boundary boundary; // переменная boundary принадлежит типу Boundary. Хоть и публичная, но не отображается в юинит, смотри перед классом боундари, там систем сериализэйбл
    public float tilt; //переменная, в которой хранится коэффициент угла наклона дракона

   // change
     public Quaternion calibrationQuaternion; //осуществляет калибровку акселерометра

    //change
     public void Start()
      {
          CalibrateAccelerometr(); //считываем положение телефона с акселерометра вначале запуска игры
      }
      
    //change
     public void CalibrateAccelerometr()
      {
          Vector3 accelerationSnapshot = Input.acceleration; // получаем данные с датчика акселерометра и записываем в переменную accelerationSnapshot
          Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot); //поворачиваем из положения лицом вверх в положение, полученное от акселерометра. Функция возвращает координаты положения телефона в пространстве типа кватернион. Другими словами, текущее положение телефона
          calibrationQuaternion = Quaternion.Inverse(rotateQuaternion); //инвертируем значения осей
      }

    //change
    public Vector3 FixAcceleration(Vector3 acceration)
     {
         //умножаем стартовое положение телефона на текущее
         //получем текущее положение с учетом калибровки
         Vector3 fixedAcceleration = calibrationQuaternion * acceration;
         return fixedAcceleration;

     }

    public GameObject shot; //перетянем на него наш Bolt
    public Transform shotSpawn; //позиция снаряда
    public float fireRate = 0.5f; //отвечает, как часто будут вылетать пули
    public float nextFire = 0.0f; //регулирует разрешение на стрельбу

    public void Update() //выполняется перед обновлением кадра, каждый кадр
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) //настроим стрельбу с определенной частотой
        {
            nextFire = Time.time + fireRate; //nextFire = время прошедшее от начала игры + частота выстрела
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //клонирование снярядов
            GetComponent<AudioSource>().Play(); //добавление звука выстрела при стрельбе 
        }
        
    }

    private void FixedUpdate() //расчитывает физику, а потом отрисовывает изображение
    {
        //надо комменить, чтобы акселерометр включить
     //   float moveHorizontal = Input.GetAxis("Horizontal"); //возвращает значение от -1 до 1 при нажатии на устройстве ввода
     //   float moveVertical = Input.GetAxis("Vertical");     //возвращает значение от -1 до 1 при нажатии на устройстве ввода  */
        
        //change
        Vector3 accelerationRaw = Input.acceleration; //записывает в вектор три значения полученные с акселерометра. Каждый кадр проверяем положение телефона в пространстве
        Vector3 acceleration = FixAcceleration(accelerationRaw);//получаем координаты текущего положения телефона относительно стартового положения 

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(   //обращение к углу наклона для реализации наклона дракона
            0f, //х = 0, т.к. наклон будет по z
            0f, //y = 0, т.к. наклон будет по z
            GetComponent<Rigidbody>().velocity.x * -tilt); //связь скорости наклона со скоростью перемещения.  tilt  с минусом, потому что таким образом наклон будет происхожит в обе стороны
            
        //тоже надо комментить, что акслеерометр включить
    /*   GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal, 0f, moveVertical) * Speed;//двигает дракона в зависимоти от полученных значений GetAxis. Умножение на Speed позволяет получить скорость больше чем 1 или -1
        
       GetComponent<Rigidbody>().position = new Vector3 //обращение к позиции дракона
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную х от xMin до xMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
                0.0f, //y = 0, т.к. нам не надо двигаться по этой координате
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax) //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную z от zMin до zMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
            );
            */
        //change
      GetComponent<Rigidbody>().velocity = new Vector3(acceleration.x, 0f, acceleration.y) * Speed;//двигает корабль в зависимоти от полученных значений GetAxis. Умножение на Speed позволяет получить скорость больше чем 1 или -1

        GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную х от xMin до xMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax) //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную z от zMin до zMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
            );
    }
}
