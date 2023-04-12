using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public static int health;
    public GameObject Heart1, Heart2;
    // Start is called before the first frame update
    void Start()
    {
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        
        health = 2;

    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                
                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                
                break;
            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                
                break;

                
        }


     
    }
}
