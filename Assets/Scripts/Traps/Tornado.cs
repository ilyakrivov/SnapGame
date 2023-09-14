using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class Tornado : Trap


{
    public int mapWidth;
    public int mapHeight;
    private NavMeshAgent navMeshAgent;
    [SerializeField] float timeOff;
    [SerializeField] float timeOffDestroy; // всегда ставить на 0.2 больше чем timeOff

    public void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void Start()
    {
        psDestroy = ParticleDestoy.GetComponentInChildren<ParticleSystem>();
        psDestroy.Pause();
    }

    public void Path()
    {
        MoveToRandomPoint();
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

    protected override void Update()
    {
        timeOff -=Time.deltaTime;
        timeOffDestroy -= Time.deltaTime;
        if (timeOff <= 0f) //проверка на гибель объекта
        {
            psDestroy.Play();
            isDead = true;  // флаг для выключения повторного убийства
        }
        Path();
        if(timeOffDestroy <= 0f)
        {
            Destroy(gameObject);
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (isDead)  // если флаг тру - повторного убийства не будет
        {
            return;
        }
        if (other.gameObject.CompareTag("Ally")) // если противник имеет тег "Ally"
        {
            isDead = true;
            CountMinus(); //запуск вычитания очков
        }
        if (other.gameObject.CompareTag("Enemy")) // если противник имеет тег "Enemy"
        {
            isDead = true;
            CountPlus(); //запуск прибавления очков
        }
    }

    protected override void CountPlus()
    {
        base.CountPlus();
    }
    protected override void CountMinus()
    {
        base.CountMinus();
    }
}
