using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonsEnemies : Monster
{
    [SerializeField]
    private float rate = 1.1F;
    [SerializeField]
    private float rasst;

    [SerializeField]
    private float speed = 9.0F;

    //менять цвет префаба
    [SerializeField]
    private Color fireColor = Color.white;

    private Fire fire;

    protected override void Awake()
    {
        //     sprite = GetComponentInChildren<SpriteRenderer>();
        //       animator = GetComponent<Animator>();
        fire = Resources.Load<Fire>("FireBlack");
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate+0.5F);
        Destroy(gameObject, 40.0F);
    }
   

    private void Shoot()
    {
        Vector3 position = transform.position;
        position.y += 0.1F;
        position.x -= 1.0F;
        Fire newFire = Instantiate(fire, position, fire.transform.rotation) as Fire;

        newFire.Parent = gameObject;
        newFire.Direction = -newFire.transform.right;

        Destroy(newFire, 10F);

        //менять цвет префаба
        newFire.Color = fireColor;
    }
 

    protected override void Update()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is CharacterInCampaighController)
        {
            /*       rasst = Mathf.Abs(unit.transform.position.x - transform.position.x);
                   if (rasst < 2.0F) ReceiveDamage();
                   else unit.ReceiveDamage();
                   */
            unit.ReceiveDamage();
   //         damageSound.Play();
        }
        
        Fire fire = collider.GetComponent<Fire>();

        if (fire)
        {
            ReceiveDamage();
  //          damageSound.Play();
        }
    }

    private void Move()
    {
        /*        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 1.0F + transform.right * direction.x * 0.3F, 0.25F);

                if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<CharacterInCampaighController>()))
                {
                    direction *= -1.0F;
                    monsterDirection *= -1;
                    sprite.flipX = direction.x > 0.0f;
                }
                */
        Vector3 direction = transform.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
