using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } get { return parent; } }

    private float speed = 10.0f;
    private SpriteRenderer fireSprite;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    public GameObject explosion;
    public AudioSource audioFire;

    //менять цвет префаба
    public Color color;
    public Color Color
    {
        set { fireSprite.color = value;  }
        get { return color; }
    }

    private void Awake()
    {
        fireSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
         Destroy(gameObject, 2.5F);
         audioFire = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit.gameObject != parent)
        {
            //       unit.ReceiveDamage();

            Instantiate(explosion, gameObject.transform.position,  gameObject.transform.rotation);
            audioFire.Play();
            //         Destroy(explosion, 5.0F);
            Destroy(gameObject);
        }
    }
}
