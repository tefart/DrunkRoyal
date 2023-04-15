using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhizhka : MonoBehaviour
{
    [SerializeField] private float startingZhizha;
    [SerializeField] private float healthValue;
    [SerializeField] private float minusPotion;
    [SerializeField] public Health playerHealth;

    [SerializeField] private AudioSource getHealSound;

    public float currentZhizhka { get; private set; }

    private void Awake()
    {
        currentZhizhka = startingZhizha;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && currentZhizhka != 0)
        {
            getHealSound.Play();
            MakeHeal(1);
            
        }


    }
    public void MakeHeal(float _damage)
    {
        currentZhizhka = Mathf.Clamp(currentZhizhka - _damage, 0, startingZhizha);
        GetComponent<Health>().AddHealth(1);
    }

}
