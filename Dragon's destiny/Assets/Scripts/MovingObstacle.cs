using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;



//    НЕ ИСПОЛЬЗУЕТСЯ



public class MovingObstacle : MonoBehaviour
{

    //   new public Rigidbody2D rigidbody;

    /*   private void Awake()
       {
           rigidbody = GetComponent<Rigidbody2D>();
       }
       */
    private Vector3 direction;

    [SerializeField]
    private float speed = 6.0F;

    [SerializeField]
    private float rate = 3.0F;

    //   private void Start()
    //   {
    //       direction = -transform.up;
    //  }

      private void Update()
       {
                MoveUpAndDown();
       }
      
/*    protected void Start()
    {
//        InvokeRepeating("MoveUpAndDown", rate, rate);
    }
    */

    private void MoveUpAndDown()
    {
        direction = transform.up;
        //       Wait3Seconds();
  //      Thread.Sleep(3000);
  //      timer = true;
        //     rigidbody.AddForce(transform.up * 5.5F, ForceMode2D.Impulse);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        //       Wait02Seconds();
   //     Thread.Sleep(200);
        direction = transform.up * 0.0F;
        //      Wait3Seconds();
   //     Thread.Sleep(3000);
        direction = -transform.up;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        //     rigidbody.AddForce(transform.up * (-5.5F), ForceMode2D.Impulse);
        //        Wait02Seconds();
  //      Thread.Sleep(200);
        direction = transform.up * 0.0F;

    }

  /*  private IEnumerator Wait3Seconds()
    {
        yield return new WaitForSeconds(3.0f);
    }

    private IEnumerator Wait02Seconds()
    {
        yield return new WaitForSeconds(0.2f);
    }
    */

    //  public AudioSource damageSound;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is CharacterInCampaighController)
        {
            unit.ReceiveDamage();  //damageSound.Play();
        }
    }
}
