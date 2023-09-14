using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class Tornado : Trap


{
    public int mapWidth;
    public int mapHeight;
    private NavMeshAgent navMeshAgent;
    [SerializeField] float timeOff;
    [SerializeField] float timeOffDestroy; // ������ ������� �� 0.2 ������ ��� timeOff

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
        if (timeOff <= 0f) //�������� �� ������ �������
        {
            psDestroy.Play();
            isDead = true;  // ���� ��� ���������� ���������� ��������
        }
        Path();
        if(timeOffDestroy <= 0f)
        {
            Destroy(gameObject);
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (isDead)  // ���� ���� ��� - ���������� �������� �� �����
        {
            return;
        }
        if (other.gameObject.CompareTag("Ally")) // ���� ��������� ����� ��� "Ally"
        {
            isDead = true;
            CountMinus(); //������ ��������� �����
        }
        if (other.gameObject.CompareTag("Enemy")) // ���� ��������� ����� ��� "Enemy"
        {
            isDead = true;
            CountPlus(); //������ ����������� �����
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
