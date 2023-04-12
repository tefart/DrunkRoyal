using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float RunSpeed;
    [SerializeField] private float JumpSpeed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        //ссылки для Rigidbody2D и animator для обьекта
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalImput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalImput * RunSpeed, body.velocity.y);

        //поворот персонажа влево-право
        if (horizontalImput > 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalImput < -0.01f)
            transform.localScale = new Vector3(-1 ,1 ,1 );

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump();

        //Передаёт параметры аниматору
        anim.SetBool("run", horizontalImput != 0);
        anim.SetBool("grounded", grounded);
    }


    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, JumpSpeed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
