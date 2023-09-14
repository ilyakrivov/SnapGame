using UnityEngine;
using UnityEngine.AI;

public enum Tag
{
    Enemy,
    Ally
}

public class GameUnit : MonoBehaviour
{
    public UnitTag tag;
    public int healthPoints;
    public float speed;
    public float timeToSelectNewDest = 5f;
    public int mapWidth;
    public int mapHeight;
    public bool dieornot = false;
    public Animator animator;
    private Rigidbody[] rb;
    private NavMeshAgent navMeshAgent;
    private float timeSinceReachedDestination = 15f;

    public void Awake()
    {
        animator.SetFloat("offset", Random.Range(0f, 1f));
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponentsInChildren<Rigidbody>();
    }

    private void Update()
    {
        if (navMeshAgent.isStopped == false)
        {
            Path(); // поиск пути
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            // Проверяем, есть ли у объекта, с которым произошло столкновение, тег "Trap"
            if (other.gameObject.CompareTag("Trap"))
            {
            Trap trap = other.GetComponent<Trap>();
            TrapDieFunction(trap.trap_ID);  //запуск функции программы смерти.
            }
            if (other.gameObject.CompareTag("Kill"))
            {
            Debug.Log("ПОМИР"); // запуск смэрти
            }
    }
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

    public void TrapDieFunction(int i)
    {


        if (i == 1)
        {
            navMeshAgent.isStopped = true;
            animator.enabled = false;
            for (int y =0; y < rb.Length; y++)
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