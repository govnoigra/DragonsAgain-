using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightShootableMonsters : Monster
{
    [SerializeField]
    private float rate = 1.0F;
    [SerializeField]
    private float rasst;

    //менять цвет префаба
    [SerializeField]
    private Color fireColor = Color.white;

    private Fire fire;
    new public Rigidbody2D rigidbody;

    //   public AudioSource damageSound;

    protected override void Awake()
    {
        //     sprite = GetComponentInChildren<SpriteRenderer>();
        //       animator = GetComponent<Animator>();
        fire = Resources.Load<Fire>("FireBlack");
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot()
    {
        Vector3 position = transform.position;
        position.y += 0.5F;
        position.x += 1.5F;
        Fire newFire = Instantiate(fire, position, fire.transform.rotation) as Fire;

        newFire.Parent = gameObject;
        newFire.Direction = newFire.transform.right;

        //менять цвет префаба
        newFire.Color = fireColor;
    }



    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is CharacterInCampaighController)
        {
            rasst = Mathf.Abs(unit.transform.position.x - transform.position.x);
            if (rasst < 2.0F)
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);
                ReceiveDamage(); // damageSound.Play();
            }
            else
            {
                unit.ReceiveDamage(); // damageSound.Play();
            }
        }
        Fire fire = collider.GetComponent<Fire>();

        if (fire)
        {
            ReceiveDamage(); // damageSound.Play();
        }
    }

}
