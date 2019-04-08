using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovingPlatform : MonoBehaviour
{

    //делать по два триггера с обеих сторон (итого четыре)

    [SerializeField]
    private float speed = 2.0F;

    private Vector3 direction;
    public bool isInPlatform = false;

    private SpriteRenderer sprite;

    new public Rigidbody2D rigidbody;

    public CharacterInCampaighController character;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        direction = -transform.right;
    }

    private void Update()
    {
        //      Move();
        if (isInPlatform) MoveWithCharacter();
        else Move();
    }

 /*       private void OnTriggerEnter2D(Collider2D collider)
        {
            Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is CharacterInCampaighController)
        {
            isInPlatform = true;
        }
        else isInPlatform = false;
        }
*/
        

   private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            isInPlatform = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInPlatform = false;

        }
    } 

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.right * direction.x * 0.3F, 0.5F);
  //      Collider2D collider;
   //     CharacterInCampaighController character = collider.gameObject.GetComponent<CharacterInCampaighController>();

        if (colliders.Length > 2 && colliders.All(x => !x.GetComponent<CharacterInCampaighController>()))
        {
            direction *= -1.0F;
   //         sprite.flipX = direction.x > 0.0f;
        }
          transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
     //   transform.position = Vector3.MoveUp(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
    private void MoveWithCharacter()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.right * direction.x * 0.3F, 0.5F);
       
        if (colliders.Length > 3)
        {
            direction *= -1.0F;
            sprite.flipX = direction.x > 0.0f;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

}
