using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CartoonFX;

public class Trap : MonoBehaviour
{
    private object collision;
    [SerializeField] public int trap_ID;
    public GameObject ParticleDamage;
    public GameObject ParticleDestoy; 
    public GameObject shake;
    public SphereCollider Coll; // ������ �� ������� ������ � ������
    private float deactiveColl = 0.9f;
    private protected Rigidbody rb;
    protected ParticleSystem psDamage;
    protected ParticleSystem psDestroy;
    [SerializeField] protected float timeToPuff = 5f;
    [SerializeField] protected float timeToDestroy = 5.25f;
    protected bool time = false;
    protected bool isDead = false;
    protected bool checkTouch = false; // �������� �� ������� , ��� ���� �� ��������� ������.
    // Update is called once per frame
    public static int Count; // ����� ������� ������������

    private void Start()
    {
        Coll = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        shake.GetComponent<CFXR_Effect>().enabled = false;
        psDamage = ParticleDamage.GetComponentInChildren<ParticleSystem>();
        psDestroy = ParticleDestoy.GetComponentInChildren<ParticleSystem>();
        psDamage.Pause();
        psDestroy.Pause();

    }

    protected virtual void Update()
    {
        if (time)
        {
            deactiveColl -= Time.deltaTime;
            timeToPuff -= Time.deltaTime;
            timeToDestroy -= Time.deltaTime;
            if(deactiveColl <= 0f)
            {
                if (Coll != null)
                {
                   Coll.isTrigger = false;
                }
            }
            if (timeToPuff <= 0f)
            {
                Puff();
            }
            if (timeToDestroy <= 0f) //�������� �� ������ �������
            {
                isDead = true;
                Destroy();
            }
        }
    }

    /*void ExploDamage()
    {
        if(LoockOther(out GameUnit[] component, transform.position, 30, Vector3.up))
        {
            Debug.Log(component.Length);
        }
        
    }*/

    protected virtual void OnTriggerEnter(Collider other) // ������ ������� ���������� �� ������������
    {
        if (isDead)
        {
            return;
        }
        if (checkTouch)
        {
            return; //���� ��� true �� ����������
        }
        if (other.gameObject.CompareTag("Ally")) // ���� ��������� ����� ��� "Ally"
        {
            CountMinus(); //������ ��������� �����
        }
        if (other.gameObject.CompareTag("Enemy")) // ���� ��������� ����� ��� "Enemy"
        {
            CountPlus(); //������ ����������� �����         
        }
        if (other.gameObject.CompareTag("Ground")) //�������� ��������������� ������� ������ �� � ������ � �������� �� �� �����������
        {
            //ExploDamage();
            psDamage.Play();
            time = true;
            checkTouch = true;
            if (shake != null)
            {
                rb.isKinematic = true;
                shake.GetComponent<CFXR_Effect>().enabled = true;
                RocketMove();
            }
        }
    }

    public virtual void RocketMove()
    {
        Vector3 position = transform.position;
        position.y -= 2.5f;
        transform.position = position;
    }
    protected virtual void Puff() // ������� ���� � ���� ������� ����������� �������
    {
        if (psDestroy != null)
        {
            psDestroy.Play();
        }
        
    }
    protected virtual void Destroy()
    {
            Destroy(gameObject);
    }
    protected virtual void CountMinus()
    {
        Count -= 10;
    }

    protected virtual void CountPlus()
    {
        Count += 10;
    }
}

