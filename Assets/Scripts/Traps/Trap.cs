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
    public SphereCollider Coll; // объект на котором тригер с уроном
    private float deactiveColl = 0.9f;
    private protected Rigidbody rb;
    protected ParticleSystem psDamage;
    protected ParticleSystem psDestroy;
    [SerializeField] protected float timeToPuff = 5f;
    [SerializeField] protected float timeToDestroy = 5.25f;
    protected bool time = false;
    protected bool isDead = false;
    protected bool checkTouch = false; // проверка на касание , что очки не считались дважды.
    // Update is called once per frame
    public static int Count; // общий счетчик столкновений

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
            if (timeToDestroy <= 0f) //проверка на гибель объекта
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

    protected virtual void OnTriggerEnter(Collider other) // делаем функцию защищённой от наследования
    {
        if (isDead)
        {
            return;
        }
        if (checkTouch)
        {
            return; //если тач true то возвращаем
        }
        if (other.gameObject.CompareTag("Ally")) // если противник имеет тег "Ally"
        {
            CountMinus(); //запуск вычитания очков
        }
        if (other.gameObject.CompareTag("Enemy")) // если противник имеет тег "Enemy"
        {
            CountPlus(); //запуск прибавления очков         
        }
        if (other.gameObject.CompareTag("Ground")) //проверка соприкосновения ловушки запуск фх и таймер с запуском фх на уничтожение
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
    protected virtual void Puff() // функция пуфа и ниже функция уничтожения объекта
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

