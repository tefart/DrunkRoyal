using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;
    

    private void Awake()
    {
        initScale = transform.localScale;
    }


    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x  >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                //смена направления
                DirectionChange();
            }

        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                //смена направления
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }


    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;

        //повернуться лицом в правельное направление 
        enemy.localScale = new Vector3(-Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);  

        //движение в сторону направления
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, 
            enemy.position.y , enemy.position.z); 
    } 
}
