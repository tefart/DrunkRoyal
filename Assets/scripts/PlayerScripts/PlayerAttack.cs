using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] public float attackRange;

    [SerializeField] private AudioSource attackSound;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Attack Layer")]
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int attackDamage = 100;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            
            Attack();
        }
            
        cooldownTimer += Time.deltaTime;

        
    }

    
    private void Attack()
    {   
        //анимация атаки
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        attackSound.Play();
        //радиус атаки
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);



        //Урон атаки
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDamage);
        }


    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

