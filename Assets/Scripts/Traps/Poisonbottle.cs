using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Poisonbottle : Trap
{
    // Start is called before the first frame update
    void Start()
    {
        Coll = GetComponent<SphereCollider>();
        psDamage = ParticleDamage.GetComponentInChildren<ParticleSystem>();
        psDestroy = ParticleDestoy.GetComponentInChildren<ParticleSystem>();
        psDamage.Pause();
        //psDestroy.Pause();
        psDestroy.gameObject.SetActive(false);

    }

    protected override void OnTriggerEnter(Collider other)
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
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (time)
        {
            if (timeToDestroy <= 0f) //проверка на гибель объекта
            {
                isDead = true;
                psDestroy.transform.parent = null;
                transform.parent.localScale = Vector3.Lerp(transform.parent.localScale, Vector3.zero, 5 * Time.deltaTime) ;

                if (transform.parent.localScale.x < 0.5f)
                {
                    psDestroy.transform.position = transform.position + Vector3.up;
                    psDestroy.gameObject.SetActive(true);
                    Destroy();
                }
            }
        }
    }
    protected override void Puff()
    {
        base.Puff();
    }
}
