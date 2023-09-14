using UnityEngine;
using UnityEngine.AI;

public enum UnitTag
{
    Enemy,
    Ally
}

public class GameUnitEnemy : MonoBehaviour
{
    public UnitTag tag;
    public int healthPoints;
    public float speed;
    public float timeToSelectNewDest = 5f;
    public int mapWidth;
    public int mapHeight;
    public bool dieornot = false;
    public Animator animator;
    private GameObject allyObject;
    private NavMeshAgent navMeshAgent;
    private float timeSinceReachedDestination = 15f;
    public EnemyTrigger enemyTrigger;
    private Rigidbody[] rb;

    private void Awake()
    {
        animator.SetFloat("offset", Random.Range(0f, 1f));
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponentsInChildren<Rigidbody>();
    }

    public void Update()
    {
        if (navMeshAgent.isStopped == false && !enemyTrigger.hunt)
        {
            Path(); // поиск пути
        }

        if (navMeshAgent.isStopped == false && enemyTrigger.hunt)
        {
            HuntTo(); // поиск пути к врагу
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        // Проверяем, есть ли у объекта, с которым произошло столкновение, тег "Trap"
        if (other.gameObject.CompareTag("Trap"))
        {
            Trap trap = other.GetComponent<Trap>();
            TrapDieFunction(trap.trap_ID);  //запуск функции программы смерти.
        }
    } */
    private void Path()
    {
        if (navMeshAgent.enabled && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            timeSinceReachedDestination += Time.deltaTime;
            if (timeSinceReachedDestination >= timeToSelectNewDest)
            {
                timeSinceReachedDestination = 0f;
                MoveToRandomPoint();
            }
        }
    }
    public void MoveToRandomPoint()
    {
        float x = Random.Range(-mapWidth / 2f, mapWidth / 2f);
        float z = Random.Range(-mapHeight / 2f, mapHeight / 2f);
        Vector3 targetPosition = new Vector3(x, 0f, z);
        MoveTo(targetPosition);
    }
    public void MoveTo(Vector3 targetPosition)
    {
        if (navMeshAgent.enabled)
        {
            navMeshAgent.SetDestination(targetPosition);
        }
    }
    public void HuntTo()
    {
        if (navMeshAgent.enabled && enemyTrigger.hunt)
        {
            navMeshAgent.SetDestination(enemyTrigger.allyObject.transform.position);
        }
    }

    public void TrapDieFunction(int i)
    {


        if (i == 1)
        {
            navMeshAgent.isStopped = true;
            animator.enabled = false;
            for (int y = 0; y < rb.Length; y++)
            {
                rb[y].AddForce(Vector3.up * 200);
            }
            Debug.Log("Смерть от динамиа");
        }
        if (i == 2)
        {

            navMeshAgent.isStopped = true;
            animator.enabled = false;
            Vector3 dir = Vector3.up + (transform.position - Random.insideUnitSphere).normalized;
            for (int y = 0; y < rb.Length; y++)
            {
                rb[y].AddForce(dir * 2000);
            }
            Debug.Log("Запуск смерти от Урагана");
        }
        if (i == 3)
        {
            for (int y = 0; y < rb.Length; y++)
            {
                rb[y].AddForce(Vector3.up * 600);
            }
            navMeshAgent.isStopped = true;
            animator.enabled = false;
            Debug.Log("Запуск смерти от ракет");
        }
        if (i == 4)
        {
            navMeshAgent.isStopped = true;
            animator.enabled = false;
            for (int y = 0; y < rb.Length; y++)
            {
                rb[y].AddForce(Vector3.up * 600);
            }
            Debug.Log("Запуск смерти от колб с ядом");
        }

        if (i == 5)
        {
            navMeshAgent.isStopped = true;
            animator.enabled = false;
            for (int y = 0; y < rb.Length; y++)
            {
                rb[y].AddForce(Vector3.up * 100);
            }
            Debug.Log("Запуск смерти от града стрел");
        }
    }


}