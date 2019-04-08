using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterInCampaighController : Unit
{


    [SerializeField]   //чтобы приватные отображались в инспекторе
    private int lives = 5; //жизни


    public Text gameOver;

    public int Lives
    {
        get { return lives; }
        set
        {
           if (value<6) lives = value;
            livesBar.Refresh();
        }
    }

    private LivesBar livesBar;

    [SerializeField]
    private float speed = 3.0f; //скорость
    [SerializeField]
    private float jumpForce = 8.0f; //сила прыжка

    private bool isGrounded = false; //на земле ли персонаж (для прыжков)
    public bool canDoubleJump; //для двойного прыжка

    public int directionInput; //в какую сторону нужно идти

    public bool facingRight = true; //сторона поворота персонажа

    public GameObject Player; //сам дракон
    public float xPlayer, yPlayer; //координаты дракона

    private Fire fire; //огонь для выстрела
    public int fireDirection = 1;

    public AudioSource audioGot;
    public AudioSource damageSoundForCharacter;
    public AudioSource characterJumpSound;
    public AudioSource deathOfCharacter;

    public GameObject jumpCloud;

    private bool gameover; //логическая переменная для отслеживания конца игры
    private bool restart; //логическая переменная для отслеживания рестарта игры
    public GameObject restartButton; //ссылка на кнопку рестарта

    public int FireDirection
    {
        get { return fireDirection; }
        set { fireDirection = value; }
    }

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new public Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer dragon;

    public Color color;
    //менять цвет префаба
    public Color Color
    {
        set { dragon.color = value; }
    }

    // [SerializeField]
    // private Material jumpMaterial = Material.white;

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dragon = GetComponentInChildren<SpriteRenderer>();

        fire = Resources.Load<Fire>("Fire"); //подгружаем префаб огня для выстрела
        audioGot = GetComponent<AudioSource>();

        restart = false;
        restartButton.SetActive(false); //чтобы кнопка вначале игры была невидна
        gameOver.text = "";
        Time.timeScale = 1;

    }


    private void FixedUpdate()
    {
        CheckGround();
    }

    
    private void Update()
    {
        if (isGrounded) State = CharState.Idle;
        RunUI();

        xPlayer = Player.transform.position.x;
        yPlayer = Player.transform.position.y;
        if ((directionInput < 0) && (facingRight))
        {
            Flip();
   //         xPlayer += (float)0.5;
            Player.transform.position = new Vector3(xPlayer, yPlayer, 0f);

        }
        if ((directionInput > 0) && (!facingRight))
        {
            Flip();
   //         xPlayer -= (float)0.5;
            Player.transform.position = new Vector3(xPlayer, yPlayer, 0f);
        }
        if (isGrounded && directionInput!=0)
        {
            State = CharState.Run;
        }

        if (lives == 0)
        {
            Destroy(gameObject); //удаление дракона
            gameOver.text = "Конец игры";
            restartButton.SetActive(true); //метод сетактив делает объект активным и видимым, если передаваемое значение тру
            restart = true;
        }
    }

    void Flip()  //поворот персонажа
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


      public void RunUI()
      {
        
        Vector3 direction = transform.right * directionInput;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    //    dragon.flipX = direction.x < 0.0f;
       // if (isGrounded) State = CharState.Run;
    } 

   public void Move(int InputAxis)
    {
        directionInput = InputAxis;
        if (directionInput != 0) fireDirection = directionInput;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            characterJumpSound.Play();
            canDoubleJump = true;
        } else if (canDoubleJump)
        {
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            Instantiate(jumpCloud, gameObject.transform.position, gameObject.transform.rotation);
       //     Destroy(jumpCloud, 1.5F);
            characterJumpSound.Play();
            canDoubleJump = false;
        }

    }

    public void Shoot()
    {
        Vector3 position = transform.position;
         position.y += 0.4F;
        if (fireDirection > 0) position.x += 3.0F;
        else if (fireDirection < 0) position.x -= 2.0F;
        Fire newFire = Instantiate(fire, position, fire.transform.rotation) as Fire;

        newFire.Parent = gameObject;
        newFire.Direction = newFire.transform.right * fireDirection;
        if (isGrounded) State = CharState.Attack;
    }

    public override void ReceiveDamage()
    {
        Lives--;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);
       if (Lives>0) damageSoundForCharacter.Play();
       else deathOfCharacter.Play();

        /*  if (lives == 0)
          {
              gameOver.text = "Вы померли";
              Time.timeScale = 0;
          }
          */


        //     Debug.Log(lives);
    }

    private void CheckGround()
    {
    //    Collider2D collider = gameObject.GetComponent<Collider2D>();
  //      if (collider.tag == "Ground") isGrounded = true;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * (-0.5F), 0.2F);

        isGrounded = colliders.Length > 1; // если кол-во попадающих коллайдеров больше 1, то игрок стоит на земле
        if (!isGrounded) State = CharState.Jump;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Fire fire = collider.gameObject.GetComponent<Fire>();
        if (fire && fire.Parent != gameObject)
        {
            ReceiveDamage();
   //         damageSound.Play();
        }

        CoinToGet coin = collider.gameObject.GetComponent<CoinToGet>();
        if (collider.tag== "Coins")
        {
          audioGot.Play();
        }

        HeartToGet heart = collider.gameObject.GetComponent<HeartToGet>();
        if (collider.tag == "Hearts")
        {
            audioGot.Play();
        }

    
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "platform")
        {
            transform.parent = other.transform;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "platform")
        {
            transform.parent = null;

        }
    }

    /*  public void MoveWithPlatform(Vector3 direct)
      {

      }
      */
}

public enum CharState
{
    Idle,
    Run,
    Jump,
    Attack
}