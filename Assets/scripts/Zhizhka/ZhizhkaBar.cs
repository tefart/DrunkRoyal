using UnityEngine;
using UnityEngine.UI;

public class ZhizhkaBar : MonoBehaviour
{
    [SerializeField] public Zhizhka playerZhizhka;
    [SerializeField] private Image totalzhizhaBar;
    [SerializeField] private Image currentzhizhaBar;

    private void Start()
    {
        totalzhizhaBar.fillAmount = playerZhizhka.currentZhizhka / 2;
    }

    private void Update()
    {
        currentzhizhaBar.fillAmount = playerZhizhka.currentZhizhka / 2;
    }

    

}
