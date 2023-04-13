using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float RunSpeed;
    [SerializeField] private float JumpSpeed;
    [SerializeField] private LayerMask groundLayer; 
    private Rigidbody2D body;
    private Animator anim;
    private CapsuleCollider2D capsuleCollider;
    


    private void Awake()
    {
        //ссылки для Rigidbody2D и animator для обьекта
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();    
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

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && IsGrounded())
            Jump();

        //Передаёт параметры аниматору
        anim.SetBool("run", horizontalImput != 0);
        anim.SetBool("grounded", IsGrounded());

        
    }


    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, JumpSpeed);
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return !IsGrounded();
    }

}
