using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    public Vector2 startWait; //переменная для диапазона
    private float targetManeuver; //targetManeuver определяет дистанцию дракона-врага, на которую он будет смещаться вправо и влево
    public float dodge; //максимально расстояние маневрирования дракона-врага
    public Vector2 maneuverTime; //переменная для диапазона
    public float maneuverSpeed; //скорость маневра
    public Vector2 maneuverWait; //определяет время в секундах до создания следущего маневра
    private float currentSpeed; //cкорость дракона по оси z

    public Boundary boundary; // переменная boundary принадлежит типу Boundary. Хоть и публичная, но не отображается в юинит, смотри перед классом боундари, там систем сериализэйбл
    public float tilt; //переменная, в которой хранится коэффициент угла наклона дракона

    private void Start()
    {
        currentSpeed = GetComponent<Rigidbody>().velocity.z; //скорость корабля по оси z
        StartCoroutine( Evade() ); //при помощи этой функции вызвается функция корутина
    }

    IEnumerator Evade() //делает функцию Evade корутиной. Запускается один раз при появлении драконов врагов на карте
    {
        yield return new WaitForSeconds( //функция приостоновит работу функции Evade на выбранное в Random.Range время и как только это время закончится функция продолжит дальнейшее выполнение кода паралленльно с основынм потоком. Приостоновка нудна, чтобы дракон враг маневрировал не сразу после появления, а через какой-то промежуток времени
            Random.Range(
                startWait.x, //диапазон от
                startWait.y //диапазон до
            )
           );

        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x); //функция рандом рандж выбирает случайное значение от 1 до додж. dodge - максимально расстояние маневрирования дракона-врага. targetManeuver определяет дистанцию дракона-врага, на которую он будет смещаться вправо и влево. мат сайнс нужно для того, чтобы дракон смог маневрировать в другую сторону, когда координаты будут меньше нуля

            yield return new WaitForSeconds( //функция приостоновить работу функции Evade на выбранное случайным образом значение рандомрандж  из диапазона значений
                Random.Range(
                    maneuverTime.x, //диапазон от
                    maneuverTime.y //диапазон до
                    ) 
                );

            targetManeuver = 0; //обнуляя мы прекращаем маневрирование корабля

            yield return new WaitForSeconds( //cнова создаем паузу. Пауза между маневрами
                Random.Range(
                    maneuverWait.x,
                    maneuverWait.y
                    )
            );
        }
    }

    private void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards //моветовардс принимает три значения:начальное значение, конечное значение и скорость
            (
                GetComponent<Rigidbody>().velocity.x, // скорость перемещения дракона влево и вправо
                targetManeuver, //содержит расстояние маневра
                maneuverSpeed * Time.deltaTime //скорость, с которой будет выполняться маневр. Помощью таймдельта тайм будет плавное перемещение даже на слабых устройствах
            );

        GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, currentSpeed); //возвращаемое значнеие newManeuver применяем к дракону

        GetComponent<Rigidbody>().position = new Vector3 //обращение к позиции дракона
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную х от xMin до xMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
                0.0f, //y = 0, т.к. нам не надо двигаться по этой координате
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax) //структуа Mathf.Clamp содержит много матем.формул. Нужна, чтобы ограничить переменную z от zMin до zMax. 0f означает, что y равен 0, ибо он нам не нужен. Переменные являются часть класса Boundary
            );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(   //обращение к углу наклона для реализации наклона дракона
            0f, //х = 0, т.к. наклон будет по z
            0f, //y = 0, т.к. наклон будет по z
            GetComponent<Rigidbody>().velocity.x * -tilt);  //связь скорости наклона со скоростью перемещения.  tilt  с минусом, потому что таким образом наклон будет происхожит в обе стороны

    }
}
