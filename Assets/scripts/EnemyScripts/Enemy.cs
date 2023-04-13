using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private float damage;

    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // �������� ������ ��������

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        //�������� ������ 
        animator.SetBool("IsDead", true);
        //����� �� ����� �����

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
