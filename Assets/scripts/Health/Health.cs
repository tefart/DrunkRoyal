using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField] private AudioSource getDmgSound;
    [SerializeField] private AudioSource getDieSound;

    [Header("iFrames")]

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    

    

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }
    public void TakeDamage(float _damage) 
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        getDmgSound.Play();

        if (currentHealth > 0)
        {
            //player получил урон
            StartCoroutine(Invunerability());
            anim.SetTrigger("hurt");
        }
        else
        {

            if (!dead)
            {
                anim.SetTrigger("die");
                getDieSound.Play();

                foreach (Behaviour component in components)
                    component.enabled = false;


                if (GetComponent<meleeEnemy>() != null)
                    GetComponent<meleeEnemy>().boxCollider.enabled = false;

                dead = true;
            }
        }
    }
    
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
       
        // врем€ неу€звимости
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(255, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/numberOfFlashes * 2);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / numberOfFlashes * 2);

        }
        Physics2D.IgnoreLayerCollision(10, 11, false);

    }
     public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
