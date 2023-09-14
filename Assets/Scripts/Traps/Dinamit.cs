using System.Collections;
using UnityEngine;
using CartoonFX;

public class Dinamit : Trap
{

    private float timerPuff = 5f;
    private float timerDestroy = 5.3f; // ������� 0.3f
    private bool flagExplosive = false;
    private bool flagMinus = false;
    private bool flagPlus = false;
    private bool Check1 = false; // ���� ��� ���������� ������� �������� ��� ��������� �����
    private bool Check2 = false;

    //� ������ ������� ��������� ������ Puff ��� ������

    public void Start()
    {
        psDamage = ParticleDamage.GetComponentInChildren<ParticleSystem>();
        psDestroy = ParticleDestoy.GetComponentInChildren<ParticleSystem>();
        shake.GetComponent<CFXR_Effect>().enabled = false;
        psDamage.Pause();
        psDestroy.Pause();
    }

    protected override void Update()
    {
        if (flagExplosive)
        {
            timerPuff -= Time.deltaTime; 
            timerDestroy -= Time.deltaTime;
            if (timerPuff <= 0)
            {
                Puff();

            }
            if (timerDestroy <= 0)
            {
                Destroy();

            }
        } 
    if (flagMinus)  // ����� ���� (�������� ��� ���������� �������
    {
        timerPuff -= Time.deltaTime;
        if (Check1)
            {
                if (timerPuff <= 0)
                {
                    StartCoroutine(MinusCorut());
                    Check1 = false;
                }
            }
    }   
    if (flagPlus)  // ���� ���� (�������� ��� ���������� �������
        {
        timerPuff -= Time.deltaTime;
        if (Check2)
            {
                if (timerPuff <= 0)
                {
                    StartCoroutine(PlusCorut());
                    Check2 = false;
                }
            }
    }

    }
    IEnumerator PlusCorut()
    {
        yield return new WaitForEndOfFrame();
        CountPlus();
    }
    IEnumerator MinusCorut()
    {
        yield return new WaitForEndOfFrame();
        CountMinus();
    }

    protected override void OnTriggerEnter(Collider other) //������������� ������� (�� ��������� � ������� ������������)
    {
        if (isDead)
        {
            return;
        }
        if (checkTouch)
        {
            return;
        }
         if (other.gameObject.CompareTag("Ally")) // ���� ��������� ����� ��� "Ally"
        {
            flagMinus = true; // ������ ���� ��� ������� ������� ������� ��� ������ � ��������� �����
            Check1 = true;

        }
        if (other.gameObject.CompareTag("Enemy")) // ���� ��������� ����� ��� "Enemy"
        {
            flagPlus = true; // ������ ���� ��� ������� ������� ������� ��� ������ � �����������
            Check2 = true;
        }

        if (other.gameObject.CompareTag("Ground")) //�������� ��������������� ������� ������ �� � ������ � �������� �� �� �����������
        {
            flagExplosive = true;
            checkTouch = true;
        }
    }

    protected override void Destroy()
    {
        Destroy(gameObject);
    }

    protected override void Puff()
    {
        shake.GetComponent<CFXR_Effect>().enabled = true;
        psDamage.Play();
    }

    protected override void CountMinus()
    {
        base.CountMinus();
    }
    protected override void CountPlus()
    {
        base.CountPlus();
    }
}
